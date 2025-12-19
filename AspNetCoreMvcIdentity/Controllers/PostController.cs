using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreMvcIdentity.Models;
using AspNetCoreMvcIdentity.Models.PostViewModels;
using AspNetCoreMvcIdentity.Models.ReplyViewModels;
using AspNetCoreMvcIdentity.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using AspNetCoreMvcIdentity.Application.Posts.Commands.CreatePost;

namespace AspNetCoreMvcIdentity.Controllers
{
    public class PostController : Controller
    {
        private readonly IForum _forum;
        private readonly IPost _post;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMediator _mediator;

        public PostController(IPost post, IForum forum, UserManager<ApplicationUser> userManager, IMediator mediator)
        {
            _post = post;
            _forum = forum;
            _userManager = userManager;
            _mediator = mediator;
        }

        public async Task<IActionResult> IndexAsync(int id)
        {
            var post = _post.GetById(id);
            
            if (post == null)
            {
                return NotFound();
            }
            
            post.Views += 1;
            await _post.Update(post);

            var replies = BuildPostReplies(post.Replies);
            
            var model = new PostIndexModel
            {
                Id = post.Id,
                Title = post.Title,
                AuthorId = post.User.Id.ToString(),
                AuthorName = post.User.UserName,
                AuthorRating = post.User.Rating,
                Created = post.Created,
                PostContent = post.Content,
                Replies = replies,
                ForumId = post.Forum.Id,
                ForumName = post.Forum.Title,
                AuthorImageUrl = post.User.GetProfileImageUrl(),
                IsAuthorAdmin = await IsAuthorAdmin(post.User),
                UserType = post.User.UserType
            };
            
            return View(model);
        }

        private async Task<bool> IsAuthorAdmin(ApplicationUser user)
        {
            return (await _userManager.GetRolesAsync(user)).Contains("Admin");
        }

        private IEnumerable<PostReplyModel> BuildPostReplies(IEnumerable<PostReply> replies)
        {
            return replies.Select(r => new PostReplyModel
            {
                Id = r.Id,
                AuthorName = r.User.UserName,
                AuthorId = r.User.Id.ToString(),
                AuthorImageUrl = r.User.GetProfileImageUrl(),
                AuthorRating = r.User.Rating,
                Created = r.Created,
                ReplyContent = r.Content,
                IsAuthorAdmin = IsAuthorAdmin(r.User).Result,
                QuotedReplyContent = r.QuotedReplyContent,
                QuotedReplyId = r.QuotedReplyId,
                UserType = r.User.UserType 
            });
        }
        
        [Authorize]
        public IActionResult Create(int id)
        {
            var forum = _forum.GetById(id);

            var model = new NewPostModel
            {
                ForumName = forum.Title,
                ForumId = forum.Id,
                ForumImageUrl = forum.ImageUrl,
                AuthorName = User.Identity.Name
            };

            return View(model);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            var post = _post.GetById(id);
            var model = new PostListingModel
            {
                Id = post.Id,
                Title = post.Title,
                DatePosted = post.Created.ToString()
            };

            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _post.Delete(id).Wait();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddPost(CreatePostInput input)
        {
            if (!ModelState.IsValid)
            {
                // Rebuild the display model for the Create view
                var forum = _forum.GetById(input.ForumId);
                var model = new NewPostModel
                {
                    ForumId = input.ForumId,
                    ForumName = forum?.Title,
                    ForumImageUrl = forum?.ImageUrl,
                    AuthorName = User.Identity?.Name,
                    Title = input.Title,
                    Content = input.Content
                };
                return View("Create", model);
            }

            var userId = _userManager.GetUserId(User);

            var command = new CreatePostCommand
            {
                Title = input.Title,
                Content = input.Content,
                ForumId = input.ForumId,
                UserId = userId
            };

            var id = await _mediator.Send(command);
            return RedirectToAction("Index", "Post", new { id = id });
        }
    }
}