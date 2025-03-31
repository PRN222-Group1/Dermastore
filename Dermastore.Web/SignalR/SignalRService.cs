using Dermastore.Web.Interfaces;
using Microsoft.AspNetCore.SignalR;

namespace Dermastore.Web.Services
{
    public class SignalRService : ISignalRService
    {
        private readonly IHubContext<SignalRServer> _hubContext;

        public SignalRService(IHubContext<SignalRServer> hubContext) 
        {
            _hubContext = hubContext;
        }

        public async Task LoadAccounts()
        {
            await _hubContext.Clients.All.SendAsync("LoadAccounts");
        }

        public async Task LoadBlogs()
        {
            await _hubContext.Clients.All.SendAsync("LoadBlogs");
        }

        public async Task LoadOrders()
        {
            await _hubContext.Clients.All.SendAsync("LoadOrders");
        }

        public async Task LoadProducts()
        {
            await _hubContext.Clients.All.SendAsync("LoadProducts");
        }

        public async Task LoadPromotions()
        {
            await _hubContext.Clients.All.SendAsync("LoadPromotions");
        }

        public async Task LoadDashboard()
        {
            await _hubContext.Clients.All.SendAsync("LoadDashboard");
        }
    }
}
