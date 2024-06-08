using System.Collections.Generic;
using AspNetCoreMvcIdentity.Models;

public class AdminDashboardViewModel
{
    public int TotalUsers { get; set; }
    public int ActiveUsers { get; set; }
    public int AdminUsers { get; set; }
    public int TotalPosts { get; set; }
    public int TotalReplies { get; set; }
    public int TotalForums { get; set; }
    public int TotalViews { get; set; }
    public IEnumerable<ApplicationUser> Users { get; set; }
}