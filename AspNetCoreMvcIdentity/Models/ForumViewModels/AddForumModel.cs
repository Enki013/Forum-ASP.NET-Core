using AspNetCoreMvcIdentity.Models.ValidationAttributes;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreMvcIdentity.Models.ForumViewModels
{
    /// <summary>
    /// Input DTO for creating a new forum. Only contains user-submitted fields.
    /// </summary>
    public class AddForumModel
    {
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }
        
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [AllowedExtensions(new string[] { ".jpg", ".jpeg", ".png", ".gif" })]
        [MaxFileSize(5 * 1024 * 1024)] // 5MB
        public IFormFile? ImageUpload { get; set; }
    }
}
