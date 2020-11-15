using System.Threading.Tasks;

namespace ClubApp.Common
{
    public interface IApiPrincipalResolver
    {
        ApiPrincipal Resolve();
    }
}
