using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoFlame.UserServices.User.Auth.RefreshToken
{
    public class RefreshTokenRequest:IRequest<LoginResult>
    {
        public string RefreshToken { get; set; }
        public string UserName { get; set; }
        public string AccessToken { get; set; }
        public RefreshTokenRequest(string refreshToken, string userName, string accessToken)
        {
            RefreshToken = refreshToken;
            UserName = userName;
            AccessToken = accessToken;
        }
    }
}
