using poc.multpayment.domain.Command;
using System;

namespace poc.multpayment.domain.Command.PaymentCommand
{
    public class PaymentAuthorizeCommand : BaseCommand
    {
        public PaymentAuthorizeCommand(decimal amount, int orderId, ProviderEnum providerEnum) : base(providerEnum)
        {
            Amount = amount;
            OrderId = orderId;
        }

        public decimal Amount { get; set; }
        public int OrderId { get; set; }
        public Guid CustomerId { get; set; }

    }
}
