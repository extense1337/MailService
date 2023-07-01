namespace MailService.Domain.Models;

/// <summary>
/// Результат отправки
/// </summary>
public enum SendResult : byte
{
    Failed = 0,
    OK = 1
}

/// <summary>
/// Сообщение
/// </summary>
public class Mail
{
    /// <summary>
    /// Конверт сообщения
    /// </summary>
    public MailEnvelope MailEnvelope { get; set; }

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