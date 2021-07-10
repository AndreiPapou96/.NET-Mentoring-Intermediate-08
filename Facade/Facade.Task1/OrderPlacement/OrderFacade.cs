using System;

namespace Facade.Task1.OrderPlacement
{
    //Implement Façade to place order.
    //Place order algorithm:  
    //Load product by product Id.Use ProductCatalog service.
    //Make payment for the product from ProductCatalog service using service PaymentSystem.
    //Make invoice payment using InvoiceSystem. 

    public class OrderFacade
    {
        private InvoiceSystem _invoiceSystem;
        private PaymentSystem _paymentSystem;
        private ProductCatalog _productCatalog;

        public OrderFacade(InvoiceSystem invoiceSystem, PaymentSystem paymentSystem, ProductCatalog productCatalog)
        {
            _invoiceSystem = invoiceSystem;
            _paymentSystem = paymentSystem;
            _productCatalog = productCatalog;
        }

        public void PlaceOrder(string productId, int quantity, string email)
        {
            var product = _productCatalog.GetProductDetails(productId);
            var payment = new Payment
            {
                ProductId = product.Id,
                ProductName = product.Name,
                Quantity = quantity,
                TotalPrice = product.Price
            };

            var invoice = new Invoice
            {
                CustomerEmail = email,
                DueDate = DateTime.Now.AddMonths(3),
                SendDate = DateTime.Now,
                InvoiceNumber = new Guid(),
                ProductId = product.Id,
                ProductName = product.Name,
                Quantity = quantity,
                TotalPrice = product.Price
            };

            _paymentSystem.MakePayment(payment);
            _invoiceSystem.SendInvoice(invoice);
        }
    }
}
