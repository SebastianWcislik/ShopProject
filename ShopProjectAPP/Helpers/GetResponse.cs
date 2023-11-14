using System.Text.Json;

namespace ShopProjectAPP.Helpers
{
    public class GetResponse
    {
        public async Task<T> GetResponseAsync<T>(HttpClient client, string requestUri)
        {
            var data = await client.GetAsync(requestUri);
            var tmp1 = data.Content.ReadAsStringAsync().Result;
            var responseData = JsonSerializer.Deserialize<T>(tmp1);

            return responseData;
        }
    }
}
