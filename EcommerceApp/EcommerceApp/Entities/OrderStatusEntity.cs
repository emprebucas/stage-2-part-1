namespace EcommerceApp.Entities
{
    /// <summary>
    /// An enum to define the possible values for the order status
    /// which can be Pending, Processed, Cancelled.
    /// </summary>
    public enum OrderStatusEntity
    {
        /// <summary>
        /// Represents the status of an order when it is awaiting processing.
        /// </summary>
        Pending,

        /// <summary>
        /// Represents the status of an order when it has been successfully processed.
        /// </summary>
        Processed,

        /// <summary>
        /// Represents the status of an order when it has been cancelled.
        /// </summary>
        Cancelled
    }
}
