using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceApp.Entities
{
    /// <summary>
    /// The OrderEntity represents a real world order and defines the properties and 
    /// attributes associated with an order, such as the order's ID, the user ID that owns the order,
    /// and the order's status.
    /// </summary>
    public class OrderEntity
    {
        /// <summary>
        /// The OrderId, a primary key in GUID.
        /// </summary>
        [Key]
        public Guid OrderId { get; set; }

        /// <summary>
        /// Defining the User entity as a foreign key to 
        /// establish the relationship between User and Order.
        /// </summary>
        [ForeignKey("User")]
        public Guid UserId { get; set; }

        /// <summary>
        /// The status of an order which can be Pending, Processed, Cancelled.
        /// </summary>
        public OrderStatusEntity Status { get; set; }
    }
}
