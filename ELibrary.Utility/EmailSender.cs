using Microsoft.AspNetCore.Identity.UI.Services;

namespace ELibrary.Utility;

public class EmailSender : IEmailSender
{
    public Task SendEmailAsync(string email, string subject, string htmlMessage)
    {
        // Todo
        return Task.CompletedTask;
    }
}