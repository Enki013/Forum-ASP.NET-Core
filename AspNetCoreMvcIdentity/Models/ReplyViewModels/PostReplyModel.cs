using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AspNetCoreMvcIdentity.Models.ReplyViewModels
{
    public class PostReplyModel
    {
        public int Id { get; set; }
        public string AuthorId { get; set; } = string.Empty;
        public string AuthorName { get; set; } = string.Empty;
        public string AuthorImageUrl { get; set; } = string.Empty;
        public int AuthorRating { get; set; }
        public DateTime Created { get; set; }
        
        [Required(ErrorMessage = "Reply content is required")]
        [MinLength(1, ErrorMessage = "Reply content cannot be empty")]
        public string ReplyContent { get; set; } = string.Empty;
        public bool IsAuthorAdmin { get; set; }

        public int PostId { get; set; }
        public string PostTitle { get; set; } = string.Empty;
        public string PostContent { get; set; } = string.Empty;
        public string ForumName { get; set; } = string.Empty;
        public string ForumImageUrl { get; set; } = string.Empty;
        public int ForumId { get; set; }

        public int? ParentReplyId { get; set; }
        public int? QuotedReplyId { get; set; }
        public string QuotedReplyContent { get; set; } = string.Empty;
        public IEnumerable<PostReplyModel> Replies { get; set; } = new List<PostReplyModel>();
        public string UserType { get; set; } = string.Empty;
    }
}
