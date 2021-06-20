



using APIRequests.WebRequests;
using APIRequestsCore.WebRequestInterface;
using BLL.WebServices;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;

namespace Civica.Core.EPortal.Web
{
    public static class IoC
    {
        public static void Initialise(IServiceCollection services, string webServiceUrl)
        {
            services.AddTransient<IEmployeeService, EmployeeService>();
            services.AddHttpClient<EmployeeWebRequest>("WebClient", x => { x.BaseAddress = new Uri(webServiceUrl); }).ConfigurePrimaryHttpMessageHandler(ConfigureHandler);
            services.AddSingleton<EmployeeWebRequestClientFactory>();

        }

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
    }
}