using poc.multpayment.application.Services.v1.ViewModel;
using System.Threading.Tasks;

namespace poc.multpayment.application.Interfaces.v1
{
    public interface IPaymentAppService
    {
        Task Authorize(PaymentAuthorizeViewModel payment);
    }
}
