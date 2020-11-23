using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoFlame.UserServices.User.Auth.Logout
{
    public class LogOutRequest: IRequest
    {
        public string CurrentUserName { get; set; }
        public LogOutRequest(string userName)
        {
            CurrentUserName = userName;
        }
    }
}
