using MailKit.Net.Smtp;
using MailService.Api.Models;
using MailService.Domain.Models;
using MimeKit;

namespace MailService.Domain.Services;

/// <summary>
/// SMTP сервис
/// </summary>
public interface ISmtpService
{
    /// <summary>
    /// Отправить сообщение
    /// </summary>
    /// <returns></returns>
    Task<bool> SendMessageAsync(Mail mail, CancellationToken cancellationToken);
}

/// <inheritdoc />
public class SmtpService : ISmtpService
{
    private readonly SmtpSettings _smtp;

    public SmtpService(SmtpSettings smtp)
    {
        _smtp = smtp;
    }

    /// <inheritdoc />
    public async Task<bool> SendMessageAsync(Mail mail, CancellationToken cancellationToken)
    {
        var message = new MimeMessage();
        message.From.Add(new MailboxAddress(_smtp.FromName, _smtp.FromAddress));

        foreach (var recipient in mail.MailEnvelope.Recipients)
        {
            message.To.Add(new MailboxAddress("", recipient));
        }
        message.Subject = mail.MailEnvelope.Subject;

        message.Body = new TextPart("plain") {
            Text = mail.MailEnvelope.Body
        };

        using var client = new SmtpClient();

        try
        {
            await client.ConnectAsync(_smtp.Host, _smtp.Port, _smtp.UseSsl, cancellationToken);
            await client.AuthenticateAsync(_smtp.UserName, _smtp.Password, cancellationToken);
            await client.SendAsync(message, cancellationToken);
            mail.Result = SendResult.OK;
        }
        catch (Exception ex) when (ex is not OperationCanceledException)
        {
            mail.FailedMessage = ex.Message;
            mail.Result = SendResult.Failed;
        }

        await client.DisconnectAsync(true, cancellationToken);

        return true;
    }
}