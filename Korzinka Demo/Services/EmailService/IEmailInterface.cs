using Korzinka_Demo.Domain.Entities;

namespace Korzinka_Demo.Services.EmailService
{
    public interface IEmailInterface
    {
        public bool SendMail(MailData data);
    }
}
