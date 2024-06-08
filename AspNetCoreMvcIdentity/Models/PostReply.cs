using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreMvcIdentity.Models
{
    public class PostReply
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Created { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual Post Post { get; set; }
        public int? ParentReplyId { get; set; }
        public virtual PostReply ParentReply { get; set; }
        public virtual ICollection<PostReply> Replies { get; set; }
        public int? QuotedReplyId { get; set; }
        public string QuotedReplyContent { get; set; }
    }
}
