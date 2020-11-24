using MediatR;
using NoFlame.Domain.Repository;
using NoFlame.Infrastructure.Repository.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NoFlame.UserServices.User.Auth.Login
{
    public class LoginRequestHandler : IRequestHandler<LoginRequest, LoginResult>
    {
        public IUserRepository _userRepository { get; }
        private IJwtAuthManager _jwtAuthManager { get; }
        public LoginRequestHandler(IUserRepository userRepository, IJwtAuthManager jwtAuthManager)
        {
            _userRepository = userRepository;
            _jwtAuthManager = jwtAuthManager;
        }

       
        public async Task<LoginResult> Handle(LoginRequest request, CancellationToken cancellationToken)
        {
            var IsValid = await _userRepository.IsValidUserCredentials(request.UserName, request.Password);
            if (!IsValid)
                throw new Exception("User does not exist");
            var roles = await _userRepository.GetUserRoles(request.UserName);          
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, request.UserName),                             
            };
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role.Name));                
            }
            var jwtResult = _jwtAuthManager.GenerateTokens(request.UserName, claims, DateTime.Now);

            return new LoginResult
            {
                UserName = request.UserName,
                Role = String.Join(",", roles.Select(x => x.Name)),
                AccessToken = jwtResult.AccessToken,
                RefreshToken = jwtResult.RefreshToken.TokenString
            };
        }
    }
}
