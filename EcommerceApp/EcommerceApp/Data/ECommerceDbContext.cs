using EcommerceApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApp.Data
{
    /// <summary>
    /// A database context for the e-Commerce website that
    /// provides access to the Orders, CartItems, and Users tables.
    /// </summary>
    public class ECommerceDbContext : DbContext
    {
        /// <summary>
        /// Constructor that configure various options for the database context, 
        /// such as the connection string and database provider.
        /// </summary>
        /// <param name="options"></param>
        // constructor
        public ECommerceDbContext(DbContextOptions<ECommerceDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Represents the Orders table in the database.
        /// Provides a collection of orders from the Orders table that can be queried and manipulated in the database.
        /// </summary>
        public DbSet<OrderEntity> Orders { get; set; }

        /// <summary>
        /// Represents the CartItems table in the database.
        /// Provides a collection of cart items from the CartItems table that can be queried and manipulated in the database.
        /// </summary>
        public DbSet<CartItemEntity> CartItems { get; set; }

        /// <summary>
        /// Represents the Users table in the database.
        /// Provides a collection of users from the Users table that can be queried and manipulated in the database.
        /// </summary>
        public DbSet<UserEntity> Users { get; set; }

    }
}