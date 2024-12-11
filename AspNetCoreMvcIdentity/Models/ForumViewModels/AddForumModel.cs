using AspNetCoreMvcIdentity.Models.ValidationAttributes;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreMvcIdentity.Models.ForumViewModels
{
    public class AddForumModel
    {
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }
        
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
        
        public string ImageUrl { get; set; }

        [AllowedExtensions(new string[] { ".jpg", ".jpeg", ".png", ".gif" })]
        [MaxFileSize(5 * 1024 * 1024)] // 5MB
        public IFormFile ImageUpload { get; set; }
    }
}
