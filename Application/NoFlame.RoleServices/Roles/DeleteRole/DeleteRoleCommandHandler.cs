using MediatR;
using NoFlame.Domain.Repository;
using System.Threading;
using System.Threading.Tasks;

namespace NoFlame.RoleServices.Roles.DeleteRole
{
    public class DeleteRoleCommandHandler : IRequestHandler<DeleteRoleCommand>
    {
        private IRoleRepository _roleRepository;

        public DeleteRoleCommandHandler(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }
        public async Task<Unit> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
        {
            await _roleRepository.DeleteRole(request.Id);
            return Unit.Value;
        }
    }
}
