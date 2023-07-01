namespace MailService.Api.Models;

/// <summary>
/// Настройки SMTP
/// </summary>
public class SmtpSettings
{
    public string Host { get; set; }
    public int Port { get; set; }
    public bool UseSsl { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string FromName { get; set; }
    public string FromAddress { get; set; }
}