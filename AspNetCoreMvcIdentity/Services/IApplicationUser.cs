using AspNetCoreMvcIdentity.Models;
using System;
using System.Collections.Generic;
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
        Task UpdateAsync(ApplicationUser user);
        Task DeleteAsync(string id);
        Task UpdateUserStatusAsync(long id, bool isActive);
    }
}
