using MailService.Domain.Models;
using MailService.Domain.Services;
using MailService.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace MailService.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MailsController : ControllerBase
{
    private readonly IMailService _mailService;

    public MailsController(IMailService mailService)
    {
        _mailService = mailService;
    }

    /// <summary>
    /// Отправить сообщение
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> SendMail(MailEnvelope mailEnvelope, CancellationToken cancellationToken = default)
    {
        var createdMail = await _mailService.SendMailAsync(mailEnvelope, cancellationToken);

        var mailInfo = new MailInfo
        {
            CreationDate = createdMail.CreationDate,
            Result = createdMail.Result,
            Error = createdMail.FailedMessage
        };

        var statusCode = mailInfo.Result switch
        {
            SendResult.Failed => StatusCodes.Status404NotFound,
            SendResult.OK => StatusCodes.Status201Created,
            _ => StatusCodes.Status500InternalServerError
        };

        return StatusCode(statusCode, mailInfo);
    }

    /// <summary>
    /// Получить все сообщения
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public IEnumerable<Mail> GetAllMails()
    {
        return _mailService.GetAllMails();
    }
}