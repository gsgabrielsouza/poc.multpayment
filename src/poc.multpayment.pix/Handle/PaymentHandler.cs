using MediatR;
using poc.multpayment.provider.pix.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace poc.multpayment.provider.pix.Handle
{
    public class PaymentHandler : IRequestHandler<PixPaymentAuthorizeCommand>
    {
        public PaymentHandler()
        {
        }

        public Task<Unit> Handle(PixPaymentAuthorizeCommand request, CancellationToken cancellationToken)
        {
            Console.WriteLine("Pagamento na Cielo");
            return Unit.Task;
        }
    }
}
