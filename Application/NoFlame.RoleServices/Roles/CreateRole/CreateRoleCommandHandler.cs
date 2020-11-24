using MediatR;
using NoFlame.Domain.Repository;
using System.Threading;
using System.Threading.Tasks;

namespace NoFlame.RoleServices.Roles.CreateRole
{
    public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand>
    {
        private IRoleRepository _roleRepository;

        public CreateRoleCommandHandler(IRoleRepository roleRepository )
        {
            _roleRepository = roleRepository;
        }
        public async Task<Unit> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            await _roleRepository.CreateRole(request.Name);
            return Unit.Value;
        }
    }
}
