using FoodOrdering.MVC.Services;
using FoodOrdering.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FoodOrdering.MVC.Controllers
{
    public class OrdersController : Controller
    {
        private readonly ApiService _apiService;
        private readonly InvoiceService _invoiceService;

        public OrdersController(
            ApiService apiService,
            InvoiceService invoiceService)
        {
            _apiService = apiService;
            _invoiceService = invoiceService;
        }

        public async Task<IActionResult> Index()
        {
            var orders =
                await _apiService.GetAsync
                <List<OrderViewModel>>(
                    "api/Orders");

            return View(orders);
        }

        public async Task<IActionResult> DownloadInvoice(
            int id)
        {
            var orders =
                await _apiService.GetAsync
                <List<OrderViewModel>>(
                    "api/Orders");

            var order =
                orders?.FirstOrDefault(
                    x => x.Id == id);

            if (order == null)
                return NotFound();

            var invoice =
                new InvoiceViewModel
                {
                    OrderId = order.Id,
                    CustomerName =
                        order.CustomerName,

                    CustomerEmail =
                        order.CustomerEmail,

                    TotalAmount =
                        order.TotalAmount,

                    OrderDate =
                        order.OrderDate,

                    Items =
                        order.OrderItems
                };

            var pdf =
                _invoiceService
                    .GenerateInvoice(invoice);

            return File(
                pdf,
                "application/pdf",
                $"Invoice_{order.Id}.pdf");
        }
    }
}