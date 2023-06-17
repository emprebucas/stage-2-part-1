using EcommerceApp.Interfaces;
using EcommerceApp.Models;
using EcommerceApp.Queries;
using MediatR;

namespace EcommerceApp.QueryHandlers
{
    /// <summary>
    /// UserQueryHandler handles the `GetUserByIdQuery` query and retrieves a user by 
    /// interacting with the User repository through the interface IUserRepository.
    /// </summary>
    public class UserQueryHandler : IRequestHandler<GetUserByIdQuery, UserModel>
    {
        private readonly IUserRepository _userRepository;

        /// <summary>
        /// The constructor takes the `IUserRepository` which is an interface that 
        /// represents the User repository responsible for accessing user related data.
        /// </summary>
        /// <param name="userRepository"></param>
        public UserQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        /// <summary>
        /// The `Handle` method uses an instance of the user interface to call `GetUserByIdAsync` and pass the `UserId` from the query.
        /// It returns a `Task User Model` which is an asynchronous operation to retrieve a user.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<UserModel> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            return await _userRepository.GetUserByIdAsync(request.UserId);
        }
    }
}
