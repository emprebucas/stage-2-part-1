using EcommerceApp.DTOs;
using MediatR;

namespace EcommerceApp.Commands
{
    /// <summary>
    /// AddUserCommand is used to request the addition of a user.
    /// </summary>
    public class AddUserCommand : IRequest<Unit>
    {
        /// <summary>
        /// Property `User` of type `UserDto` which contains information about the user to be added.
        /// </summary>
        public UserDto? User { get; set; }
    }
}
