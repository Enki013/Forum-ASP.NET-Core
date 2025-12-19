using AspNetCoreMvcIdentity.Models;
using MediatR;

namespace AspNetCoreMvcIdentity.Application.Forums.Queries.GetForumById
{
    public class GetForumByIdQuery : IRequest<Forum?>
    {
        public int ForumId { get; set; }
    }
}
