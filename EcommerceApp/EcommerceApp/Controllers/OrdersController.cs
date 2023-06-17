using EcommerceApp.Commands;
using EcommerceApp.DTOs;
using EcommerceApp.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SendGrid.Helpers.Errors.Model;

namespace EcommerceApp.Controllers
{
    /// <summary>
    /// OrdersController handles order-related operations. 
    /// It uses the MediatR library for handling commands and queries.
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("orders")]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// The constructor takes `IMediator` which allows the controller to use MediatR for handling commands and queries.
        /// </summary>
        /// <param name="mediator"></param>
        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// HTTP GET endpoint that retrieves all the orders of a user.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> GetAllOrders()
        {
            var query = new GetAllOrdersQuery();

            try
            {
                var orders = await _mediator.Send(query);

                return Ok(orders);
            }
            catch (BadRequestException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// HTTP GET endpoint that retrieves an order by its orderId.
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        [HttpGet("{orderId}")]
        public async Task<ActionResult> GetOrderById(Guid orderId)
        {
            var query = new GetOrderByIdQuery { OrderId = orderId };

            try
            {
                var order = await _mediator.Send(query);

                if (order == null)
                {
                    return NotFound();
                }
                return Ok(order);
            }
            catch (BadRequestException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// HTTP PUT endpoint for updating an order.
        /// </summary>
        /// <param name="orderDto"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult> UpdateOrder(OrderDto orderDto)
        {
            var command = new UpdateOrderCommand { Order = orderDto };

            try
            {
                await _mediator.Send(command);
                return Ok("Order updated successfully.");
            }
            catch (BadRequestException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// HTTP DELETE endpoint for deleting an order by its orderId.
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        [HttpDelete("{orderId}")]
        public async Task<ActionResult> DeleteOrder(Guid orderId)
        {
            var command = new DeleteOrderCommand { OrderId = orderId };

            try
            {
                await _mediator.Send(command);
                return Ok("Order deleted successfully.");
            }
            catch (BadRequestException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
