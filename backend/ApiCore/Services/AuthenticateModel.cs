using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCore.Services
{
    public class AuthenticateModel
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string PassWord { get; set; }
        public string Permission { get; set; }
        public string Token { get; set; }
    }
}
