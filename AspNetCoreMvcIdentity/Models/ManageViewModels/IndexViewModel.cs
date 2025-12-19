using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreMvcIdentity.Models.ManageViewModels
{
    public class IndexViewModel
    {
        public string? Username { get; set; }

        public bool IsEmailConfirmed { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Phone]
        [Display(Name = "Phone number")]
        public string? PhoneNumber { get; set; }

        public string? StatusMessage { get; set; }

        [Display(Name = "Status Message")]
        [StringLength(200, ErrorMessage = "Status mesajı en fazla 200 karakter olabilir.")]
        public string? UserStatusMessage { get; set; }
    }
}
