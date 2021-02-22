using MediatR;
using poc.multpayment.provider.cielo.Command;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace poc.multpayment.provider.cielo.Handle
{
    public class PaymentHandle :  IRequestHandler<CieloPaymentAuthorizeCommand>
    {
        public Task<Unit> Handle(CieloPaymentAuthorizeCommand request, CancellationToken cancellationToken)
        {
            Console.WriteLine("Pagamento na Cielo");
            return Unit.Task;
        }
    }
}
