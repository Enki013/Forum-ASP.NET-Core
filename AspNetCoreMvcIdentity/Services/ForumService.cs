using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreMvcIdentity.Data;
using AspNetCoreMvcIdentity.Models;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreMvcIdentity.Services
{
    public class ForumService(ApplicationDbContext context) : IForum
    {
        private readonly ApplicationDbContext _context = context;

        public async Task Create(Forum forum)
        {
            _context.Add(forum);
            await _context.SaveChangesAsync();
        }


        public async Task Delete(int forumId)
        {
            var forum = await _context.Forums.FindAsync(forumId);
            
            if (forum != null)
            {
                // Explicitly load posts to delete them
                var posts = _context.Posts.Where(p => p.Forum.Id == forumId).Include(p => p.Replies).ToList();
                
                foreach (var post in posts)
                {
                    _context.PostReplays.RemoveRange(post.Replies);
                    _context.Posts.Remove(post);
                }

                _context.Forums.Remove(forum);
                await _context.SaveChangesAsync();
            }
        }

        public IEnumerable<Forum> GetAll()
        {
            return _context.Forums
                .Include(f => f.Posts)
                    .ThenInclude(p => p.User)
                .Include(f => f.Posts)
                    .ThenInclude(p => p.Replies)
                        .ThenInclude(r => r.User);
        }

   

        public IEnumerable<ApplicationUser> GetAllActiveUsers(int id)
        {
            var forum = GetById(id);
            var posts = forum?.Posts;
            if (posts != null && posts.Any())
            {
                var postUsers = posts.Select(p => p.User);
                var replyUsers = posts.SelectMany(p => p.Replies).Select(r => r.User);

                return postUsers.Union(replyUsers).Distinct();
            }
            return new List<ApplicationUser>();
        }

        public Forum? GetById(int id)
        {
            return _context.Forums.Where(f => f.Id == id)
                .Include(f => f.Posts)
                    .ThenInclude(p => p.User)
                .Include(f => f.Posts)
                    .ThenInclude(p => p.Replies)
                    .ThenInclude(r => r.User)
                .FirstOrDefault();

        }

        public bool HasRecentPost(int id)
        {
            const int hoursAgo = 24;
            var window = DateTime.Now.AddHours(-hoursAgo);
            var forum = GetById(id);
            if (forum == null)
            {
                return false;
            }
            return forum.Posts.Any(p => p.Created > window);
        }
    }
}
