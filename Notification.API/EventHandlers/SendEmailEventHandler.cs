using AutoMapper;
using EventBus.Abstractions;
using MediatR;
using Notification.Application.Common.Events;
using Notification.Application.Features.Notifications.Commands.SendEmail;

namespace Notification.API.EventHandlers
{
    public class SendEmailEventHandler : IIntegrationEventHandler<SendEmailEvent>
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ILogger<SendEmailEventHandler> _logger;

        public SendEmailEventHandler(IMediator mediator, IMapper mapper, ILogger<SendEmailEventHandler> logger)
        {
            _mediator = mediator;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task Handle(SendEmailEvent @event)
        {
            try
            {
                var command = _mapper.Map<SendEmailCommand>(@event);

                await _mediator.Send(command);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message, new object(), ex);
                throw;
            }
        }
    }
}