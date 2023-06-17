using Dapper;
using EcommerceApp.Data;
using EcommerceApp.Entities;
using EcommerceApp.Interfaces;
using EcommerceApp.Models;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using SendGrid.Helpers.Errors.Model;

namespace EcommerceApp.Repositories
{
    /// <summary>
    /// OrderRepository provides the implementation for retrieving, updating, checking out, and deleting orders.
    /// </summary>
    public class OrderRepository : IOrderRepository
    {
        private readonly ECommerceDbContext _dbContext;
        private readonly IConfiguration _configuration;
        private readonly HttpContextHelper _httpContextHelper;

        /// <summary>
        /// The constructor takes the `ECommerceDbContext`, `IConfiguration`, and `HttpContextHelper` objects.
        /// `ECommerceDbContext`: used to interact with the database using Entity Framework Core.
        /// `IConfiguration`: used to retrieve the datab2ase connection string.
        /// `HttpContextHelper`: used to retrieve 'x-user-id' in the request header.
        /// </summary>
        /// <param name="dbContext"></param>
        /// <param name="configuration"></param>
        /// <param name="httpContextHelper"></param>
        public OrderRepository(ECommerceDbContext dbContext, IConfiguration configuration, HttpContextHelper httpContextHelper)
        {
            _dbContext = dbContext;
            _configuration = configuration;
            _httpContextHelper = httpContextHelper;
        }

        /// <summary>
        /// GetAllOrdersAsync retrieves all orders for the current user.
        /// It uses Dapper to execute SQL query and return the orders.
        /// </summary>
        /// <returns></returns>
        public async Task<List<OrderModel>> GetAllOrdersAsync()
        {
            var userId = _httpContextHelper.GetUserId();

            var connectionString = _configuration.GetConnectionString("ECommerceDb");
            using var connection = new MySqlConnection(connectionString);

            var query = "SELECT * FROM Orders  WHERE UserId = @UserId";
            var orders = await connection.QueryAsync<OrderModel>(query, new { UserId = userId });

            if (orders != null)
            {
                if (orders.Any())
                {
                    return orders.AsList();
                }
            }
            throw new BadRequestException("User does not have any order.");
        }

        /// <summary>
        /// GetOrderByIdAsync retrieves an order by their ID from the database. 
        /// It uses Dapper to execute the SQL query and returns the retrieved order.
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        /// <exception cref="BadRequestException"></exception>
        public async Task<OrderModel> GetOrderByIdAsync(Guid orderId)
        {
            var connectionString = _configuration.GetConnectionString("ECommerceDb");
            using var connection = new MySqlConnection(connectionString);

            var query = "SELECT * FROM Orders WHERE OrderId = @OrderId";
            var orders = await connection.QueryAsync<OrderModel>(query, new { OrderId = orderId });
            var order = orders.FirstOrDefault();

            if (order == null)
            {
                throw new BadRequestException("Order does not exist.");
            }

            return order;
        }

        /// <summary>
        /// UpdateOrderAsync uses Entity Framework Core to update an order.
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        /// <exception cref="BadRequestException"></exception>
        public async Task UpdateOrderAsync(OrderEntity order)
        {
            var userExists = await _dbContext.Users.AnyAsync(u => u.UserId == order.UserId);

            if (!userExists)
            {
                throw new BadRequestException("Cannot update order. User does not exist.");
            }

            var orderExists = await _dbContext.Orders.AnyAsync(o => o.OrderId == order.OrderId && o.UserId == order.UserId);

            if (!orderExists)
            {
                throw new BadRequestException("Cannot update order. Order does not exist for this user.");
            }

            var isPendingOrder = await _dbContext.Orders.AnyAsync(o => o.OrderId == order.OrderId && o.Status == OrderStatusEntity.Pending);

            if (!isPendingOrder)
            {
                throw new BadRequestException("Cannot update order. Order is already processed or cancelled.");
            }

            order.Status = OrderStatusEntity.Cancelled;

            _dbContext.Orders.Update(order);
            await _dbContext.SaveChangesAsync();

        }

        /// <summary>
        /// CheckoutOrderAsync uses Entity Framework Core to checkout an order.
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        /// <exception cref="BadRequestException"></exception>
        public async Task CheckoutOrderAsync(OrderEntity order)
        {
            var userExists = await _dbContext.Users.AnyAsync(u => u.UserId == order.UserId);

            if (!userExists)
            {
                throw new BadRequestException("Cannot checkout order. User does not exist.");
            }

            var orderExists = await _dbContext.Orders.AnyAsync(o => o.UserId == order.UserId && o.OrderId == order.OrderId);

            if (!orderExists)
            {
                throw new BadRequestException("Cannot checkout order. Order does not exist for this user.");
            }

            var userHasPendingOrder = await _dbContext.Orders.AnyAsync(o => o.OrderId == order.OrderId && o.Status == OrderStatusEntity.Pending);

            if (!userHasPendingOrder)
            {
                throw new BadRequestException("Cannot checkout order. Order is already either processed or cancelled.");
            }

            var orderHasCartItems = await _dbContext.CartItems.AnyAsync(c => c.OrderId == order.OrderId);

            if (!orderHasCartItems)
            {
                throw new BadRequestException("Cannot checkout order. Order has no cart items.");
            }

            // If the user exists, has a pending order with cart items, they can checkout.
            order.Status = OrderStatusEntity.Processed;

            _dbContext.Orders.Update(order);
            await _dbContext.SaveChangesAsync();
         
        }

        /// <summary>
        /// DeleteOrderAsync uses Entity Framework Core to delete an order.
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public async Task DeleteOrderAsync(Guid orderId)
        {
            var order = await _dbContext.Orders.FindAsync(orderId);

            if (order == null)
            {
                throw new BadRequestException("Cannot delete order. Order does not exist.");
            }

            _dbContext.Orders.Remove(order);
            await _dbContext.SaveChangesAsync();

        }

    }

}
