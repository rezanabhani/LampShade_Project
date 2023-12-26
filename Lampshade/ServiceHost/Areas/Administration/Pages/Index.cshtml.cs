using System.Collections.Generic;
using _01_LampshadeReport.Contracts.Account;
using _01_LampshadeReport.Contracts.Order;
using AccountManagement.Application.Contracts.Account;
using AccountManagement.Application.Contracts.AccountAddress;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using ShopManagement.Application.Contracts.Order;

namespace ServiceHost.Areas.Administration.Pages
{
    public class IndexModel : PageModel
    {
        public long CountSales;
        public long CountNewOrders;
        public long CountUsers;
        public Chart DoughnutDataSet { get; set; }
        public List<Chart> BarLineDataSet { get; set; }

        private readonly IOrderReport _orderReport;
        private readonly IAccountReport _accountReport;

        public IndexModel(IOrderReport orderReport, IAccountReport accountReport)
        {
            _orderReport = orderReport;
            _accountReport = accountReport;
        }

        public void OnGet()
        {
            CountSales = _orderReport.CountSales();
            CountNewOrders = _orderReport.CountNewOrders();
            CountUsers = _accountReport.CountUsers();

            BarLineDataSet = new List<Chart>
            {
                new Chart
                {
                    Label = "Apple",
                    Data = new List<int> {100, 200, 250, 170, 50},
                    BackgroundColor = new[] {"#ffcdb2"},
                    BorderColor = "#b5838d"
                },
                new Chart
                {
                    Label = "Samsung",
                    Data = new List<int> {200, 300, 350, 270, 100},
                    BackgroundColor = new[] {"#ffc8dd"},
                    BorderColor = "#ffafcc"
                },
                new Chart
                {
                    Label = "Total",
                    Data = new List<int> {300, 500, 600, 440, 150},
                    BackgroundColor = new[] {"#0077b6"},
                    BorderColor = "#023e8a"
                },
            };
            DoughnutDataSet = new Chart
            {
                Label = "Apple",
                Data = new List<int> { 100, 200, 250, 170, 50 },
                BorderColor = "#ffcdb2",
                BackgroundColor = new[] { "#b5838d", "#ffd166", "#7f4f24", "#ef233c", "#003049" }
            };
        }
    }
    

    public class Chart
    {
        [JsonProperty(PropertyName = "label")] public string Label { get; set; }

        [JsonProperty(PropertyName = "data")] public List<int> Data { get; set; }

        [JsonProperty(PropertyName = "backgroundColor")]
        public string[] BackgroundColor { get; set; }

        [JsonProperty(PropertyName = "borderColor")]
        public string BorderColor { get; set; }
    }
}
