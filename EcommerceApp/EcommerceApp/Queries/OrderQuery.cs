using EcommerceApp.Models;
using MediatR;

namespace EcommerceApp.Queries
{
    /// <summary>
    /// GetAllOrdersQuery is used to retrieve a list of orders.
    /// This query expects to return a result of type `List OrderModel`.
    /// </summary>
    public class GetAllOrdersQuery : IRequest<List<OrderModel>>
    {
    }

    /// <summary>
    /// GetOrderByIdQuery is used to retrieve a order by its ID.
    /// This query expects to return a result of type `OrderModel`.
    /// </summary>
    public class GetOrderByIdQuery : IRequest<OrderModel>
    {
        /// <summary>
        /// Property `OrderId` of type `Guid` which represents the unique identifier of the order that needs to be retrieved.
        /// </summary>
        public Guid OrderId { get; set; }
    }
}
