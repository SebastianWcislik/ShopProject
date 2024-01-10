using Newtonsoft.Json;
using System.Text;

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
            try
            {
                if (result != null)
                {
                    resultObejct = JsonConvert.DeserializeObject<T>(result);
                }
            }
            catch
            {
                return resultObejct;
            }
            return resultObejct;
        }

        public async ValueTask<T> PostResponse<T>(string path, object content)
        {
            string json = JsonConvert.SerializeObject(content);
            var jsonContent = new StringContent(json,  Encoding.UTF8, "application/json");

            var result = await http.PostAsync(path, jsonContent);
            T resultObejct = default;
            try
            {
                if (result != null)
                {
                    var resultMessage = await result.Content.ReadAsStringAsync();
                    resultObejct = JsonConvert.DeserializeObject<T>(resultMessage);
                }
            }
            catch
            {
                return resultObejct;
            }
            return resultObejct;
        }

        public async ValueTask<T> PutResponse<T>(string path, object content)
        {
            string json = JsonConvert.SerializeObject(content);
            var jsonContent = new StringContent(json, Encoding.UTF8, "application/json");

            var result = await http.PutAsync(path, jsonContent);
            T resultObejct = default;
            try
            {
                if (result != null)
                {
                    var resultMessage = await result.Content.ReadAsStringAsync();
                    resultObejct = JsonConvert.DeserializeObject<T>(resultMessage);
                }
            }
            catch
            {
                return resultObejct;
            }
            return resultObejct;
        }

        public async ValueTask<T> DeleteResponse<T>(string path)
        {
            var result = await http.DeleteAsync(path);
            T resultObejct = default;
            try
            {
                if (result != null)
                {
                    var resultMessage = await result.Content.ReadAsStringAsync();
                    resultObejct = JsonConvert.DeserializeObject<T>(resultMessage);
                }
            }
            catch
            {
                return resultObejct;
            }
            return resultObejct;
        }
    }
}
