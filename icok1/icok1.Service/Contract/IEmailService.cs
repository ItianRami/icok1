using icok1.Domain.Settings;
using System.Threading.Tasks;

namespace icok1.Service.Contract
{
    public interface IEmailService
    {
        Task SendEmailAsync(MailRequest mailRequest);

    }
}
