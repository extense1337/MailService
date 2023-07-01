using MailService.Domain.Models;

namespace MailService.Database;

public class MailEntity
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public int Id { get; set; }

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
    public string Recipients { get; set; }

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