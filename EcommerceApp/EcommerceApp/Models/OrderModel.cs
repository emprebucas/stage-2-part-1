using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceApp.Models
{
    /// <summary>
    /// UserModel represents the model for an order.
    /// </summary>
    public class OrderModel
    {
        /// <summary>
        /// OrderId represents the unique identifier for the order.
        /// </summary>
        [Key]
        public Guid OrderId { get; set; }
        /// <summary>
        /// UserId represents the foreign key for the associated user.
        /// </summary>
        [ForeignKey("User")]
        public Guid UserId { get; set; }
        /// <summary>
        /// Status represents the status of the order.
        /// </summary>
        public OrderStatusModel Status { get; set; }
    }
}
