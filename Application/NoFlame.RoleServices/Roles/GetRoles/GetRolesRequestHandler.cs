using MediatR;
using NoFlame.Domain.Repository;
using NoFlame.Domain.UserAggregate;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NoFlame.RoleServices.Roles.GetRoles
{
    public class GetRolesRequestHandler : IRequestHandler<GetRolesRequest, List<Role>>
    {
        private IRoleRepository _roleRepository;

        public GetRolesRequestHandler(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }
        public async Task<List<Role>> Handle(GetRolesRequest request, CancellationToken cancellationToken)
        {
            return await _roleRepository.GetRoles();
        }
    }
}
