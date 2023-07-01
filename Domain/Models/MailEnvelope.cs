namespace Domain.Models;

/// <summary>
/// Конверт сообщения
/// </summary>
public class MailEnvelope
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
    /// Адрессаты
    /// </summary>
    public ICollection<string> Recipients { get; set; }
}
