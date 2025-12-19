using System;
using System.Collections.Generic;

namespace AspNetCoreMvcIdentity.Models
{
    public class PostReply
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime Created { get; set; }
        public virtual ApplicationUser User { get; set; } = null!;
        public virtual Post Post { get; set; } = null!;
        public int? ParentReplyId { get; set; }
        public virtual PostReply? ParentReply { get; set; }
        public virtual ICollection<PostReply> Replies { get; set; } = new List<PostReply>();
        public int? QuotedReplyId { get; set; }
        public string QuotedReplyContent { get; set; } = string.Empty;
    }
}
