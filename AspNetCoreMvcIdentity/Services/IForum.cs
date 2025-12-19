using AspNetCoreMvcIdentity.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspNetCoreMvcIdentity.Services
{
    public interface IForum
    {
        Forum? GetById(int id);
        IEnumerable<Forum> GetAll();

        Task Create(Forum forum);
        Task Delete(int forumId);

        bool HasRecentPost(int id);
        IEnumerable<ApplicationUser> GetAllActiveUsers(int id);
    }
}
