using System;
using System.Threading;
using System.Threading.Tasks;
using AspNetCoreMvcIdentity.Application.Common.Interfaces;
using AspNetCoreMvcIdentity.Models;
using AspNetCoreMvcIdentity.Services;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace AspNetCoreMvcIdentity.Application.Replies.Commands.CreateReply
{
    public class CreateReplyCommandHandler : IRequestHandler<CreateReplyCommand>
    {
        private readonly IPost _postService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IApplicationUser _userService;
        private readonly IDateTimeProvider _dateTime;

        public CreateReplyCommandHandler(
            IPost postService, 
            UserManager<ApplicationUser> userManager, 
            IApplicationUser userService,
            IDateTimeProvider dateTime)
        {
            _postService = postService;
            _userManager = userManager;
            _userService = userService;
            _dateTime = dateTime;
        }

        public async Task Handle(CreateReplyCommand request, CancellationToken cancellationToken)
        {
            var post = _postService.GetById(request.PostId);
            if (post == null)
            {
                throw new Exception($"Post with id {request.PostId} not found"); 
            }

            var user = await _userManager.FindByIdAsync(request.AuthorId);
            if (user == null)
            {
                throw new Exception($"User with id {request.AuthorId} not found"); 
            }

            PostReply quotedReply = null;
            string quotedContent = string.Empty;
            string quotedTitle = string.Empty;
            
            if (request.QuotedReplyId.HasValue)
            {
                quotedReply = _postService.GetReplyById(request.QuotedReplyId.Value);
                if (quotedReply != null)
                {
                    quotedContent = $" {quotedReply.Content}";
                }
            }

            var reply = new PostReply
            {
                Post = post,
                Content = request.Content,
                Title = post.Title,
                Created = _dateTime.Now,
                User = user,
                ParentReplyId = request.ParentReplyId,
                QuotedReplyId = request.QuotedReplyId,
                QuotedReplyContent = quotedContent
            };

            await _postService.AddReply(reply);
            await _userService.UpdateUserRating(user.Id.ToString(), typeof(PostReply));
            
            // MediatR 14.0 requires returning Task for void return type
            // But we implement IRequest which returns Unit implicitly if not specified? 
            // Wait, IRequest is void, so Task is enough.
        }
    }
}
