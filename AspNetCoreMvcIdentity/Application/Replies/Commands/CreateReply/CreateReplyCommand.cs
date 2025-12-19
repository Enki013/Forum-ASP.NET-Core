using MediatR;

namespace AspNetCoreMvcIdentity.Application.Replies.Commands.CreateReply
{
    public class CreateReplyCommand : IRequest
    {
        public int PostId { get; set; }
        public string Content { get; set; } = string.Empty;
        public string AuthorId { get; set; } = string.Empty;
        public int? ParentReplyId { get; set; }
        public int? QuotedReplyId { get; set; }
    }
}
