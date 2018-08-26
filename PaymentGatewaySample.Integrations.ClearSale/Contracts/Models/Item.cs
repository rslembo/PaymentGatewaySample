namespace PaymentGatewaySample.Integrations.ClearSale.Contracts.Models
{
    public class Item
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal ItemValue { get; set; }
        public int Qty { get; set; }
        public int Gift { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName{ get; set; }
    }
}