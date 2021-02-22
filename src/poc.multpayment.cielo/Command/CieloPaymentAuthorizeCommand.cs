using MediatR;
using poc.multpayment.domain.Command;
using poc.multpayment.domain.Command.PaymentCommand;
using System;

namespace poc.multpayment.provider.cielo.Command
{
    public class CieloPaymentAuthorizeCommand : BaseCommand, IRequest
    {
        public CieloPaymentAuthorizeCommand(PaymentAuthorizeCommand paymentCommand) : this(paymentCommand.Amount, paymentCommand.OrderId, paymentCommand.CustomerId) { }

        public CieloPaymentAuthorizeCommand(decimal amount, int orderId, Guid customerId)
        {
            Amount = amount;
            OrderId = orderId;
            CustomerId = customerId;
        }

        public decimal Amount { get; set; }
        public int OrderId { get; set; }
        public Guid CustomerId { get; set; }

    }
}
