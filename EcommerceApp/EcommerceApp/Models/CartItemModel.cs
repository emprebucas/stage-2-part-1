using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceApp.Models
{
    /// <summary>
    /// CartItemModel represents the model for a cart item.
    /// </summary>
    public class CartItemModel
    {
        /// <summary>
        /// CartItemId represents the unique identifier for the cart item.
        /// </summary>
        [Key]
        public Guid CartItemId { get; set; }

        /// <summary>
        /// OrderId represents the foreign key for the associated order.
        /// </summary>
        [ForeignKey("Order")]
        public Guid OrderId { get; set; }
        /// <summary>
        /// UserId represents the foreign key for the associated user.
        /// </summary>
        [ForeignKey("User")]
        public Guid UserId { get; set; }

        /// <summary>
        /// Item represents the name of the user.
        /// </summary>
        public string? Item { get; set; }
        /// <summary>
        /// Price represents the price of the user.
        /// </summary>
        public int? Price { get; set; }
    }
}
