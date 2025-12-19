using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AspNetCoreMvcIdentity.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreMvcIdentity.Application.Posts.Commands.DeletePost
{
    public class DeletePostCommandHandler(ApplicationDbContext context) : IRequestHandler<DeletePostCommand>
    {
        private readonly ApplicationDbContext _context = context;

        public async Task Handle(DeletePostCommand request, CancellationToken cancellationToken)
        {
            var post = await _context.Posts
                .Include(p => p.Replies)
                .FirstOrDefaultAsync(p => p.Id == request.PostId, cancellationToken);
            
            if (post != null)
            {
                _context.PostReplays.RemoveRange(post.Replies);
                _context.Posts.Remove(post);
                await _context.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
