using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreMvcIdentity.Models;
using AspNetCoreMvcIdentity.Models.ReplyViewModels;
using AspNetCoreMvcIdentity.Services;
using AspNetCoreMvcIdentity.Application.Replies.Commands.CreateReply;
using AspNetCoreMvcIdentity.Application.Posts.Queries.GetPostById;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MediatR;

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
            var post = await _mediator.Send(new GetPostByIdQuery { PostId = id });
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
                AuthorName = postAuthor.UserName ?? string.Empty,
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
        public async Task<IActionResult> AddReply(CreateReplyInput input)
        {
            if (!ModelState.IsValid)
            {
                // Rebuild the display model for the Create view
                var post = await _mediator.Send(new GetPostByIdQuery { PostId = input.PostId });
                if (post == null) return NotFound();
                
                var postAuthor = post.User;
                var model = new PostReplyModel
                {
                    PostId = post.Id,
                    PostTitle = post.Title,
                    PostContent = post.Content,
                    AuthorId = postAuthor.Id.ToString(),
                    AuthorName = postAuthor.UserName ?? string.Empty,
                    AuthorImageUrl = postAuthor.GetProfileImageUrl(),
                    AuthorRating = postAuthor.Rating,
                    IsAuthorAdmin = await _userManager.IsInRoleAsync(postAuthor, "Admin"),
                    Created = post.Created,
                    ForumId = post.Forum.Id,
                    ForumName = post.Forum.Title,
                    ForumImageUrl = post.Forum.ImageUrl,
                    ParentReplyId = input.ParentReplyId,
                    ReplyContent = input.ReplyContent,
                    UserType = postAuthor.UserType
                };
                return View("Create", model);
            }

            var userId = _userManager.GetUserId(User);

            var command = new CreateReplyCommand
            {
                PostId = input.PostId,
                Content = input.ReplyContent,
                AuthorId = userId ?? string.Empty,
                ParentReplyId = input.ParentReplyId,
                QuotedReplyId = input.QuotedReplyId
            };

            await _mediator.Send(command);

            return RedirectToAction("Index", "Post", new { id = input.PostId });
        }
    }
}