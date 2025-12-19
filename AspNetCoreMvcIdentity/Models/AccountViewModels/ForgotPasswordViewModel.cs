using System.ComponentModel.DataAnnotations;

namespace AspNetCoreMvcIdentity.Models.AccountViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
    }
}
