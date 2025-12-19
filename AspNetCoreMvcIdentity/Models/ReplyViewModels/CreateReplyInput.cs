using System.ComponentModel.DataAnnotations;

namespace AspNetCoreMvcIdentity.Models.ReplyViewModels
{
    /// <summary>
    /// Input DTO for creating a new reply. Only contains user-submitted fields.
    /// </summary>
    public class CreateReplyInput
    {
        public int PostId { get; set; }
        
        [Required(ErrorMessage = "Reply content is required")]
        [MinLength(1, ErrorMessage = "Reply content cannot be empty")]
        public string ReplyContent { get; set; }
        
        public int? ParentReplyId { get; set; }
        public int? QuotedReplyId { get; set; }
    }
}
