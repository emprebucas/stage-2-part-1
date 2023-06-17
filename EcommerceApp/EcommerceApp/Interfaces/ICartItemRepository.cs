using EcommerceApp.Entities;
using EcommerceApp.Models;

namespace EcommerceApp.Interfaces
{
    /// <summary>
    /// ICartItemRepository defines the contract for the Cart Iten repository.
    /// </summary>
    public interface ICartItemRepository
    {
        /// <summary>
        /// GetAllCartItemsAsync is used to retrieve all cart items. 
        /// It returns a `Task List CartItemModel` representing the asynchronous operation of retrieving all cart items.
        /// </summary>
        /// <returns></returns>
        Task<List<CartItemModel>> GetAllCartItemsAsync();

        /// <summary>
        /// AddCartItemAsync is used to add a cart item. 
        /// It takes a `CartItemModel` object `cartItem` as a parameter, representing the cart item to be added. 
        /// The method returns a `Task` representing the asynchronous operation of adding the cart item.
        /// </summary>
        /// <param name="cartItem"></param>
        /// <returns></returns>
        Task AddCartItemAsync(CartItemEntity cartItem);

        /// <summary>
        /// UpdateCartItemAsync is used to update a cart item. 
        /// It takes a `CartItemModel` object `cartItem` as a parameter, representing the cart item to be updated. 
        /// The method returns a `Task` representing the asynchronous operation of updating the cart item.
        /// </summary>
        /// <param name="cartItem"></param>
        /// <returns></returns>
        Task UpdateCartItemAsync(CartItemEntity cartItem);

        /// <summary>
        /// DeleteCartItemAsync is used to delete a cart item from the repository. 
        /// It takes a `Guid` parameter `cartItemId` representing the unique identifier of the cart item to be deleted. 
        /// The method returns a `Task` representing the asynchronous operation of deleting the cart item.
        /// </summary>
        /// <param name="cartItemId"></param>
        /// <returns></returns>
        Task DeleteCartItemAsync(Guid cartItemId);
    }
}
