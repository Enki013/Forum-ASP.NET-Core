using MediatR;
using AspNetCoreMvcIdentity.Models;

namespace AspNetCoreMvcIdentity.Application.Posts.Commands.CreatePost
{
    public class CreatePostCommand : IRequest<int>
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int ForumId { get; set; }
        public string UserId { get; set; }
    }
}
