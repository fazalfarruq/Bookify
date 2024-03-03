using Bookify.Domain.User;

namespace Bookify.Application.Abstractions.Email;

public interface IEmailService
{
    Task SendAsync(Domain.User.Email email, string subject, string body);
}