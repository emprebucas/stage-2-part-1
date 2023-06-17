using EcommerceApp.Interfaces;
using EcommerceApp.Models;
using EcommerceApp.Queries;
using MediatR;

namespace EcommerceApp.QueryHandlers
{
    /// <summary>
    /// CartItemQueryHandler handles the `CartItemQuery` query and retrieves a list of cart items by
    /// interacting with the Cart Item repository through the interface ICartItemRepository.
    /// </summary>
    public class CartItemQueryHandler : IRequestHandler<CartItemQuery, List<CartItemModel>>
    {
        private readonly ICartItemRepository _cartItemRepository;

        /// <summary>
        /// The constructor takes the `ICartItemRepository` which is an interface that 
        /// represents the Cart Item repository responsible for accessing cart item related data.
        /// </summary>
        /// <param name="cartItemRepository"></param>
        public CartItemQueryHandler(ICartItemRepository cartItemRepository)
        {
            _cartItemRepository = cartItemRepository;
        }

        /// <summary>
        /// The `Handle` method uses an instance of the cart item interface to call `GetAllCartItemsAsync`.
        /// It returns a `Task List CartItemModel` which is an asynchronous operation to retrieve a list of cart items.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<List<CartItemModel>> Handle(CartItemQuery request, CancellationToken cancellationToken)
        {
            return await _cartItemRepository.GetAllCartItemsAsync();
        }
    }
}
