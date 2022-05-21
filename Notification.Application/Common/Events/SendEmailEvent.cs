using EventBus.Events;

namespace Notification.Application.Common.Events
{
    public class SendEmailEvent : IntegrationEvent
    {
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}