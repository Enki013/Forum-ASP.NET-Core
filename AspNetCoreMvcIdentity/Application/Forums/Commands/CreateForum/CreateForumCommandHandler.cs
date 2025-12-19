using System;
using System.Threading;
using System.Threading.Tasks;
using AspNetCoreMvcIdentity.Application.Common.Interfaces;
using AspNetCoreMvcIdentity.Models;
using AspNetCoreMvcIdentity.Services;
using MediatR;

namespace AspNetCoreMvcIdentity.Application.Forums.Commands.CreateForum
{
    public class CreateForumCommandHandler : IRequestHandler<CreateForumCommand>
    {
        private readonly IForum _forumService;
        private readonly IUploadService _uploadService;
        private readonly IDateTimeProvider _dateTime;

        public CreateForumCommandHandler(IForum forumService, IUploadService uploadService, IDateTimeProvider dateTime)
        {
            _forumService = forumService;
            _uploadService = uploadService;
            _dateTime = dateTime;
        }

        public async Task Handle(CreateForumCommand request, CancellationToken cancellationToken)
        {
            var imageUri = "/images/forum/forum.png"; // Default image path

            if (request.ImageUpload != null)
            {
                var uploadedUri = await _uploadService.UploadFileAsync(request.ImageUpload);
                if (uploadedUri != null)
                {
                    imageUri = uploadedUri;
                }
            }

            var forum = new Forum
            {
                Title = request.Title,
                Description = request.Description,
                Created = _dateTime.Now,
                ImageUrl = imageUri
            };

            await _forumService.Create(forum);
        }
    }
}
