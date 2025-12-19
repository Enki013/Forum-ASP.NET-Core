using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreMvcIdentity.Models;
using AspNetCoreMvcIdentity.Models.ApplicationUserViewModels;
using AspNetCoreMvcIdentity.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreMvcIdentity.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IApplicationUser _user;

        public ProfileController(UserManager<ApplicationUser> userManager, IApplicationUser user)
        {
            _userManager = userManager;
            _user = user;
        }



        public IActionResult Details(long id)
        {
            var user = _user.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            
            var userRoles = _userManager.GetRolesAsync(user).Result;
            var isAdmin = userRoles.Contains("Admin");
            var model = new ProfileModel()
            {
                UserId = user.Id,
                UserName = user.UserName,
                UserRating = user.Rating.ToString(),
                Email = user.Email,
                ProfileImageUrl = isAdmin ? "/images/users/admin.png" : user.GetProfileImageUrl(),
                MemberSince = user.MemberSince,
                IsAdmin = isAdmin,
                UserType = user.UserType,
                StatusMessage = user.StatusMessage
            };
            return View(model);
        }


        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            var profiles = _user.GetAll().Select(u => new ProfileModel
            {
                UserId = u.Id,
                Email = u.Email,
                UserName = u.UserName,
                ProfileImageUrl = u.ProfileImageUrl,
                UserRating = u.Rating.ToString(),
                MemberSince = u.MemberSince,
                IsAdmin = _userManager.GetRolesAsync(u).Result.Contains("Admin"),
                UserType = u.UserType
            });

            var model = new ProfileListModel
            {
                Profiles = profiles
            };
            return View(model);

        }
    }
}