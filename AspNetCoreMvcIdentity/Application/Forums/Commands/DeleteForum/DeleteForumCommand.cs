using MediatR;

namespace AspNetCoreMvcIdentity.Application.Forums.Commands.DeleteForum
{
    public class DeleteForumCommand : IRequest
    {
        public int ForumId { get; set; }
    }
}
