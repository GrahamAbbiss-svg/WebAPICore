//using AutoMapper;
using Civica.Core.EPortal.Web.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System.Text.Json;
using System;
using System.Threading.Tasks;
using Civica.Core.APIRequests.WebRequests;
using System.Net.Http;
using Civica.Core.BO;

namespace Civica.Core.EPortal.Web
{
    public class AuthenticationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly AppSettings _appSettings;

        public AuthenticationMiddleware(RequestDelegate next, IOptions<AppSettings> optionsAccessor)
        {
            _next = next;
            _appSettings = optionsAccessor.Value;
        }

        public async Task Invoke(HttpContext context)
        {
            var tmpLogger = new TempLogger("C:\\Log\\tmpEPortalLog.txt");
            try
            {
                UserVm user=new UserVm();
                //string cookieValue = "Temp";

                //if (cookieValue == null)
                //{
                    // Get the anonymous user and configuration details
                    //var resUser = await GetAnonymousUser().ConfigureAwait(false);
                    //var mapper = (IMapper)context.RequestServices.GetService(typeof(IMapper));
                    //user = mapper.Map<UserVm>(resUser.Data);

                    // Generate a random login id for an anonymous user
                    //user.LoginID = Guid.NewGuid().ToString();

                    // Save the user details as a cookie
                    //var cookie = Authorisation.BuildUserCookie(user, _appSettings.UserCookieName);
                    //context.Response.Cookies.Append(cookie.Name, cookie.Value, cookie.Options);
                //}
                //else{
                //    user = JsonSerializer.Deserialize<UserVm>(cookieValue);
                //}

                // Assign the user to the http user principal
                //context.User = user;

                await _next.Invoke(context);
            }
            catch (Exception e)
            {
                //tmpLogger.LogToFile("Invoke", "Error",e.Message);
            }
        }

        //private async Task<Result<UserBo>> GetAnonymousUser()
        //{
        //    var tmpLogger = new TempLogger("C:\\Log\\tmpEPortalLog.txt");
        //    try
        //    {
        //        var httpClient = new HttpClient(ConfigureHandler())
        //        {
        //            BaseAddress = _appSettings.HostType == "Dev" ? new Uri(_appSettings.CivicaCoreWebService) : new Uri(_appSettings.CivicaCoreWebServiceLive)
        //        };

        //        tmpLogger.LogToFile("GetAnonymousUser", "BaseUri", httpClient.BaseAddress.AbsoluteUri);

        //        var request = CreateRequest("Authorisation/GetAnonymousUser");

        //        var result = await httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);

        //        tmpLogger.LogToFile("GetAnonymousUser", "result", "result Got");

        //        using (var contentStream = await result.Content.ReadAsStreamAsync())
        //        {
        //            return await JsonSerializer.DeserializeAsync<Result<UserBo>>(contentStream, DefaultJsonSerializerOptions.Options);
        //        }
        //    }
        //    catch(Exception ex)
        //    {
        //        tmpLogger.LogToFile("GetAnonymousUser", "Error", ex.Message + "-" + ex.InnerException);
        //        throw;
        //    }
        //}

        private static readonly Func<HttpMessageHandler> ConfigureHandler = () =>
        {
            var bypassCertValidation = true; /*Configuration.GetValue<bool>("BypassRemoteCertificateValidation");*/
            var handler = new HttpClientHandler();
            //!DO NOT DO IT IN PRODUCTION!! GO AND CREATE VALID CERTIFICATE!
            if (bypassCertValidation)
            {
                handler.ServerCertificateCustomValidationCallback = (httpRequestMessage, x509Certificate2, x509Chain, sslPolicyErrors) => true;
            }
            return handler;
        };

        private static HttpRequestMessage CreateRequest(string methodName)
        {
            return new HttpRequestMessage(HttpMethod.Get, methodName);
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
