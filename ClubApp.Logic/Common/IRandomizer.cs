using System;
using System.Threading.Tasks;

namespace ClubApp.Logic.Common
{
    public interface IRandomizer
    {
        Task<string> GetRandomStringAsync();
    }
}
