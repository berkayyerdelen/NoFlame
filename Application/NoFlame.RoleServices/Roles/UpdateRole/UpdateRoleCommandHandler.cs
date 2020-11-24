using MediatR;
using NoFlame.Domain.Repository;
using System.Threading;
using System.Threading.Tasks;

namespace NoFlame.RoleServices.Roles.UpdateRole
{
    public class UpdateRoleCommandHandler : IRequestHandler<UpdateRoleCommand>
    {
        private IRoleRepository _roleRepository;

        public UpdateRoleCommandHandler(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }
        public async Task<Unit> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
        {
            await _roleRepository.UpdateRole(request.Id, request.Name);
            return Unit.Value;
        }
    }
}
