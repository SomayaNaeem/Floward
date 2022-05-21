using EventBus.Events;

namespace Catalog.Application.IntegrationEvents
{
    public class SendEmailEvent : IntegrationEvent
    {
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}