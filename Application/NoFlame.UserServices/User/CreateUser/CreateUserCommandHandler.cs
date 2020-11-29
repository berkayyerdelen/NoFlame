using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NoFlame.Domain.Repository;

namespace NoFlame.UserServices.User.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Unit>
    {
        private readonly IUserRepository _userRepository;

        public CreateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<Unit> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {

            var user = Domain.UserAggregate.User.CreateUser(Guid.NewGuid(), request.FirstName, request.LastName,
                         request.LoginName, request.Password, request.Email, request.IsActive);
            await _userRepository.InsertUser(user);
            return Unit.Value;
        }
    }
}