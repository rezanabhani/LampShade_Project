using System.Linq;
using _01_LampshadeReport.Contracts.Order;
using ShopManagement.Infrastructure.EfCore;

namespace _01_LampshadeReport.Query
{
    public class OrderReport : IOrderReport
    {
        private readonly ShopContext _shopContext;

        public OrderReport(ShopContext shopContext)
        {
            _shopContext = shopContext;
        }

        public long CountSales()
        {
            return _shopContext.Orders.Where(x => x.IsPaid == true).ToList().Count;
        }

        public long CountNewOrders()
        {
            return _shopContext.Orders.ToList().Count;
        }
    }
}
