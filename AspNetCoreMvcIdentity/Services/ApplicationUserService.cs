using AspNetCoreMvcIdentity.Data;
using AspNetCoreMvcIdentity.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;

namespace AspNetCoreMvcIdentity.Services
{
    public class ApplicationUserService : IApplicationUser
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public ApplicationUserService(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IEnumerable<ApplicationUser> GetAll()
        {
            return _context.ApplicationUsers.ToList();
        }

        public bool IsInRole(ApplicationUser user, string role)
        {
            return _userManager.IsInRoleAsync(user, role).Result;
        }

        public ApplicationUser? GetById(long id)
        {
            return GetAll().FirstOrDefault(u => u.Id == id);
        }

        public async Task UpdateUserRating(string id, Type type)
        {
            var longid = Convert.ToInt64(id);
            var user = GetById(longid);
            user.Rating = CalculateUserRating(type, user.Rating);
            await _context.SaveChangesAsync();
        }

        private int CalculateUserRating(Type type, int userRating)
        {
            var inc = 0;
            if (type == typeof(Post))
                inc = 1;
            if (type == typeof(PostReply))
                inc = 3;

            return userRating + inc;
        }

        public async Task SetProfileImage(long id, Uri uri)
        {
            var user = GetById(id);
            user.ProfileImageUrl = uri?.AbsoluteUri ?? "/images/users/default.png"; // Default resim ekleyin
            _context.Update(user);
            await _context.SaveChangesAsync();
        }

        public void Update(ApplicationUser user)
        {
            _context.ApplicationUsers.Update(user);
            _context.SaveChanges();
        }

        public void Delete(string id)
        {
            var user = _context.ApplicationUsers.Find(Convert.ToInt64(id));
            if (user != null)
            {
                _context.ApplicationUsers.Remove(user);
                _context.SaveChanges();
            }
        }

        public void UpdateUserStatus(long userId, bool isActive)
        {
            var user = GetById(userId);
            if (user != null)
            {
                user.IsActive = isActive;
                _context.SaveChanges();
            }
        }
    }
}