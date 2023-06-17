using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceApp.Entities
{
    /// <summary>
    /// The CartItemEntity represents a real world cart item and defines the properties and 
    /// attributes associated with a cart item, such as the item's ID, the order ID containing the item,
    /// the user ID that owns the order containing the item, the item's name and price.
    /// </summary>
    public class CartItemEntity
    {
        /// <summary>
        /// The CartItemId, a primary key in GUID.
        /// </summary>
        [Key]
        public Guid CartItemId { get; set; }

        /// <summary>
        /// Defining the Order entity as a foreign key to 
        /// establish the relationship between Order and CartItem.
        /// </summary>
        [ForeignKey("Order")]
        public Guid OrderId { get; set; }

        /// <summary>
        /// Defining the User entity as a foreign key to 
        /// establish the relationship between User and CartItem.
        /// </summary>
        [ForeignKey("User")]
        public Guid UserId { get; set; }

        /// <summary>
        /// The cart item's name in string.
        /// </summary>
        public string? Item { get; set; }

        /// <summary>
        /// The cart item's price in int.
        /// </summary>
        public int? Price { get; set; }
    }
}
