namespace MailService.Domain.Services;

public interface ISmtpService
{
    bool SendMessage();
}

public class SmtpService : ISmtpService
{
    public bool SendMessage()
    {
        return true;
    }
}