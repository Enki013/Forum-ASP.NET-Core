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
using MediatR;
using AspNetCoreMvcIdentity.Application.Replies.Commands.CreateReply;

namespace AspNetCoreMvcIdentity.Controllers
{
    [Authorize]
    public class ReplyController : Controller
    {
        private readonly IPost _post;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMediator _mediator;

        public ReplyController(IPost post, UserManager<ApplicationUser> userManager, IMediator mediator)
        {
            _post = post;
            _userManager = userManager;
            _mediator = mediator;
        }

        public async Task<IActionResult> Create(int id, int? parentReplyId, int? quotedReplyId)
        {
            var post = _post.GetById(id);
            if (post == null)
            {
                return NotFound();
            }

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

            var command = new CreateReplyCommand
            {
                PostId = model.PostId,
                Content = model.ReplyContent,
                AuthorId = userId,
                ParentReplyId = model.ParentReplyId,
                QuotedReplyId = model.QuotedReplyId
            };

            await _mediator.Send(command);

            return RedirectToAction("Index", "Post", new { id = model.PostId });
        }
    }
}