using Microsoft.AspNetCore.Mvc;
using Notification.Application.Features.Notifications.Commands.SendEmail;

namespace Notification.API.Controllers
{
    [ApiController]
    public class NotificationsController : BaseController
    {
        [HttpPost("SendEmail")]
        public async Task<IActionResult> SendEmail([FromBody] SendEmailCommand command)
        {
            try
            {
                var output = await Mediator.Send(command);

                return Ok(output);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}