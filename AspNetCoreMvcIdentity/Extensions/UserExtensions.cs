using AspNetCoreMvcIdentity.Models;

public static class UserExtensions
{
    private const string DEFAULT_PROFILE_IMAGE = "/images/users/default.png";

    public static string GetProfileImageUrl(this ApplicationUser user)
    {
        return string.IsNullOrEmpty(user.ProfileImageUrl) 
            ? DEFAULT_PROFILE_IMAGE 
            : user.ProfileImageUrl;
    }
} 