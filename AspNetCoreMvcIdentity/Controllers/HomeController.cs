﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreMvcIdentity.Models;
using AspNetCoreMvcIdentity.Models.HomeViewModels;
using AspNetCoreMvcIdentity.Services;
using AspNetCoreMvcIdentity.Models.PostViewModels;
using AspNetCoreMvcIdentity.Models.ForumViewModels;
using Microsoft.AspNetCore.Identity;

namespace AspNetCoreMvcIdentity.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPost _post;
        private readonly IForum _forum;
        private readonly UserManager<ApplicationUser> _userManager;

        public HomeController(IPost post, IForum forum, UserManager<ApplicationUser> userManager)
        {
            _post = post;
            _forum = forum;
            _userManager = userManager;
        }


        public IActionResult Index()
        {
            var user = _userManager.GetUserAsync(User).Result;
            var isAdmin = user != null && _userManager.IsInRoleAsync(user, "Admin").Result;
            ViewBag.IsAdmin = isAdmin;
            var model = HomeIndexModel();
            return View(model);
        }

        private HomeIndexModel HomeIndexModel()
        {
            var latestPosts = _post.GetLatestPosts(10);
            var popularPosts = _post.GetMostPopularPosts(10);
            var forumvar = _forum.GetAll();

            var forums = forumvar.Select(f => new ForumListingModel
            {
                Id = f.Id,
                Title = f.Title,
                Description = f.Description,
                NumberOfPosts = f.Posts?.Count() ?? 0,
                NumberOfUsers = _forum.GetAllActiveUsers(f.Id).Count(),
                ForumImageUrl = f.ImageUrl,
                HasRecentPost = _forum.HasRecentPost(f.Id)


            });
          
            var posts = latestPosts.Select(p => new PostListingModel{
                Id = p.Id,
                Title = p.Title,
                AuthorName = p.User.UserName,
                AuthorId = p.User.Id.ToString(),
                AuthorRating = p.User.Rating,
                DatePosted = p.Created.ToString(),
                RepliesCount = p.Replies.Count(),
                Forum = GetForumListingForPost(p)

            });
            var postsPopular = popularPosts.Select(p => new PostListingModel{
                Id = p.Id,
                Title = p.Title,
                AuthorName = p.User.UserName,
                AuthorId = p.User.Id.ToString(),
                AuthorRating = p.User.Rating,
                DatePosted = p.Created.ToString(),
                RepliesCount = p.Replies.Count(),
                Forum = GetForumListingForPost(p)

            });
            return new HomeIndexModel
            {
                LatestPosts = posts,
                PopularPosts = postsPopular,
                SearchQuery = "",
                Forums = forums
                
            };


            
        }

        private ForumListingModel GetForumListingForPost(Post p)
        {
            var forum = p.Forum;
            if (forum == null)
            {
                return null; // or return a suitable default value
            }
            return new ForumListingModel
            {
                Title = forum.Title,
                ForumImageUrl = forum.ImageUrl,
                Id = forum.Id
            };
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
