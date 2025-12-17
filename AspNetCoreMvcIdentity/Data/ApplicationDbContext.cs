using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AspNetCoreMvcIdentity.Models;
using Microsoft.AspNetCore.Identity;

namespace AspNetCoreMvcIdentity.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, long>
    {

        public DbSet<Forum> Forums { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostReply> PostReplays { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<ApplicationRole> IdentityRoles { get; set; } // Changed this line




        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            // Cascade delete sorununu çözmek için ilişkileri yapılandır
            builder.Entity<Post>()
                .HasOne(p => p.User)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Post>()
                .HasOne(p => p.Forum)
                .WithMany(f => f.Posts)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<PostReply>()
                .HasOne(r => r.User)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<PostReply>()
                .HasOne(r => r.Post)
                .WithMany(p => p.Replies)
                .OnDelete(DeleteBehavior.Cascade);
                
            builder.Entity<PostReply>()
                .HasOne(r => r.ParentReply)
                .WithMany(r => r.Replies)
                .HasForeignKey(r => r.ParentReplyId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
