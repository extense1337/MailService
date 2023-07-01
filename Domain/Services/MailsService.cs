using Domain.Models;
using Domain.Repositories;

namespace Domain.Services;

/// <summary>
/// Сервис сообщений
/// </summary>
public interface IMailService
{
    /// <summary>
    /// Отправить сообщение
    /// </summary>
    /// <param name="mailEnvelope"></param>
    /// <param name="cancellationToken"></param>
    Task<Mail> SendMailAsync(MailEnvelope mailEnvelope, CancellationToken cancellationToken);

    /// <summary>
    /// Получить все сообщения
    /// </summary>
    IEnumerable<Mail> GetAllMails();
}

/// <summary>
/// Сервис сообщений
/// </summary>
public class MailsService : IMailService
{
    private readonly IMailRepository _mailRepository;
    private readonly ISmtpService _smtpService;

    public MailsService(IMailRepository mailRepository, ISmtpService smtpService)
    {
        _mailRepository = mailRepository;
        _smtpService = smtpService;
    }

    /// <inheritdoc />
    public async Task<Mail> SendMailAsync(MailEnvelope mailEnvelope, CancellationToken cancellationToken)
    {
        var mail = new Mail();

        // todo: smtp logic
        _smtpService.SendMessage();

        await _mailRepository.SaveMailAsync(mail, cancellationToken);

        return mail;
    }

    /// <inheritdoc />
    public IEnumerable<Mail> GetAllMails()
    {
        // todo: redis cache

        return _mailRepository.GetAllMails();
    }
}