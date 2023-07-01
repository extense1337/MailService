using MailService.Domain.Models;

namespace MailService.Database;

public class MailEntity
{
    /// <summary>
    /// Тема сообщения
    /// </summary>
    public string Subject { get; set; }

    /// <summary>
    /// Тело сообщения
    /// </summary>
    public string Body { get; set; }

    /// <summary>
    /// Адресаты
    /// </summary>
    public ICollection<string> Recipients { get; set; }

    /// <summary>
    /// Дата создания
    /// </summary>
    public DateTime CreationDate { get; set; }

    /// <summary>
    /// Результат отправки
    /// </summary>
    public SendResult Result { get; set; }

    /// <summary>
    /// Текст ошибки отправки
    /// </summary>
    public string? FailedMessage { get; set; }
}