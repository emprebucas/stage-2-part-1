using AutoMapper;
using EcommerceApp.Commands;
using EcommerceApp.Entities;
using EcommerceApp.Interfaces;
using EcommerceApp.Models;
using MediatR;

namespace EcommerceApp.CommandHandlers
{
    /// <summary>
    /// CartItemCommandHandler handles the `AddCartItemCommand`, `UpdateCartItemCommand`, and `DeleteCartItemCommand` commands.
    /// </summary>
    public class CartItemCommandHandler :
        IRequestHandler<AddCartItemCommand, Unit>,
        IRequestHandler<UpdateCartItemCommand, Unit>,
        IRequestHandler<DeleteCartItemCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly ICartItemRepository _cartItemRepository;

        /// <summary>
        /// The constructor takes the `ICartItemRepository` and `IMapper`.
        /// `ICartItemRepository`: an interface that represents the Cart Item repository responsible for accessing cart item related data.
        /// `IMapper`:  an interface from AutoMapper for object mapping.
        /// </summary>
        /// <param name="cartItemRepository"></param>
        /// <param name="mapper"></param>
        public CartItemCommandHandler(ICartItemRepository cartItemRepository, IMapper mapper)
        {
            _cartItemRepository = cartItemRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Unit> Handle(AddCartItemCommand request, CancellationToken cancellationToken)
        {
            var cartItem = _mapper.Map<CartItemEntity>(request.CartItem);

            await _cartItemRepository.AddCartItemAsync(cartItem);
            return Unit.Value;
        }

        /// <summary>
        /// The `Handle` method uses an instance of the mapper interface to map `CartItemDto` User from the command to a `CartItemModel` object.
        /// The `Handle` method uses an instance of the cart item interface to call `UpdateCartItemAsync` and pass the mapped User from the command.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Unit> Handle(UpdateCartItemCommand request, CancellationToken cancellationToken)
        {
            var cartItem = _mapper.Map<CartItemEntity>(request.CartItem);

            await _cartItemRepository.UpdateCartItemAsync(cartItem);
            return Unit.Value;
        }

        /// <summary>
        /// The `Handle` method uses an instance of the cart item interface to call `DeleteCartItemAsync` and pass the `CartItemId` from the command.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Unit> Handle(DeleteCartItemCommand request, CancellationToken cancellationToken)
        {
            await _cartItemRepository.DeleteCartItemAsync(request.CartItemId);
            return Unit.Value;
        }
    }
}
