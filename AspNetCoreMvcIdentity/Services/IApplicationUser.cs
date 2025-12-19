using AspNetCoreMvcIdentity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;

namespace AspNetCoreMvcIdentity.Services
{
    public interface IApplicationUser
    {
        ApplicationUser? GetById(long id);
        IEnumerable<ApplicationUser> GetAll();
        bool IsInRole(ApplicationUser user, string role);

        Task SetProfileImage(long id, Uri uri);
        Task UpdateUserRating(string id, Type type);
        void Update(ApplicationUser user);
        void Delete(string id);
        void UpdateUserStatus(long id, bool isActive);
    }
}
