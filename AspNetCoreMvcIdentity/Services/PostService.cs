using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreMvcIdentity.Data;
using AspNetCoreMvcIdentity.Models;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreMvcIdentity.Services
{
    public class PostService : IPost
    {
        private readonly ApplicationDbContext _context;
        public PostService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task Add(Post post)
        {
            _context.Add(post);
            await _context.SaveChangesAsync();
        }

        public async Task AddReply(PostReply reply)
        {
            _context.PostReplays.Add(reply);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var post = GetById(id);
            if (post != null)
            {
                var replies = _context.PostReplays.Where(r => r.Post.Id == id);
                _context.PostReplays.RemoveRange(replies);
                _context.Posts.Remove(post);
                await _context.SaveChangesAsync();
            }
        }

        public Task EditPostContent(int id, string newContent)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Post> GetAll()
        {
            return _context.Posts
                .Include(p => p.User)
                .Include(p => p.Replies).ThenInclude(r => r.User)
                .Include(p => p.Forum);
        }

        public Post? GetById(int id)
        {
            return _context.Posts
                .Include(p => p.User)
                .Include(p => p.Replies)
                    .ThenInclude(r => r.User)
                .Include(p => p.Forum)
                .FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Post> GetFilteredPosts(Forum forum, string searchQuery)
        {
            var search = searchQuery;
            return string.IsNullOrEmpty(searchQuery) ? forum.Posts :
                forum.Posts.Where(p => p.Title.ToLower().Contains(search)
                || p.Content.Contains(search));
        }

        public IEnumerable<Post> GetFilteredPosts(string searchQuery)
        {
            var search = searchQuery.ToLower();
            return GetAll().Where(p => p.Title.ToLower().Contains(search)
                || p.Content.ToLower().Contains(search));
        }

        public IEnumerable<Post> GetLatestPosts(int n)
        {
            //Implement most popular posts///////////////////////////////////////////////////////////////////
            //GetAll().OrderByDescending(p => p.Replies.Count()).Take(n)
            return GetAll().OrderByDescending(p => p.Created).Take(n);
        }

        public IEnumerable<Post> GetMostPopularPosts(int n)
        {
            //Implement most popular posts///////////////////////////////////////////////////////////////////
            //GetAll().OrderByDescending(p => p.Replies.Count()).Take(n)
            return GetAll().OrderByDescending(p => p.Replies.Count()).Take(n);
        }


        public IEnumerable<Post> GetPostsByForum(int id)
        {
            return _context.Forums.Where(f => f.Id == id)
                .First().Posts;
        }
        public PostReply? GetReplyById(int id)
        {
            return _context.PostReplays
                .Include(r => r.User)
                .FirstOrDefault(r => r.Id == id);
        }

        public async Task Update(Post post)
        {
            _context.Posts.Update(post);
            await _context.SaveChangesAsync();
        }
    }
}
