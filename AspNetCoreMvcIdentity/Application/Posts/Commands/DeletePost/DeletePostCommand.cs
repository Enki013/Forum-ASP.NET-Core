using MediatR;

namespace AspNetCoreMvcIdentity.Application.Posts.Commands.DeletePost
{
    public class DeletePostCommand : IRequest
    {
        public int PostId { get; set; }
    }
}
