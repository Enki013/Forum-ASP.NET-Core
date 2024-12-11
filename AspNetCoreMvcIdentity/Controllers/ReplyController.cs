using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreMvcIdentity.Models;
using AspNetCoreMvcIdentity.Models.ReplyViewModels;
using AspNetCoreMvcIdentity.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreMvcIdentity.Controllers
{
    [Authorize]
    public class ReplyController : Controller
    {
        private readonly IPost _post;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IApplicationUser _user;


        public ReplyController(IPost post, UserManager<ApplicationUser> userManager, IApplicationUser user)
        {
            _post = post;
            _userManager = userManager;
            _user = user;
        }

        public async Task<IActionResult> Create(int id, int? parentReplyId, int? quotedReplyId)
        {
            var post = _post.GetById(id);
            if (post == null)
            {
                return NotFound();
            }

            var currentUser = await _userManager.FindByNameAsync(User.Identity.Name);
            var postAuthor = post.User;

            var model = new PostReplyModel
            {
                PostId = post.Id,
                PostTitle = post.Title,
                PostContent = post.Content,
                AuthorId = postAuthor.Id.ToString(),
                AuthorName = postAuthor.UserName,
                AuthorImageUrl = postAuthor.GetProfileImageUrl(),
                AuthorRating = postAuthor.Rating,
                IsAuthorAdmin = await _userManager.IsInRoleAsync(postAuthor, "Admin"),
                Created = post.Created,
                ForumId = post.Forum.Id,
                ForumName = post.Forum.Title,
                ForumImageUrl = post.Forum.ImageUrl,
                ParentReplyId = parentReplyId,
                UserType = postAuthor.UserType
            };

            if (quotedReplyId.HasValue)
            {
                var quotedReply = _post.GetReplyById(quotedReplyId.Value);
                if (quotedReply != null)
                {
                    model.QuotedReplyId = quotedReply.Id;
                    model.QuotedReplyContent = quotedReply.Content;
                }
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddReply(PostReplyModel model)
        {
            var userId = _userManager.GetUserId(User);
            var user = await _userManager.FindByIdAsync(userId);
            var quotedReply = model.QuotedReplyId.HasValue ? _post.GetReplyById(model.QuotedReplyId.Value) : null;
            var reply = BuildReply(model, user, quotedReply);

            await _post.AddReply(reply);
            await _user.UpdateUserRating(userId, typeof(PostReply));

            return RedirectToAction("Index", "Post", new { id = model.PostId });
        }

        private PostReply BuildReply(PostReplyModel model, ApplicationUser user, PostReply quotedReply)
        {
            var post = _post.GetById(model.PostId);
            return new PostReply
            {
                Post = post,
                Content = model.ReplyContent,
                Created = DateTime.Now,
                User = user,
                ParentReplyId = model.ParentReplyId,
                QuotedReplyId = model.QuotedReplyId,
                QuotedReplyContent = quotedReply != null ? $" {quotedReply.Content}" : null//post index from texti
            };
        }
    }
}