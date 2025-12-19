using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AspNetCoreMvcIdentity.Data;
using AspNetCoreMvcIdentity.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreMvcIdentity.Application.Forums.Queries.GetForumById
{
    public class GetForumByIdQueryHandler(ApplicationDbContext context) : IRequestHandler<GetForumByIdQuery, Forum?>
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<Forum?> Handle(GetForumByIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.Forums
                .Where(f => f.Id == request.ForumId)
                .Include(f => f.Posts)
                    .ThenInclude(p => p.User)
                .Include(f => f.Posts)
                    .ThenInclude(p => p.Replies)
                        .ThenInclude(r => r.User)
                .FirstOrDefaultAsync(cancellationToken);
        }
    }
}
