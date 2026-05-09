using FoodOrdering.MVC.ViewModels;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace FoodOrdering.MVC.Services
{
    public class InvoiceService
    {
        public byte[] GenerateInvoice(
            InvoiceViewModel model)
        {
            return Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Margin(40);

                    page.Header()
                        .Text("FoodExpress Invoice")
                        .FontSize(28)
                        .Bold();

                    page.Content().Column(column =>
                    {
                        column.Spacing(10);

                        column.Item().Text(
                            $"Order ID: {model.OrderId}");

                        column.Item().Text(
                            $"Customer: {model.CustomerName}");

                        column.Item().Text(
                            $"Email: {model.CustomerEmail}");

                        column.Item().Text(
                            $"Date: {model.OrderDate}");

                        column.Item().PaddingVertical(10);

                        column.Item().Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                            });

                            table.Header(header =>
                            {
                                header.Cell().Text("Food");
                                header.Cell().Text("Price");
                                header.Cell().Text("Qty");
                            });

                            foreach (var item in model.Items)
                            {
                                table.Cell().Text(
                                    item.FoodName);

                                table.Cell().Text(
                                    $"₹ {item.Price}");

                                table.Cell().Text(
                                    item.Quantity.ToString());
                            }
                        });

                        column.Item().PaddingTop(20);

                        column.Item().Text(
                            $"Grand Total: ₹ {model.TotalAmount}")
                            .Bold()
                            .FontSize(20);
                    });
                });
            }).GeneratePdf();
        }
    }
}