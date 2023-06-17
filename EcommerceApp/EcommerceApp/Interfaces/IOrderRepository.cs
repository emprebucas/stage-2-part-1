using EcommerceApp.Entities;
using EcommerceApp.Models;

namespace EcommerceApp.Interfaces
{
    /// <summary>
    /// IOrderRepository defines the contract for the Order repository.
    /// </summary>
    public interface IOrderRepository
    {
        /// <summary>
        /// GetAllOrdersAsync is used to retrieve all orders. 
        /// It returns a `Task List OrderModel` representing the asynchronous operation of retrieving all orders.
        /// </summary>
        /// <returns></returns>
        Task<List<OrderModel>> GetAllOrdersAsync();

        /// <summary>
        /// GetOrderByIdAsync is used to retrieve an order by its ID. 
        /// It takes a `Guid` parameter `orderId` representing the unique identifier of the order to be retrieved. 
        /// The method returns a `Task OrderModel` representing the asynchronous operation of retrieving the order.
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        Task<OrderModel> GetOrderByIdAsync(Guid orderId);

        /// <summary>
        /// UpdateOrderAsync is used to update an order. 
        /// It takes an `OrderModel` object `order` as a parameter, representing the order to be updated. 
        /// The method returns a `Task` representing the asynchronous operation of updating the order.
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        Task UpdateOrderAsync(OrderEntity order);

        /// <summary>
        /// CheckoutOrderAsync is used to perform the checkout process for an order. 
        /// It takes an `OrderModel` object `order` as a parameter, representing the order to be checked out. 
        /// The method returns a `Task` representing the asynchronous operation of checking out the order.
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        Task CheckoutOrderAsync(OrderEntity order);

        /// <summary>
        /// DeleteOrderAsync is used to delete an order. 
        /// It takes a `Guid` parameter `orderId` representing the unique identifier of the order to be deleted. 
        /// The method returns a `Task` representing the asynchronous operation of deleting the order.
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        Task DeleteOrderAsync(Guid orderId);
    }
}
