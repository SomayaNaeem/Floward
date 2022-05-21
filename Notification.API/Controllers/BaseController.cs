using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Notification.API.Controllers
{
    [Route("api/Notification/[controller]")]
    public class BaseController : ControllerBase
    {
        private readonly IMediator _mediator;
        protected IMediator Mediator => _mediator ?? HttpContext.RequestServices.GetService<IMediator>();
    }
}