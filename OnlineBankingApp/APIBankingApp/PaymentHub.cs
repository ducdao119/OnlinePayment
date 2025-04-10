using APIBankingApp.Modals;
using Microsoft.AspNetCore.SignalR;

namespace APIBankingApp
{
    public class PaymentHub : Hub
    {
        public async Task NotifyMerchant(PaymentTransaction txn)
        {
            await Clients.All.SendAsync("ReceivePayment", txn);
        }
    }
}
