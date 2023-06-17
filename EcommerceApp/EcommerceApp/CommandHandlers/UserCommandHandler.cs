using AutoMapper;
using EcommerceApp.Commands;
using EcommerceApp.Entities;
using EcommerceApp.Interfaces;
using EcommerceApp.Models;
using MediatR;

namespace EcommerceApp.CommandHandlers
{
    /// <summary>
    /// UserCommandHandler handles the `AddUserCommand` command and adds a user to a repository.
    /// </summary>
    public class UserCommandHandler : IRequestHandler <AddUserCommand, Unit>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// The constructor takes the `IUserRepository` and `IMapper`.
        /// `IUserRepositroy`: an interface that represents the User repository responsible for accessing user related data.
        /// `IMapper`:  an interface from AutoMapper for object mapping.
        /// </summary>
        /// <param name="userRepository"></param>
        /// <param name="mapper"></param>
        public UserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// The `Handle` method uses an instance of the mapper interface to map `UserDto` User from the command to a `UserModel` object.
        /// The `Handle` method uses an instance of the user interface to call `AddUserAsync` and pass the mapped User from the command.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Unit> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<UserEntity>(request.User);

            await _userRepository.AddUserAsync(user);
            return Unit.Value;
        }
    }
}
