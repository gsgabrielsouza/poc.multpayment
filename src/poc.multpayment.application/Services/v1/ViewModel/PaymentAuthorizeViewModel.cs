namespace poc.multpayment.application.Services.v1.ViewModel
{
    public class PaymentAuthorizeViewModel
    {
        public int OrderId { get; set; }
        public decimal Amount { get; set; }
        public int PaymentType { get; set; }
    }
}
