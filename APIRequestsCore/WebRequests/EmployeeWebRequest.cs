
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using System.Text.Json;

using System.Net.Http;
using System.Runtime.CompilerServices;

using BO;
using Civica.Core.BO;
using APIRequestsCore.WebRequestInterface;
using Civica.Core.APIRequests.WebRequests;

namespace APIRequests.WebRequests
{
    public class EmployeeWebRequest : IEmployeeWebRequest
    {
        private static HttpClient _httpClient;
        public EmployeeWebRequest(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        private static HttpRequestMessage CreateRequest(string args = "", [CallerMemberName] string MethodName = "")
        {
            return new HttpRequestMessage(HttpMethod.Get, Constants.CaseRepoPath + "/" + MethodName + args);
        }
        private static HttpRequestMessage CreateRequestAWS(string args = "", [CallerMemberName] string MethodName = "")
        {
            return new HttpRequestMessage(HttpMethod.Get, Constants.CaseRepoPathAWS + "/" + MethodName + args);
        }
        private static string CreateURI(string args, [CallerMemberName] string MethodName = "")
        {
            return new string(Constants.CaseRepoPath + "/" + MethodName + args);

        }
        private static HttpRequestMessage CreateRequestSecure(string args = "", [CallerMemberName] string MethodName = "")
        {
            return new HttpRequestMessage(HttpMethod.Get, Constants.CaseRepoPathAuth + "/" + MethodName + args);
        }
        private static string CreateURISecure(string args, [CallerMemberName] string MethodName = "")
        {
            return new string("api" + "/" + Constants.CaseRepoPathAuth + "/" + MethodName + args);
        }

        private static HttpRequestMessage CreateRequestSecureA(string args = "")
        {
            return new HttpRequestMessage(HttpMethod.Get, args);
        }

        public async Task<bool> AddDocument(string Document,string Filetype)
        {
            try
            {
                var request = CreateRequest("/" + Document.ToString() + "/" + Filetype.ToString());
                var result = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);

                using (var contentStream = await result.Content.ReadAsStreamAsync())
                {
                    return await JsonSerializer.DeserializeAsync<bool>(contentStream, DefaultJsonSerializerOptions.Options);
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<Result<bool>> AddFiles(List<CaseFileBo> files)
        {
            try
            {
                var json = JsonSerializer.Serialize(files);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var request = CreateURI("/");
                
                var result = await _httpClient.PostAsync(request, content).ConfigureAwait(false);

                using (var contentStream = await result.Content.ReadAsStreamAsync())
                {
                    return await JsonSerializer.DeserializeAsync<Result<bool>>(contentStream, DefaultJsonSerializerOptions.Options);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> Employees()
        {
            
            try
            {
                var request = CreateRequestAWS("/");
                var result = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);

                using (var contentStream = await result.Content.ReadAsStreamAsync())
                {
                    return await JsonSerializer.DeserializeAsync<string>(contentStream, DefaultJsonSerializerOptions.Options);
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<City>> GetCityDescription(int Id)
        {
            try
            {
                var request = CreateRequest("/" + Id.ToString());
                var result = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);

                using (var contentStream = await result.Content.ReadAsStreamAsync())
                {
                    return await JsonSerializer.DeserializeAsync<List<City>>(contentStream, DefaultJsonSerializerOptions.Options);
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Document>> GetDocuments()
        {
            try
            {
                var request = CreateRequest("/");
                var result = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);

                using (var contentStream = await result.Content.ReadAsStreamAsync())
                {
                    return await JsonSerializer.DeserializeAsync<List<Document>>(contentStream, DefaultJsonSerializerOptions.Options);
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Employee>> GetEmployee()
        {
            try
            {
                var request = CreateRequest("/");
                var result = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);

                using (var contentStream = await result.Content.ReadAsStreamAsync())
                {
                    return await JsonSerializer.DeserializeAsync<List<Employee>>(contentStream, DefaultJsonSerializerOptions.Options);
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<CaseFileBo> GetFile()
        {
            try
            {
                var request = CreateRequest("/");
                var result = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);

                using (var contentStream = await result.Content.ReadAsStreamAsync())
                {
                    return await JsonSerializer.DeserializeAsync<CaseFileBo>(contentStream, DefaultJsonSerializerOptions.Options);
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<WeatherForecast>> GetWeather(string token)
        {
            try
            {
                var request = CreateRequestSecureA("WeatherForecast");
                //request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiU2FyYXRobGFsIiwianRpIjoiZGEzMmFjMzItZWQ0MS00ZmVlLWJkY2YtMWE4NjNlMWY3ZTA1IiwiZXhwIjoxNjU0MDAxMDM1LCJpc3MiOiJodHRwOi8vbG9jYWxob3N0OjYxOTU1IiwiYXVkIjoiaHR0cDovL2xvY2FsaG9zdDo0MjAwIn0.xpspfVHDrh0P84WLUsJ2R5wSXMFHtccrJ7zblB2Y7Y8");
                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                var result = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);

                using (var contentStream = await result.Content.ReadAsStreamAsync())
                {
                    return await JsonSerializer.DeserializeAsync<IEnumerable<WeatherForecast>>(contentStream, DefaultJsonSerializerOptions.Options);
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<Result<LoginClient>> LoginClient(LoginModel login)
        {
            try
            {
                var json = JsonSerializer.Serialize(login);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var request = CreateURISecure("/");

                var result = await _httpClient.PostAsync(request, content).ConfigureAwait(false);

                using (var contentStream = await result.Content.ReadAsStreamAsync())
                {
                    return await JsonSerializer.DeserializeAsync<Result<LoginClient>>(contentStream, DefaultJsonSerializerOptions.Options);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
