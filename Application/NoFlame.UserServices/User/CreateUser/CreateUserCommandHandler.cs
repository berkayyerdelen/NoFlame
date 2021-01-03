using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NoFlame.Domain.Repository;
using NoFlame.Shared;


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
            var password =PasswordHelper.Hash(request.Password);
            var user = Domain.UserAggregate.User.CreateUser( request.FirstName, request.LastName,
                         request.LoginName, password, request.Email, request.IsActive);
            await _userRepository.InsertUser(user);
            return Unit.Value;
        }
    }
}