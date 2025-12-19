using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AspNetCoreMvcIdentity.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreMvcIdentity.Application.Forums.Commands.DeleteForum
{
    public class DeleteForumCommandHandler(ApplicationDbContext context) : IRequestHandler<DeleteForumCommand>
    {
        private readonly ApplicationDbContext _context = context;

        public async Task Handle(DeleteForumCommand request, CancellationToken cancellationToken)
        {
            var forum = await _context.Forums.FindAsync(new object[] { request.ForumId }, cancellationToken);
            
            if (forum != null)
            {
                // Load and delete posts with their replies
                var posts = await _context.Posts
                    .Where(p => p.Forum.Id == request.ForumId)
                    .Include(p => p.Replies)
                    .ToListAsync(cancellationToken);
                
                foreach (var post in posts)
                {
                    _context.PostReplays.RemoveRange(post.Replies);
                    _context.Posts.Remove(post);
                }

                _context.Forums.Remove(forum);
                await _context.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
