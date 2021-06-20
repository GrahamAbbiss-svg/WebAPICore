
using APIRequests.WebRequests;
using APIRequestsCore.WebRequestInterface;
using BO;
using Civica.Core.BO;
using System;
using System.Collections.Generic;
using System.Text;

using System.Threading.Tasks;


namespace BLL.WebServices
{
    public class EmployeeService : IEmployeeService
    {
        private readonly EmployeeWebRequestClientFactory _employeewebrequestClientFactory;
        public EmployeeService(EmployeeWebRequestClientFactory employeewebrequestClientFactory)
        {
            _employeewebrequestClientFactory = employeewebrequestClientFactory ?? throw new ArgumentNullException(nameof(employeewebrequestClientFactory));
        }

        public async Task<bool> AddDocument(string Document, string Filetype)
        {
            var addDoc = _employeewebrequestClientFactory.Create();
            var response = await addDoc.AddDocument(Document,Filetype).ConfigureAwait(false);
            return response;
        }

        public async Task<Result<bool>> AddFiles(List<CaseFileBo> files)
        {
            var caseClient = _employeewebrequestClientFactory.Create();
            var response = await caseClient.AddFiles(files).ConfigureAwait(false);
            return response;
        }

        public async Task<string> Employees()
        {
            var awsClient = _employeewebrequestClientFactory.Create();
            var response = await awsClient.Employees().ConfigureAwait(false);
            return response;
        }

        public async Task<List<City>> GetCityDescription(int Id)
        {
            var caseCity = _employeewebrequestClientFactory.Create();
            var response = await caseCity.GetCityDescription(Id).ConfigureAwait(false);
            return response;
        }

        public async Task<List<Document>> GetDocuments()
        {
            var getDoc = _employeewebrequestClientFactory.Create();
            var response = await getDoc.GetDocuments().ConfigureAwait(false);
            return response;
        }

        public async Task<List<Employee>> GetEmployee()
        {
            var caseEmployee = _employeewebrequestClientFactory.Create();
            var response = await caseEmployee.GetEmployee().ConfigureAwait(false);
            return response;
        }

        public async Task<CaseFileBo> GetFile()
        {
            var caseFile = _employeewebrequestClientFactory.Create();
            var response = await caseFile.GetFile().ConfigureAwait(false);
            return response;
        }
    }
}
