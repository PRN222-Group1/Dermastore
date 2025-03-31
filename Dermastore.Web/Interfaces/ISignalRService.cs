namespace Dermastore.Web.Interfaces
{
    public interface ISignalRService
    {
        Task LoadBlogs();
        Task LoadProducts();
        Task LoadAccounts();
        Task LoadOrders();
        Task LoadPromotions();
        Task LoadDashboard();
    }
}
