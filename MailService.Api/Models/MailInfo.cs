using System.Text.Json.Serialization;
using MailService.Domain.Models;

namespace MailService.Api.Models;

public class MailInfo
{
    /// <summary>
    /// Дата создания сообщения
    /// </summary>
    [JsonPropertyName("creationDate")]
    public DateTime CreationDate { get; init; }

    /// <summary>
    /// Результат
    /// </summary>
    [JsonPropertyName("result")]
    public SendResult Result { get; init; }

    /// <summary>
    /// Текст ошибки
    /// </summary>
    [JsonPropertyName("error")]
    public string? Error { get; init; }
}