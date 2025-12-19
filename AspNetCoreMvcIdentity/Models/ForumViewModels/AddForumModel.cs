using AspNetCoreMvcIdentity.Models.ValidationAttributes;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace AspNetCoreMvcIdentity.Models.ForumViewModels
{
    /// <summary>
    /// Input DTO for creating a new forum. Only contains user-submitted fields.
    /// </summary>
    public class AddForumModel
    {
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; } = string.Empty;

        [AllowedExtensions(new string[] { ".jpg", ".jpeg", ".png", ".gif" })]
        [MaxFileSize(5 * 1024 * 1024)] // 5MB
        public IFormFile? ImageUpload { get; set; }
    }
}
