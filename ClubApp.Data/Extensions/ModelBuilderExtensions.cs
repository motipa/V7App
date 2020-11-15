using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Reflection;

namespace ClubApp.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void ApplyConfigurations(this ModelBuilder modelBuilder, Assembly configurationAssembly)
        {
            MethodInfo applyConfigurationMethodInfo = modelBuilder.GetType().GetMethods(BindingFlags.Instance | BindingFlags.Public)
            .First(m => m.Name == "ApplyConfiguration");

            if (applyConfigurationMethodInfo != null)
            {
                configurationAssembly.GetTypes()
                .Select(t => (ty: t, itr: t.GetInterfaces().FirstOrDefault(i => i.Name == typeof(IEntityTypeConfiguration<>).Name)))
                .Where(tyitr => tyitr.itr != null)
                .Select(tyitr => (arg: tyitr.itr.GetGenericArguments()[0], tyobj: Activator.CreateInstance(tyitr.ty)))
                .Select(argobj => applyConfigurationMethodInfo.MakeGenericMethod(argobj.arg).Invoke(modelBuilder, new[] { argobj.tyobj }))
                .ToArray();
            }
        }
    }
}
