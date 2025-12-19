using AspNetCoreMvcIdentity.Models;
using MediatR;

namespace AspNetCoreMvcIdentity.Application.Posts.Queries.GetPostById
{
    public class GetPostByIdQuery : IRequest<Post?>
    {
        public int PostId { get; set; }
    }
}
