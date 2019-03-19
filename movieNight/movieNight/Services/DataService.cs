using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace movieNight.Services
{
    public class DataService
    {
        public static async Task<dynamic> GetDataFromService(string url)
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(url);

            dynamic data = null;
            if (response != null)
            {
                string json = response.Content.ReadAsStringAsync().Result;
                data = JsonConvert.DeserializeObject(json);
            }

            return data;
        }
    }
}