using EcommerceApp.Interfaces;
using EcommerceApp.Models;
using EcommerceApp.Queries;
using MediatR;

namespace EcommerceApp.QueryHandlers
{
    /// <summary>
    /// OrderQueryHandler handles the `GetAllOrdersQuery` and `GetOrderByIdQuery` queries.
    /// </summary>
    public class OrderQueryHandler : 
        IRequestHandler<GetAllOrdersQuery, List<OrderModel>>,
        IRequestHandler<GetOrderByIdQuery, OrderModel>
    {
        private readonly IOrderRepository _orderRepository;

        /// <summary>
        /// The constructor takes the `IOrderRepository` which is an interface that 
        /// represents the Order repository responsible for accessing order related data.
        /// </summary>
        /// <param name="orderRepository"></param>
        public OrderQueryHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        /// <summary>
        /// The `Handle` method uses an instance of the order interface to call `GetAllOrdersAsync`.
        /// It returns a `Task List OrderModel` which is an asynchronous operation to retrieve a list of orders.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<List<OrderModel>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            return await _orderRepository.GetAllOrdersAsync();
        }

        /// <summary>
        /// The `Handle` method uses an instance of the order interface to call `GetOrderByIdAsync` and pass the `OrderId` from the query.
        /// It returns a `Task Order Model` which is an asynchronous operation to retrieve a order.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<OrderModel> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            return await _orderRepository.GetOrderByIdAsync(request.OrderId);
        }
    }
}
