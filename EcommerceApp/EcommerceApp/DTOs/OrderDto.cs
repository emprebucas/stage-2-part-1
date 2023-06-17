using EcommerceApp.Models;

namespace EcommerceApp.DTOs
{
    /// <summary>
    /// OrderDto represents a Data Transfer Object (DTO) for an order. 
    /// It contains properties that are used for transferring order data between different layers or components of the application.
    /// </summary>
    public class OrderDto
    {
        /// <summary>
        /// OrderId represents the unique identifier for the order.
        /// </summary>
        public Guid OrderId { get; set; }

        /// <summary>
        ///  UserId represents the identifier of the user associated with the order.
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Status represents the status of the order.
        /// </summary>
        public OrderStatusModel Status { get; set; }
    }
}
