using EcommerceApp.Models;
using MediatR;

namespace EcommerceApp.Queries
{
    /// <summary>
    /// CartItemQuery is used to retrieve a list of cart items.
    /// This query expects to return a result of type `List CartItemModel`.
    /// </summary>
    public class CartItemQuery : IRequest<List<CartItemModel>>
    {
    }
}