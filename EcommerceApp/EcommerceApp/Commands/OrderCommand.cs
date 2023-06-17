using EcommerceApp.DTOs;
using MediatR;

namespace EcommerceApp.Commands
{
    /// <summary>
    /// UpdateOrderCommand is used to request an update to an order.
    /// </summary>
    public class UpdateOrderCommand : IRequest<Unit>
    {
        /// <summary>
        /// Property `Order` of type `OrderDto` which contains updated information for the order.
        /// </summary>
        public OrderDto? Order { get; set; }
    }

    /// <summary>
    /// CheckoutOrderCommand is used to request the checkout of an order.
    /// </summary>
    public class CheckoutOrderCommand : IRequest<Unit>
    {
        /// <summary>
        /// Property `Order` of type `OrderDto` which contains the order information to be checked out.
        /// </summary>
        public OrderDto? Order { get; set; }
    }

    /// <summary>
    /// DeleteOrderCommand is used to request the deletion of an order.
    /// </summary>
    public class DeleteOrderCommand : IRequest<Unit>
    {
        /// <summary>
        /// Property `OrderId` of type `Guid` which represents the unique identifier of the order to be deleted.
        /// </summary>
        public Guid OrderId { get; set; }
    }
}