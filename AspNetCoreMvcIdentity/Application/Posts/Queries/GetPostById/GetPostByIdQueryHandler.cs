using System.Threading;
using System.Threading.Tasks;
using AspNetCoreMvcIdentity.Data;
using AspNetCoreMvcIdentity.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreMvcIdentity.Application.Posts.Queries.GetPostById
{
    public class GetPostByIdQueryHandler(ApplicationDbContext context) : IRequestHandler<GetPostByIdQuery, Post?>
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<Post?> Handle(GetPostByIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.Posts
                .Include(p => p.User)
                .Include(p => p.Replies)
                    .ThenInclude(r => r.User)
                .Include(p => p.Forum)
                .FirstOrDefaultAsync(p => p.Id == request.PostId, cancellationToken);
        }
    }
}
