using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Identity.Client.Extensions.Msal;

namespace clientsApi.Dto.AccountDto
{
    public class NewUserDto
    {
        public string UserName { get; set; }
        public string Email { get; set; } 
        public string Token { get; set; }
    }
}