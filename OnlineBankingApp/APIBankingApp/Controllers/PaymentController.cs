using APIBankingApp.Modals;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace APIBankingApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly IHubContext<PaymentHub> _hubContext;

        public PaymentController(IHubContext<PaymentHub> hubContext)
        {
            _hubContext = hubContext;
        }

        [HttpPost("notify")]
        public async Task<IActionResult> NotifyMerchant([FromBody] PaymentTransaction txn)
        {
            if (txn == null)
            {
                return BadRequest("Transaction data is required.");
            }

            await _hubContext.Clients.All.SendAsync("ReceivePayment", txn);
            return Ok();
        }
    }
}
