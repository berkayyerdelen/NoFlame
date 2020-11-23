using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoFlame.UserServices.User.Auth.Login
{
    public class LoginRequest: IRequest<LoginResult>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
