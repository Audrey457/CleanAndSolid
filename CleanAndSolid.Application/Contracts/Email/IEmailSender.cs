using CleanAndSolid.Application.Models.Email;

namespace CleanAndSolid.Application.Contracts.Email
{
    public interface IEmailSender
    {
        Task<bool> SendEmail(EmailMessage email);
    }
}
