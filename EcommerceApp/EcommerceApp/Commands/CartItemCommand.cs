using EcommerceApp.DTOs;
using MediatR;

namespace EcommerceApp.Commands
{
    /// <summary>
    /// AddCartItemCommand is used to request the addition of a cart item.
    /// </summary>
    public class AddCartItemCommand : IRequest<Unit>
    {
        /// <summary>
        /// Property `CartItem` of type `CartItemDto` which contains information about the cart item to be added.
        /// </summary>
        public CartItemDto? CartItem { get; set; }
    }

    /// <summary>
    /// UpdateCartItemCommand is used to request an update to a cart item.
    /// </summary>
    public class UpdateCartItemCommand : IRequest<Unit>
    {
        /// <summary>
        /// Property `CartItem` of type `CartItemDto` which contains updated information for the cart item.
        /// </summary>
        public CartItemDto? CartItem { get; set; }
    }

    /// <summary>
    /// DeleteCartItemCommand is used to request the deletion of a cart item.
    /// </summary>
    public class DeleteCartItemCommand : IRequest<Unit>
    {
        /// <summary>
        /// Property `CartItemId` of type `Guid` which represents the unique identifier of the cart item to be deleted.
        /// </summary>
        public Guid CartItemId { get; set; }
    }
}