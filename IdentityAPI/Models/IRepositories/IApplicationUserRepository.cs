
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IdentityAPI.Models.IRepositories
{
    public interface IApplicationUserRepository
    {
        Task<IEnumerable<ApplicationUser>> GetApplicationUsers();
        Task Create(ApplicationUser user);
        Task Update(string id, ApplicationUser user);
        Task Delete(string id);
        Task<ApplicationUser> GetBy(string id);
    }
}