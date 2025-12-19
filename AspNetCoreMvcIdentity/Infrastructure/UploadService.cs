using System;
using System.IO;
using System.Threading.Tasks;
using AspNetCoreMvcIdentity.Application.Common.Interfaces;
using Microsoft.AspNetCore.Http;

namespace AspNetCoreMvcIdentity.Infrastructure
{
    public class UploadService : IUploadService
    {
        public async Task<string> UploadFileAsync(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return null;

            // Ensure the uploads directory exists
            var uploadDir = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/forum");
            if (!Directory.Exists(uploadDir))
            {
                Directory.CreateDirectory(uploadDir);
            }

            // Generate unique filename
            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            var filePath = Path.Combine(uploadDir, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            // Return relative path for database storage
            return $"/images/forum/{fileName}";
        }
    }
}
