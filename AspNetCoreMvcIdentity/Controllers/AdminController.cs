using Microsoft.AspNetCore.Mvc;
using AspNetCoreMvcIdentity.Models;
using AspNetCoreMvcIdentity.Services;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

[Authorize(Roles = "Admin")]
public class AdminController : Controller
{
    private readonly IApplicationUser _userService;
    private readonly IPost _postService;
    private readonly IForum _forumService;
    private readonly UserManager<ApplicationUser> _userManager;

    public AdminController(IApplicationUser userService, IPost postService, IForum forumService, UserManager<ApplicationUser> userManager)
    {
        _userService = userService;
        _postService = postService;
        _forumService = forumService;
        _userManager = userManager;
    }

    public IActionResult Index()
    {
        var model = new AdminDashboardViewModel
        {
            TotalUsers = _userService.GetAll().Count(),
            ActiveUsers = _userService.GetAll().Count(u => u.IsActive),
            AdminUsers = _userService.GetAll().Count(u => _userService.IsInRole(u, "Admin")),
            TotalPosts = _postService.GetAll().Count(),
            TotalReplies = _postService.GetAll().Sum(p => p.Replies.Count()),
            TotalForums = _forumService.GetAll().Count(), // New feature
            TotalViews = _postService.GetAll().Sum(p => p.Views), // New feature
            Users = _userService.GetAll() // New feature
        };

        return View(model);
    }

    [HttpPost]
    public IActionResult UpdateUserStatus(long userId, bool isActive)
    {
        _userService.UpdateUserStatus(userId, isActive);
        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<IActionResult> SetUserRole(long userId, string role)
    {
        var user = _userService.GetById(userId);
        if (user != null)
        {
            var roles = new[] { "Admin", "Standard", "Expert" };
            foreach (var r in roles)
            {
                if (await _userManager.IsInRoleAsync(user, r))
                {
                    await _userManager.RemoveFromRoleAsync(user, r);
                }
            }
            var result = await _userManager.AddToRoleAsync(user, role);
            if (result.Succeeded)
            {
                user.UserType = role;
                _userService.Update(user);
            }
        }
        return RedirectToAction("Index");
    }
}