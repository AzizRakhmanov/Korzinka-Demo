using Korzinka_Demo.Domain.Entities;
using Korzinka_Demo.Services.EmailService;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class MailController : ControllerBase
{
    private readonly IEmailInterface _mailService;
    //injecting the IMailService into the constructor
    public MailController(IEmailInterface _MailService)
    {
        _mailService = _MailService;
    }

    [HttpPost]
    [Route("SendMail")]
    public bool SendMail(MailData mailData)
    {
        return _mailService.SendMail(mailData);
    }
}