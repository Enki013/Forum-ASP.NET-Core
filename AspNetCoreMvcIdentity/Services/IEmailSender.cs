using System.Threading.Tasks;

namespace AspNetCoreMvcIdentity.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
