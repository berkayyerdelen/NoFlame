using System;

namespace NoFlame.Infrastructure.Repository.Authentication
{
    public class RefreshToken
    {
      
        public string UserName { get; set; }            
        public string TokenString { get; set; }    
        public DateTime ExpireAt { get; set; }
    }
}
