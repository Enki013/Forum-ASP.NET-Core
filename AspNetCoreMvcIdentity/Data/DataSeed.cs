using AspNetCoreMvcIdentity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreMvcIdentity.Data
{
    public class DataSeed
    {
        private readonly ApplicationDbContext _context;

        public DataSeed(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task SeedSuperUser()
        {
            var roleStore = new RoleStore<ApplicationRole, ApplicationDbContext, long>(_context);
            var userStore = new UserStore<ApplicationUser, ApplicationRole, ApplicationDbContext, long>(_context);

            var user = new ApplicationUser
            {
                UserName = "Admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@email.com",
                NormalizedEmail = "ADMIN@EMAIL.COM",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = Guid.NewGuid().ToString(),
                ProfileImageUrl = "/images/users/admin.png",
            };

            var hasher = new PasswordHasher<ApplicationUser>();
            user.PasswordHash = hasher.HashPassword(user, "admin");

            if (!_context.Roles.Any(r => r.Name == "Admin"))
            {
                await roleStore.CreateAsync(new ApplicationRole { Name = "Admin", NormalizedName = "ADMIN" });
            }

            if (!_context.Users.Any(u => u.NormalizedUserName == user.NormalizedUserName))
            {
                await userStore.CreateAsync(user);
                await userStore.AddToRoleAsync(user, "Admin"); // Rol ataması burada
            }

            await _context.SaveChangesAsync();
        }

        public async Task AssignAdminRoleManually()
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == "Admin");
            var role = await _context.Roles.FirstOrDefaultAsync(r => r.Name == "Admin");

            if (user != null && role != null)
            {
                var userRole = new IdentityUserRole<long>
                {
                    UserId = user.Id,
                    RoleId = role.Id
                };

                if (!_context.UserRoles.Any(ur => ur.UserId == user.Id && ur.RoleId == role.Id))
                {
                    _context.UserRoles.Add(userRole);
                    await _context.SaveChangesAsync();
                }
            }
        }

        public async Task SeedForumsAndPosts()
        {
            if (!_context.Forums.Any())
            {
                var forum = new Forum
                {
                    Title = "Genel Tartışma",
                    Description = "Genel konular hakkında tartışmalar.",
                    Created = DateTime.Now,
                    ImageUrl = "/images/forum/forum.png"
                };

                _context.Forums.Add(forum);
                await _context.SaveChangesAsync();

                var post = new Post
                {
                    Title = "Hoş Geldiniz",
                    Content = "Forumumuza hoş geldiniz! Burada genel konular hakkında tartışabilirsiniz.",
                    Created = DateTime.Now,
                    Forum = forum,
                    User = _context.Users.FirstOrDefault(u => u.UserName == "Admin")
                };

                _context.Posts.Add(post);
                await _context.SaveChangesAsync();
            }
        }

        public async Task SeedRoles()
        {
            var roleStore = new RoleStore<ApplicationRole, ApplicationDbContext, long>(_context);

            var roles = new[] { "Admin", "Standard", "Expert" };
            foreach (var role in roles)
            {
                if (!_context.Roles.Any(r => r.Name == role))
                {
                    await roleStore.CreateAsync(new ApplicationRole { Name = role, NormalizedName = role.ToUpper() });
                }
            }
            await _context.SaveChangesAsync();
        }
    }
}
