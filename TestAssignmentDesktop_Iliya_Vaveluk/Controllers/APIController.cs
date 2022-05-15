using TestAssignmentDesktop_Iliya_Vaveluk.Models;
using Newtonsoft.Json;

namespace TestAssignmentDesktop_Iliya_Vaveluk.Controllers
{
    public class APIController
    {
        public static async Task<List<AllCurrenciesModel>> GetTop10Currencies()
        {
            HttpClient httpClient = new HttpClient();
            string request = "https://api.coincap.io/v2/assets?limit=10";
            HttpResponseMessage response =
                (await httpClient.GetAsync(request)).EnsureSuccessStatusCode();
            string httpResponse = await response.Content.ReadAsStringAsync();
            Root? myDeserializedClass = JsonConvert.DeserializeObject<Root>(httpResponse);
            return myDeserializedClass.data;
        }

        public static async Task<CurrencyModel?> GetCurrency(string id)
        {
            HttpClient httpClient = new HttpClient();
            string request = $"https://api.coincap.io/v2/assets/{id}";
            HttpResponseMessage response =
                (await httpClient.GetAsync(request)).EnsureSuccessStatusCode();
            string httpResponse = await response.Content.ReadAsStringAsync();
            RootCurrency? myDeserializedClass = JsonConvert.DeserializeObject<RootCurrency>(httpResponse);
            return myDeserializedClass.data;
        }
        public static async Task<List<MarketModel>> GetMarkets(string id)
        {
            HttpClient httpClient = new HttpClient();
            string request = $"https://api.coincap.io/v2/assets/{id}/markets?limit=10";
            HttpResponseMessage response =
                (await httpClient.GetAsync(request)).EnsureSuccessStatusCode();
            string httpResponse = await response.Content.ReadAsStringAsync();
            RootMarket? myDeserializedClass = JsonConvert.DeserializeObject<RootMarket>(httpResponse);
            return myDeserializedClass.data;
        }
        public static async Task<string> GetHistory(string id)
        {
            HttpClient httpClient = new HttpClient();
            string request = $"https://api.coincap.io/v2/assets/{id}/history?interval=d1";
            HttpResponseMessage response =
                (await httpClient.GetAsync(request)).EnsureSuccessStatusCode();
            string httpResponse = await response.Content.ReadAsStringAsync();
            RootCurrencyHistory? myDeserializedClass = JsonConvert.DeserializeObject<RootCurrencyHistory>(httpResponse);
            var jsDictionary = "[";
            foreach (var item in myDeserializedClass.data)
            {
                
                jsDictionary += "[" + "\""+ item.date.ToString("d") + "\","  + item.priceUsd + "]" + ",";
            }
            jsDictionary += "]";
            return jsDictionary;
        }
        public static async Task<List<ExchangesModel>> GetExchanges()
        {
            HttpClient httpClient = new HttpClient();
            string request = "https://api.coincap.io/v2/exchanges";
            HttpResponseMessage response =
                (await httpClient.GetAsync(request)).EnsureSuccessStatusCode();
            string httpResponse = await response.Content.ReadAsStringAsync();
            RootExchanges? myDeserializedClass = JsonConvert.DeserializeObject<RootExchanges>(httpResponse);
            return myDeserializedClass.data;
        }
    }
}
