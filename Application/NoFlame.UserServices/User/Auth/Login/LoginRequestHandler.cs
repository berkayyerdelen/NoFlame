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
using NoFlame.Shared;

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

            var user = await _userRepository.IsValidUserCredentials(request.UserName);
            if (user.Id==Guid.Empty)
                throw new Exception("User does not exist");
           var isPasswordValid= PasswordHelper.Check(user.Password, request.Password);
           if (isPasswordValid ==false)
           {
               throw new Exception("Password is not correct");
           }
            var roles = await _userRepository.GetUserRoles(user.Id);          
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, request.UserName),                             
            };
            roles.ForEach(role => { claims.Add(new Claim(ClaimTypes.Role, role)); });
           
            var jwtResult = await _jwtAuthManager.GenerateTokens(request.UserName, claims, DateTime.Now);

            return new LoginResult
            {
                UserName = request.UserName,
                Role = String.Join(",", roles.Select(x => x)),
                AccessToken = jwtResult.AccessToken,
                RefreshToken = jwtResult.RefreshToken.TokenString
            };
        }
    }
}
