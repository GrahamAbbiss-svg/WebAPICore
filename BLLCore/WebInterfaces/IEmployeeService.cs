
using BO;
using Civica.Core.BO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace APIRequestsCore.WebRequestInterface
{
    public interface IEmployeeService
    {
        Task<bool> AddDocument(string Document, string Filetype);

        Task<List<City>> GetCityDescription(int Id);

        Task<List<Document>> GetDocuments();

        Task<List<Employee>> GetEmployee();

        Task<CaseFileBo> GetFile();

        Task<Result<bool>> AddFiles(List<CaseFileBo> files);
        Task<string> Employees();

        Task<IEnumerable<WeatherForecast>> GetWeather(string token);

        Task<Result<LoginClient>> LoginClient(LoginModel login);


    }
}
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       