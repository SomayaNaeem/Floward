using MediatR;
using Notification.Application.Common.Interfaces;

namespace Notification.Application.Features.Notifications.Commands.SendEmail
{
    public class SendEmailCommand : IRequest<bool>
    {
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }

    public class SendEmailCommandHandler : IRequestHandler<SendEmailCommand, bool>
    {
        private readonly IEmailService _notificationsService;

        public SendEmailCommandHandler(IEmailService notificationsService)
        {
            _notificationsService = notificationsService;
        }

        public async Task<bool> Handle(SendEmailCommand request, CancellationToken cancellationToken)
        {
            await _notificationsService.SendEmailAsync(request.Email, request.Subject, request.Message);

            return true;
        }
    }
}