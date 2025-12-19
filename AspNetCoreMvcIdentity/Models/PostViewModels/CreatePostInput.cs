using System.ComponentModel.DataAnnotations;

namespace AspNetCoreMvcIdentity.Models.PostViewModels
{
    /// <summary>
    /// Input DTO for creating a new post. Only contains user-submitted fields.
    /// </summary>
    public class CreatePostInput
    {
        public int ForumId { get; set; }
        
        [Required(ErrorMessage = "Title is required")]
        [MinLength(3, ErrorMessage = "Title must be at least 3 characters")]
        public string Title { get; set; }
        
        [Required(ErrorMessage = "Content is required")]
        [MinLength(1, ErrorMessage = "Content cannot be empty")]
        public string Content { get; set; }
    }
}
