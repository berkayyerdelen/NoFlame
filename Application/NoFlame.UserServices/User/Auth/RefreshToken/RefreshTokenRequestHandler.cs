using MediatR;
using Microsoft.AspNetCore.Http;
using NoFlame.Infrastructure.Repository.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NoFlame.UserServices.User.Auth.RefreshToken
{
    public class RefreshTokenRequestHandler : IRequestHandler<RefreshTokenRequest, LoginResult>
    {
        private IJwtAuthManager _jwtAuthManager;
        private IHttpContextAccessor _httpContextAccessor;

        public RefreshTokenRequestHandler(IJwtAuthManager jwtAuthManager, IHttpContextAccessor httpContextAccessor)
        {
            _jwtAuthManager = jwtAuthManager;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<LoginResult> Handle(RefreshTokenRequest request, CancellationToken cancellationToken)
        {
            var jwtResult = await _jwtAuthManager.Refresh(request.RefreshToken, request.AccessToken, DateTime.UtcNow);
            return (new LoginResult()
            {
                AccessToken = jwtResult.AccessToken,
                RefreshToken = jwtResult.RefreshToken.TokenString,
                UserName = request.UserName,
                Role= _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Role)?.Value ?? string.Empty
            });
        }
    }
}
