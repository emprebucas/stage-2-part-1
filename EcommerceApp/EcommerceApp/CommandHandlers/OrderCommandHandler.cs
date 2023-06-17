using AutoMapper;
using EcommerceApp.Commands;
using EcommerceApp.Entities;
using EcommerceApp.Interfaces;
using EcommerceApp.Models;
using MediatR;

namespace EcommerceApp.CommandHandlers
{
    /// <summary>
    /// OrderCommandHandler handles the `UpdateOrderCommand`, `CheckoutOrderCommand`, and `DeleteOrderCommand` commands.
    /// </summary>
    public class OrderCommandHandler :
        IRequestHandler<UpdateOrderCommand, Unit>,
        IRequestHandler<CheckoutOrderCommand, Unit>,
        IRequestHandler<DeleteOrderCommand, Unit>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// The constructor takes the `IOrderRepository` and `IMapper`.
        /// `IOrderRepository`: an interface that represents the Order repository responsible for accessing order related data.
        /// `IMapper`:  an interface from AutoMapper for object mapping.
        /// </summary>
        /// <param name="orderRepository"></param>
        /// <param name="mapper"></param>
        public OrderCommandHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// The `Handle` method uses an instance of the mapper interface to map `OrderDto` User from the command to a `OrderModel` object.
        /// The `Handle` method uses an instance of the order interface to call `UpdateOrderAsync` and pass the mapped Order from the command.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Unit> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = _mapper.Map<OrderEntity>(request.Order);

            await _orderRepository.UpdateOrderAsync(order);
            return Unit.Value;
        }

        /// <summary>
        /// The `Handle` method uses an instance of the mapper interface to map `OrderDto` User from the command to a `OrderModel` object.
        /// The `Handle` method uses an instance of the order interface to call `CheckoutOrderAsync` and pass the mapped Order from the command.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Unit> Handle(CheckoutOrderCommand request, CancellationToken cancellationToken)
        {
            var order = _mapper.Map<OrderEntity>(request.Order);

            await _orderRepository.CheckoutOrderAsync(order);
            return Unit.Value;
        }

        /// <summary>
        /// The `Handle` method uses an instance of the order interface to call `DeleteOrderAsync` and pass the `OrderId` from the command.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Unit> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            await _orderRepository.DeleteOrderAsync(request.OrderId);
            return Unit.Value;
        }
    }
}
