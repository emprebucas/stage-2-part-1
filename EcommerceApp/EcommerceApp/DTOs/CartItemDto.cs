using System.Xml.Linq;

namespace EcommerceApp.DTOs
{
    /// <summary>
    /// CartItemDto represents a Data Transfer Object (DTO) for a cart item. 
    /// It contains properties that are used for transferring cart item data between different layers or components of the application.
    /// </summary>
    public class CartItemDto
    {
        /// <summary>
        /// CartItemId represents the unique identifier for the cart item.
        /// </summary>
        public Guid CartItemId { get; set; }

        /// <summary>
        /// OrderId represents the identifier of the order associated with the cart item.
        /// </summary>
        public Guid OrderId { get; set; }

        /// <summary>
        /// UserId represents the identifier of the user associated with the cart item.
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Item represents the name of the cart item.
        /// </summary>
        public string? Item { get; set; }

        /// <summary>
        /// Price represents the price of the cart item.
        /// </summary>
        public int? Price { get; set; }
    }
}
