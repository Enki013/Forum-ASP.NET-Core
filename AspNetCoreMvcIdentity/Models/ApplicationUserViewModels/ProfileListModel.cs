using System.Collections.Generic;

namespace AspNetCoreMvcIdentity.Models.ApplicationUserViewModels
{
    public class ProfileListModel
    {
        public IEnumerable<ProfileModel> Profiles { get; set; } = new List<ProfileModel>();
    }
}
