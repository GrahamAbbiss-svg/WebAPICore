
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using MVCCallAPICore.Models;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace CookieAuthenticationDemo.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public ActionResult UserLogin()
        {
            return View("~/Views/User/UserLogin.cshtml");
        }

        [HttpPost]
        public ActionResult UserLogin([Bind] Users user)
        {
            // username = anet 
            List<Users> lstusee = new List<Users>();
            var users = new Users();
            var allUsers = users.GetUsers().FirstOrDefault();
            if (users.GetUsers().Any(u => u.UserName == user.UserName))
            {
                var userClaims = new List<Claim>()
                {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, "anet@test.com"),
                 };

                var grandmaIdentity = new ClaimsIdentity(userClaims, "User Identity");

                var userPrincipal = new ClaimsPrincipal(new[] { grandmaIdentity });
                HttpContext.SignInAsync(userPrincipal);

                return RedirectToAction("Index", "Home");
            }
            lstusee.Add(user);
            return View("~/Views/Home/Users.cshtml", lstusee);
        }
    }
}