namespace AspNetCoreMvcIdentity.Models.ManageViewModels
{
    public class RemoveLoginViewModel
    {
        public string LoginProvider { get; set; } = string.Empty;
        public string ProviderKey { get; set; } = string.Empty;
    }
}
