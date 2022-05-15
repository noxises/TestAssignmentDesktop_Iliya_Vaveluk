namespace TestAssignmentDesktop_Iliya_Vaveluk.Models
{
   
    public class ExchangesModel
    {
        public string exchangeId { get; set; }
        public string name { get; set; }
        public string rank { get; set; }
        public string percentTotalVolume { get; set; }
        public string volumeUsd { get; set; }
        public string tradingPairs { get; set; }
        public string socket { get; set; }
        public string exchangeUrl { get; set; }
        public string updated { get; set; }
    }

    public class RootExchanges
    {
        public List<ExchangesModel> data { get; set; }
        public long timestamp { get; set; }
    }


}
