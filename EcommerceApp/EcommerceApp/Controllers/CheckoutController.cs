using EcommerceApp.Commands;
using EcommerceApp.DTOs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SendGrid.Helpers.Errors.Model;

namespace EcommerceApp.Controllers
{
    /// <summary>
    /// CheckoutController handles the checkout operation. 
    /// It uses the MediatR library for handling commands and queries.
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("checkout")]
    public class CheckoutController : ControllerBase
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// The constructor takes `IMediator` which allows the controller to use MediatR for handling commands and queries.
        /// </summary>
        /// <param name="mediator"></param>
        public CheckoutController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// HTTP POST endpoint for checking out an order.
        /// </summary>
        /// <param name="orderDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> CheckoutOrder(OrderDto orderDto)
        {
            var command = new CheckoutOrderCommand { Order = orderDto };

            try
            {
                await _mediator.Send(command);
                return Ok("Order checked out successfully.");
            }
            catch (BadRequestException ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
