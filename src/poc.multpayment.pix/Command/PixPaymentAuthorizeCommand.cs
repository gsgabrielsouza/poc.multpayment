using MediatR;
using poc.multpayment.domain.Command;
using poc.multpayment.domain.Command.PaymentCommand;

namespace poc.multpayment.provider.pix.Command
{
    public class PixPaymentAuthorizeCommand : BaseCommand, IRequest
    {
        public PixPaymentAuthorizeCommand(PaymentAuthorizeCommand paymentCommand) { }
    }
}
