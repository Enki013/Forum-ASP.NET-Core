using MediatR;

namespace AspNetCoreMvcIdentity.Application.Replies.Commands.CreateReply
{
    public class CreateReplyCommand : IRequest
    {
        public int PostId { get; set; }
        public string Content { get; set; }
        public string AuthorId { get; set; }
        public int? ParentReplyId { get; set; }
        public int? QuotedReplyId { get; set; }
    }
}
