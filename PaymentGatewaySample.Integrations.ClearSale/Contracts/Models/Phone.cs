namespace PaymentGatewaySample.Integrations.ClearSale.Contracts.Models
{
    public class Phone
    {
        public PhoneType Type { get; set; }
        public int CountryCode { get; set; }
        public int AreaCode { get; set; }
        public string Number { get; set; }
    }
}