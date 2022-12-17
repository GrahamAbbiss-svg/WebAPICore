using AutoMapper;
using Civica.Core.BO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using WebAPI.Core.Common;


namespace TestMVC
{
    public class AuthenticationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly WebAPI.Core.Common.AppSettings _appSettings;

        public AuthenticationMiddleware(RequestDelegate next, IOptions<WebAPI.Core.Common.AppSettings> optionsAccessor)
        {
            _next = next;
            _appSettings = optionsAccessor.Value;
            
        }

        //public async Task Invoke(HttpContext context)
        //{
        //    try
        //    {
        //        UserVm user=new UserVm();
        //        //_appSettings.UserCookieName = "test";
        //        string cookieValue = context.Request.Cookies[_appSettings.UserCookieName];

        //        if (cookieValue == null)
        //        {
        //            // Get the anonymous user and configuration details
        //            var resUser = GetAnonymousUser();
        //            var mapper = (IMapper)context.RequestServices.GetService(typeof(IMapper));

        //            user = mapper.Map<UserVm>(resUser);
        //            // Generate a random login id for an anonymous user
        //            //user.LoginID = Guid.NewGuid().ToString();
        //            // Save the user details as a cookie
        //            var cookie = Authorisation.BuildUserCookie(user, _appSettings.UserCookieName);
        //            context.Response.Cookies.Append(cookie.Name, cookie.Value, cookie.Options);
        //        }
        //        else
        //        {
        //            user = JsonSerializer.Deserialize<UserVm>(cookieValue);
        //        }

        //        // Assign the user to the http user principal
        //        context.User = user;

        //        await _next.Invoke(context);
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}

        public async Task Invoke(HttpContext context)
        {
            try
            {
                //UserVm user;
                string cookieValue = context.Request.Cookies[_appSettings.UserCookieName];
               // DeleteCookies(context);
                
                if (cookieValue != null)
                {
                    context.User = JsonSerializer.Deserialize<UserVm>(cookieValue);
                }

                await _next.Invoke(context);
            }
            catch (Exception e)
            {
            }
        }

        private void DeleteCookies(HttpContext context)
        {
            foreach (var cookie in context.Request.Cookies)
            {
                context.Response.Cookies.Delete(cookie.Key);
            }
        }
        private UserBo GetAnonymousUser()
        {
            UserBo userBo = new UserBo();
            try
            {
                userBo.LoginID = "1234";
                userBo.Name = "Reece";
                userBo.Password = "secsybum";
                return userBo;
            }
            catch
            {
                throw;
            }
        }

      
        }
    public static class AuthorisationMiddlewareExtensions
    {
        public static IApplicationBuilder UseAuthenticationMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AuthenticationMiddleware>();
        }
    }
}
