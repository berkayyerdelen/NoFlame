﻿using MediatR;
using NoFlame.Domain.Repository;
using System.Threading;
using System.Threading.Tasks;

namespace NoFlame.UserServices.User.UserClaims
{
    public class SetUserRoleCommandHandler : IRequestHandler<SetUserRoleCommand>
    {
        private IUserRepository _userRepository;

        public SetUserRoleCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<Unit> Handle(SetUserRoleCommand request, CancellationToken cancellationToken)
        {
            await _userRepository.SetUserRole(request.UserId, request.RoleIds);
            return Unit.Value;
        }
    }
}
