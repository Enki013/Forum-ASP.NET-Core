using MediatR;
using Microsoft.AspNetCore.Http;

namespace AspNetCoreMvcIdentity.Application.Forums.Commands.CreateForum
{
    public class CreateForumCommand : IRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public IFormFile ImageUpload { get; set; }
    }
}
