using TestAssignmentDesktop_Iliya_Vaveluk.Models;
using Newtonsoft.Json;

namespace TestAssignmentDesktop_Iliya_Vaveluk.Controllers
{
    public class APIController
    {
        public static async Task<string> GetResponse(string url)
        {
            HttpClient httpClient = new HttpClient();
            string httpResponse = "";
            try
            {
                HttpResponseMessage response = (await httpClient.GetAsync(url)).EnsureSuccessStatusCode();
                httpResponse = await response.Content.ReadAsStringAsync();
            }
            catch (Exception)
            {
                Console.WriteLine("404");
                throw;
            }

            return httpResponse;
        }
        public static List<AllCurrenciesModel> GetAllCurrencies()
        {
            var response = GetResponse("https://api.coincap.io/v2/assets").GetAwaiter().GetResult();
            Root? myDeserializedClass = JsonConvert.DeserializeObject<Root>(response);
            return myDeserializedClass.data;
        }
        public static CurrencyModel? GetCurrency(string id)
        {
            var response = GetResponse($"https://api.coincap.io/v2/assets/{id}").GetAwaiter().GetResult();
            RootCurrency? myDeserializedClass = JsonConvert.DeserializeObject<RootCurrency>(response);
            return myDeserializedClass.data;
        }
        public static List<MarketModel> GetMarkets(string id)
        {
            var response = GetResponse($"https://api.coincap.io/v2/assets/{id}/markets?limit=10").GetAwaiter().GetResult();
            RootMarket? myDeserializedClass = JsonConvert.DeserializeObject<RootMarket>(response);
            return myDeserializedClass.data;
        }
        public static string GetHistory(string id)
        {
            var response = GetResponse($"https://api.coincap.io/v2/assets/{id}/history?interval=d1").GetAwaiter().GetResult();
            RootCurrencyHistory? myDeserializedClass = JsonConvert.DeserializeObject<RootCurrencyHistory>(response);
            return CreateStringForJapaneseChart(myDeserializedClass);
        }
        public static string CreateStringForJapaneseChart(RootCurrencyHistory list)
        {
            var result = "[";
            foreach (var item in list.data)
            {

                result += "[" + "\"" + item.date.ToString("d") + "\"," + item.priceUsd + "]" + ",";
            }
            result += "]";
            return result;
        }
        public static List<ExchangesModel> GetExchanges()
        {
            var response = GetResponse("https://api.coincap.io/v2/exchanges").GetAwaiter().GetResult();
            RootExchanges? myDeserializedClass = JsonConvert.DeserializeObject<RootExchanges>(response);
            return myDeserializedClass.data;
        }
    }
}
