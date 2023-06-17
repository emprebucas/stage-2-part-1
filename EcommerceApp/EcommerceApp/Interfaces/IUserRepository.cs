using EcommerceApp.Entities;
using EcommerceApp.Models;

namespace EcommerceApp.Interfaces
{
    /// <summary>
    /// IUserRepository defines the contract for the User repository.
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// GetUserByIdAsync is used to retrieve a user by their ID. 
        /// It takes a `Guid` parameter `userId` representing the unique identifier of the user to be retrieved. 
        /// The method returns a `Task UserModel` representing the asynchronous operation of retrieving the user.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<UserModel> GetUserByIdAsync(Guid userId);

        /// <summary>
        /// AddUserAsync is used to add a user. 
        /// It takes a `UserEntity` object as a parameter, representing the user to be added. 
        /// The method returns a `Task` representing the asynchronous operation of adding the user.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task AddUserAsync(UserEntity user);
    }
}