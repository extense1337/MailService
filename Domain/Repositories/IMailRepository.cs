using Domain.Models;

namespace Domain.Repositories;

public interface IMailRepository
{
    /// <summary>
    /// Сохранить сообщение
    /// </summary>
    /// <param name="mail"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<int> SaveMailAsync(Mail mail, CancellationToken cancellationToken);

    /// <summary>
    /// Получить список всех сообщений
    /// </summary>
    /// <returns></returns>
    IEnumerable<Mail> GetAllMails();
}