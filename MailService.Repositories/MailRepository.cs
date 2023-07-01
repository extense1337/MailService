using MailService.Database;
using MailService.Domain.Models;
using MailService.Domain.Repositories;

namespace MailService.Repositories;

/// <summary>
/// Репозиторий сообщений
/// </summary>
public class MailRepository : IMailRepository
{
    private readonly MailDbContext _dbContext;

    public MailRepository(MailDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <inheritdoc />
    public Task<int> SaveMailAsync(Mail mail, CancellationToken cancellationToken)
    {
        _dbContext.Mails.Add(new MailEntity
        {
            Subject = mail.MailEnvelope.Subject,
            Body = mail.MailEnvelope.Body,
            Recipients = string.Join("; ", mail.MailEnvelope.Recipients),
            CreationDate = mail.CreationDate,
            Result = mail.Result,
            FailedMessage = mail.FailedMessage
        });

        return _dbContext.SaveChangesAsync(cancellationToken);
    }

    /// <inheritdoc />
    public IEnumerable<Mail> GetAllMails()
    {
        return _dbContext.Mails.Select(mailEntity => new Mail
        {
            MailEnvelope = new MailEnvelope
            {
                Subject = mailEntity.Subject,
                Body = mailEntity.Body,
                Recipients = mailEntity.Recipients.Split(new[] {"; "}, StringSplitOptions.RemoveEmptyEntries).ToList()
            },
            CreationDate = mailEntity.CreationDate,
            Result = mailEntity.Result,
            FailedMessage = mailEntity.FailedMessage
        });
    }
}