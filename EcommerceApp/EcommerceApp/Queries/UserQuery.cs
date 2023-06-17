using EcommerceApp.Models;
using MediatR;

namespace EcommerceApp.Queries
{
    /// <summary>
    /// GetUserByIdQuery is used to retrieve a user by their ID.
    /// This query expects to return a result of type `UserModel`.
    /// </summary>
    public class GetUserByIdQuery : IRequest<UserModel>
    {
        /// <summary>
        /// Property `UserId` of type `Guid` which represents the unique identifier of the user that needs to be retrieved.
        /// </summary>
        public Guid UserId { get; set; }
    }
}
