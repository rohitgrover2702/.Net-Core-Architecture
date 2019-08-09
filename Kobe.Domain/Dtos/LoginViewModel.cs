using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Kobe.Domain.Dtos
{
    public class LoginViewModel
    {
        public string Username { get; set; }
        public string email { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }       
        public string Language { get; set; }
        public object TokenInfo { get; set; }
        
    }
}
