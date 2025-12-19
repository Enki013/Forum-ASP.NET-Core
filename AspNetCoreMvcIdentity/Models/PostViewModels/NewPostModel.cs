using System.ComponentModel.DataAnnotations;

namespace AspNetCoreMvcIdentity.Models.PostViewModels
{
    public class NewPostModel
    {
        public string ForumName { get; set; } = string.Empty;
        public string AuthorName { get; set; } = string.Empty;
        public string ForumImageUrl { get; set; } = string.Empty;
        public int ForumId { get; set; }
        
        [Required(ErrorMessage = "Title is required")]
        [MinLength(3, ErrorMessage = "Title must be at least 3 characters")]
        public string Title { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Content is required")]
        [MinLength(1, ErrorMessage = "Content cannot be empty")]
        public string Content { get; set; } = string.Empty;
        
        public string UserId { get; set; } = string.Empty;
        public int? ParentReplyId { get; set; }
    }
}
