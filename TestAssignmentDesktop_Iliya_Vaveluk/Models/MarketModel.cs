namespace TestAssignmentDesktop_Iliya_Vaveluk.Models
{
    public class MarketModel
    {
        public string exchangeId { get; set; }
        public string baseId { get; set; }
        public string quoteId { get; set; }
        public string baseSymbol { get; set; }
        public string quoteSymbol { get; set; }
        public string volumeUsd24Hr { get; set; }
        public string priceUsd { get; set; }
        public string volumePercent { get; set; }
    }

    public class RootMarket
    {
        public List<MarketModel> data { get; set; }
        public long timestamp { get; set; }
    }

}
