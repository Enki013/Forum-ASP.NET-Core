using System;
using System.Threading;
using System.Threading.Tasks;
using AspNetCoreMvcIdentity.Application.Common.Interfaces;
using AspNetCoreMvcIdentity.Models;
using AspNetCoreMvcIdentity.Services;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace AspNetCoreMvcIdentity.Application.Posts.Commands.CreatePost
{
    public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, int>
    {
        private readonly IPost _postService;
        private readonly IForum _forumService;
        private readonly IApplicationUser _userService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IDateTimeProvider _dateTimeProvider;

        public CreatePostCommandHandler(
            IPost postService,
            IForum forumService,
            IApplicationUser userService,
            UserManager<ApplicationUser> userManager,
            IDateTimeProvider dateTimeProvider)
        {
            _postService = postService;
            _forumService = forumService;
            _userService = userService;
            _userManager = userManager;
            _dateTimeProvider = dateTimeProvider;
        }

        public async Task<int> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId);
            if (user == null)
            {
                throw new Exception($"User with id {request.UserId} not found");
            }

            var forum = _forumService.GetById(request.ForumId);
            if (forum == null)
            {
                throw new Exception($"Forum with id {request.ForumId} not found");
            }

            var post = new Post
            {
                Title = request.Title,
                Content = request.Content,
                Created = _dateTimeProvider.Now,
                User = user,
                Forum = forum
            };

            await _postService.Add(post);
            await _userService.UpdateUserRating(user.Id.ToString(), typeof(Post));

            return post.Id;
        }
    }
}
