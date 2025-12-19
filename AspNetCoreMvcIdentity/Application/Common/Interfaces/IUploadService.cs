using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace AspNetCoreMvcIdentity.Application.Common.Interfaces
{
    public interface IUploadService
    {
        Task<string> UploadFileAsync(IFormFile file);
    }
}
