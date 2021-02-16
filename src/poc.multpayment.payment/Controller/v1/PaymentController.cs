using Microsoft.AspNetCore.Mvc;
using poc.multpayment.application.Interfaces.v1;
using poc.multpayment.application.Services.v1.ViewModel;
using System.Threading.Tasks;

namespace poc.multpayment.payment.Controller.v1
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentAppService paymentAppService;

        public PaymentController(IPaymentAppService paymentAppService) => this.paymentAppService = paymentAppService ?? throw new System.ArgumentNullException(nameof(paymentAppService));

        [HttpPost]
        [Route("authorize")]
        public async Task<IActionResult> Authorize([FromBody] PaymentAuthorizeViewModel payment)
        {
            await paymentAppService.Authorize(payment);
            return Ok();
        }
    }
}
