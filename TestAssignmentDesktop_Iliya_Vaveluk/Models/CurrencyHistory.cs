namespace TestAssignmentDesktop_Iliya_Vaveluk.Models
{
    
    public class CurrencyHistory
    {
        public string priceUsd { get; set; }
        public long time { get; set; }
        public DateTime date { get; set; }
    }

    public class RootCurrencyHistory
    {
        public List<CurrencyHistory> data { get; set; }
        public long timestamp { get; set; }
    }
}
