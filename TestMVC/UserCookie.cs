using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
namespace TestMVC
{
    public class UserCookie
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public CookieOptions Options { get; set; }
    }
}
