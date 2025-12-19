using System;
using System.Collections.Generic;

namespace AspNetCoreMvcIdentity.Models
{
    public class Forum
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime Created { get; set; }
        public string ImageUrl { get; set; } = string.Empty;

        public virtual IEnumerable<Post> Posts { get; set; } = new List<Post>();
    }
}
