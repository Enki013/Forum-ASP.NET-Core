using System;
using System.Collections.Generic;

namespace AspNetCoreMvcIdentity.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime Created { get; set; }
        public int Views { get; set; }

        public virtual ApplicationUser User { get; set; } = null!;
        public virtual Forum Forum { get; set; } = null!;
        public virtual IEnumerable<PostReply> Replies { get; set; } = new List<PostReply>();
    }
}
