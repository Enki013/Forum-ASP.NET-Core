using AspNetCoreMvcIdentity.Models.ForumViewModels;
using AspNetCoreMvcIdentity.Models.PostViewModels;
using System.Collections.Generic;

namespace AspNetCoreMvcIdentity.Models.HomeViewModels
{
    public class HomeIndexModel
    {
        public string SearchQuery { get; set; } = string.Empty;
        public IEnumerable<PostListingModel> LatestPosts { get; set; } = new List<PostListingModel>();
        public IEnumerable<PostListingModel> PopularPosts { get; set; } = new List<PostListingModel>();
        public IEnumerable<ForumListingModel> Forums { get; set; } = new List<ForumListingModel>();
    }
}
