using MediatR;
using NoFlame.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NoFlame.UserServices.User.UserClaims
{
    public class SetUserRoleCommand : IRequest
    {
        public Guid UserId { get; set; }
        public List<Guid> RoleIds { get; set; }
    }
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
