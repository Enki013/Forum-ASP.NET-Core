using MediatR;

namespace AspNetCoreMvcIdentity.Application.Posts.Commands.CreatePost
{
    public class CreatePostCommand : IRequest<int>
    {
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public int ForumId { get; set; }
        public string UserId { get; set; } = string.Empty;
    }
}
