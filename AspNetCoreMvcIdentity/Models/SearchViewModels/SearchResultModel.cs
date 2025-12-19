using AspNetCoreMvcIdentity.Models.PostViewModels;
using System.Collections.Generic;

namespace AspNetCoreMvcIdentity.Models.SearchViewModels
{
    public class SearchResultModel
    {
        public IEnumerable<PostListingModel> Posts { get; set; } = new List<PostListingModel>();
        public string SearchQuery { get; set; } = string.Empty;
        public bool EmptySearchResults { get; set; }
    }
}
