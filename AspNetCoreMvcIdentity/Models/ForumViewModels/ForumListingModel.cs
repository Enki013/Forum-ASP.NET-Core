namespace AspNetCoreMvcIdentity.Models.ForumViewModels
{
    public class ForumListingModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ForumImageUrl { get; set; } = string.Empty;

        public int NumberOfPosts { get; set; }
        public int NumberOfUsers { get; set; }
        public bool HasRecentPost { get; set; }
    }
}
