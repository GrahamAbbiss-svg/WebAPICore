using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestMVC.Filters
{
    public class CustomAuthorizationFilterAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            string currentUserRole = Convert.ToString(context.HttpContext.Session.GetString("UserRole"));

            UserVm vm = new UserVm();
            vm = (UserVm)context.HttpContext.User;

            object[] action = new object[2];

            action = (object[])context.RouteData.Values.Values;

            if (!string.IsNullOrEmpty(vm.Name))
            {
                if (vm.RoleId != 1)
                {
                    context.Result = new RedirectToRouteResult
                (
                new RouteValueDictionary(new
                {
                    action = "Error",
                    controller = "Home"
                }));

                }

            }
            else
            {
                context.Result = new RedirectToRouteResult
                (
                new RouteValueDictionary(new
                {
                    action = "Error",
                    controller = "Home"
                }));

            }

        }
    }
}
