using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace AspNetCoreMvcIdentity.Services
{
    public interface IUpload
    {
        Task<string> UploadFileAsync(IFormFile file);
    }
}