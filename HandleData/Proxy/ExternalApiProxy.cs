using HandleData.Model;
using System.Text.Json;

namespace HandleData.Proxy
{
    public class ExternalApiProxy : IExternalApiProxy
    {
        public Task<Data?> GetAsync(string organizationNumber)
        {
            throw new NotImplementedException();
        }

        private static async Task<Data?> GetDeserializedData(HttpContent httpContent)
        {
            Data? data = new();

            string json = await httpContent.ReadAsStringAsync();
            if (json != null)
            {
                data = JsonSerializer.Deserialize<Data>(json);
            }

            return data;
        }
    }
}
