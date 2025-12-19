using AspNetCoreMvcIdentity.Models.PostViewModels;
using System.Collections.Generic;

namespace AspNetCoreMvcIdentity.Models.ForumViewModels
{
    public class ForumDetailsModel
    {
        public ForumListingModel Forum { get; set; } = new ForumListingModel();
        public IEnumerable<PostListingModel> Posts { get; set; } = new List<PostListingModel>();
        public string SearchQuery { get; set; } = string.Empty;
    }
}
