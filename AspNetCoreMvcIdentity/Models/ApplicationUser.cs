using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace AspNetCoreMvcIdentity.Models
{

// Rating: Kullanıcı puanı
// ProfileImageUrl: Profil resmi yolu
// MemberSince: Üyelik tarihi
// IsActive: Kullanıcı aktiflik durumu
// UserType: Kullanıcı tipi (Admin/Mod/User)

    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser<long>
    {
        public int Rating { get; set; }
        public string? ProfileImageUrl { get; set; }
        public DateTime MemberSince { get; set; }
        public bool IsActive { get; set; }
        public ICollection<Post> Posts { get; set; }
        public ICollection<PostReply> Replies { get; set; }
        public string? UserType { get; set; } // "Admin", "Mod", or "User"
    }
}
