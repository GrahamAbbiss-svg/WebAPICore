using System.Text.Json;

namespace Civica.Core.APIRequests.WebRequests
{
    public static class DefaultJsonSerializerOptions
    {
        public static JsonSerializerOptions Options => new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
    }
}
