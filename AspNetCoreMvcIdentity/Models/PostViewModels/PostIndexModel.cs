using AspNetCoreMvcIdentity.Models.ReplyViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreMvcIdentity.Models.PostViewModels
{
    public class PostIndexModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string AuthorImageUrl { get; set; }
        public int AuthorRating { get; set; }
        public DateTime Created { get; set; }
        public string PostContent { get; set; }
        public bool IsAuthorAdmin { get; set; }
        public string PostTitle { get; set; }

        public int ForumId { get; set; }
        public string ForumName { get; set; }

        public int? QuotedReplyId { get; set; }
        public string QuotedReplyContent { get; set; }
        public string UserType { get; set; } // Added UserType property

        public IEnumerable<PostReplyModel> Replies { get; set; }
    }
}
