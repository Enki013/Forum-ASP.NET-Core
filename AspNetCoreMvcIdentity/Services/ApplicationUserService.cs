using AspNetCoreMvcIdentity.Data;
using AspNetCoreMvcIdentity.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreMvcIdentity.Services
{
    public class ApplicationUserService(ApplicationDbContext context, UserManager<ApplicationUser> userManager) : IApplicationUser
    {
        private readonly ApplicationDbContext _context = context;
        private readonly UserManager<ApplicationUser> _userManager = userManager;

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
            if (user == null)
            {
                return;
            }
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
            if (user == null)
            {
                return;
            }
            user.ProfileImageUrl = uri?.AbsoluteUri ?? "/images/users/default.png"; // Default resim ekleyin
            _context.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ApplicationUser user)
        {
            _context.ApplicationUsers.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var user = await _context.ApplicationUsers.FindAsync(Convert.ToInt64(id));
            if (user != null)
            {
                _context.ApplicationUsers.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateUserStatusAsync(long userId, bool isActive)
        {
            var user = GetById(userId);
            if (user != null)
            {
                user.IsActive = isActive;
                await _context.SaveChangesAsync();
            }
        }
    }
}