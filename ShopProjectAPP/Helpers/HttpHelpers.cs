using Newtonsoft.Json;

#nullable disable

namespace ShopProjectAPP.Helpers
{
    public class HttpHelpers
    {
        public HttpClient http;

        public HttpHelpers()
        {
            this.http = new HttpClient();
            this.http.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", "ServerAuth");
        }

        public async ValueTask<T> GetResponse<T>(string path)
        {
            var result = await http.GetStringAsync(path);
            T resultObejct = default;
            if (result != null)
            {
                resultObejct = JsonConvert.DeserializeObject<T>(result);
            }
            return resultObejct;
        }
    }
}
