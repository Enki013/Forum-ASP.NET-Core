using AspNetCoreMvcIdentity.Models.ForumViewModels;

namespace AspNetCoreMvcIdentity.Models.PostViewModels
{
    public class PostListingModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string AuthorName { get; set; } = string.Empty;
        public int AuthorRating { get; set; }
        public string AuthorId { get; set; } = string.Empty;
        public string DatePosted { get; set; } = string.Empty;

        public int ForumId { get; set; }
        public string ForumImageUrl { get; set; } = string.Empty;
        public string ForumName { get; set; } = string.Empty;

        public int RepliesCount { get; set; }

        public ForumListingModel? Forum { get; set; }
    }
}
