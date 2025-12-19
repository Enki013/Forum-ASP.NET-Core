using System.Collections.Generic;

namespace AspNetCoreMvcIdentity.Models.ForumViewModels
{
    public class ForumIndexModel
    {
        public IEnumerable<ForumListingModel> ForumList { get; set; } = new List<ForumListingModel>();
    }
}
