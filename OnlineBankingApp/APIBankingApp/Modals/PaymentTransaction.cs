namespace APIBankingApp.Modals
{
    public class PaymentTransaction
    {
        public string Id { get; set; }
        public string QrCode { get; set; }
        public decimal Amount { get; set; }
        public DateTime Time { get; set; }
    }
}
