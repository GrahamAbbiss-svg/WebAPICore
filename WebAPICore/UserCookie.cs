using Microsoft.AspNetCore.Http;

namespace Civica.Core.EPortal.Web
{
    public class UserCookie
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public CookieOptions Options { get; set; }
    }
}
