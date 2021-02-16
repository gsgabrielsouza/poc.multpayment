using poc.multpayment.application.Interfaces.v1;
using poc.multpayment.application.Provider;
using poc.multpayment.application.Services.v1.Command.PaymentCommand;
using poc.multpayment.application.Services.v1.ViewModel;
using poc.multpayment.domain.Command;
using System;
using System.Threading.Tasks;

namespace poc.multpayment.application.Services.v1
{
    public class PaymentAppService : IPaymentAppService
    {
        private readonly DispatchCommandProvider dispatchCommand;

        public PaymentAppService(DispatchCommandProvider dispatchCommand)
        {
            this.dispatchCommand = dispatchCommand;
        }
        public async Task Authorize(PaymentAuthorizeViewModel payment)
        {
            await dispatchCommand.Execute<PaymentAuthorizeCommand, object>(new PaymentAuthorizeCommand(payment.Amount, payment.OrderId, (ProviderEnum)payment.PaymentType));
        }
    }
}
