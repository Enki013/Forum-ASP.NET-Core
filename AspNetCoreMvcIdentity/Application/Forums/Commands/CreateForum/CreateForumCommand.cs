using MediatR;
using Microsoft.AspNetCore.Http;

namespace AspNetCoreMvcIdentity.Application.Forums.Commands.CreateForum
{
    public class CreateForumCommand : IRequest
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public IFormFile? ImageUpload { get; set; }
    }
}
