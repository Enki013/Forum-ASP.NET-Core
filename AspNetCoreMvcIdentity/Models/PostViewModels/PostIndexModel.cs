using AspNetCoreMvcIdentity.Models.ReplyViewModels;
using System;
using System.Collections.Generic;

namespace AspNetCoreMvcIdentity.Models.PostViewModels
{
    public class PostIndexModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string AuthorId { get; set; } = string.Empty;
        public string AuthorName { get; set; } = string.Empty;
        public string AuthorImageUrl { get; set; } = string.Empty;
        public int AuthorRating { get; set; }
        public DateTime Created { get; set; }
        public string PostContent { get; set; } = string.Empty;
        public bool IsAuthorAdmin { get; set; }
        public string PostTitle { get; set; } = string.Empty;

        public int ForumId { get; set; }
        public string ForumName { get; set; } = string.Empty;

        public int? QuotedReplyId { get; set; }
        public string QuotedReplyContent { get; set; } = string.Empty;
        public string UserType { get; set; } = string.Empty;

        public IEnumerable<PostReplyModel> Replies { get; set; } = new List<PostReplyModel>();
    }
}
