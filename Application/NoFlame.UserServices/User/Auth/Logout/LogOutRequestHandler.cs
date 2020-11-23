using MediatR;
using NoFlame.Infrastructure.Repository.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NoFlame.UserServices.User.Auth.Logout
{
    public class LogOutRequestHandler : IRequestHandler<LogOutRequest>
    {
        public LogOutRequestHandler(IJwtAuthManager jwtAuthManager)
        {
            _jwtAuthManager = jwtAuthManager;
        }

        public IJwtAuthManager _jwtAuthManager { get; }

        public Task<Unit> Handle(LogOutRequest request, CancellationToken cancellationToken)
        {
            _jwtAuthManager.RemoveRefreshTokenByUserName(request.CurrentUserName);
            return Task.FromResult(Unit.Value);
        }
    }
}
