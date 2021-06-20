using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;


namespace APIRequests.WebRequests
{
    public class EmployeeWebRequestClientFactory
    {
        private readonly IServiceProvider _serviceProvider;
        public EmployeeWebRequestClientFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public EmployeeWebRequest Create()
        {

            //return null;
            return _serviceProvider.GetRequiredService<EmployeeWebRequest>();
        }

        public EmployeeWebRequest CreateAWS()
        {

            //return null;
            return _serviceProvider.GetRequiredService<EmployeeWebRequest>();
        }
    }
}
