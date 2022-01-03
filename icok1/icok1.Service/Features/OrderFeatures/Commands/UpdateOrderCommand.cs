using icok1.Domain.Entities;
using icok1.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace icok1.Service.Features.OrderFeatures.Commands
{
    public class UpdateOrderCommand : IRequest<string>
    {
        public string Id { get; set; }
        public string CustomerId { get; set; }
        //public DateTime OrderDate { get; set; }
        public Dictionary<string, int> OrderDetails { get; set; }
        //public PaymentTransaction PaymentTransaction { get; set; }

        public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, string>
        {
            private readonly ICosmosDbServiceT<Order> _cosmosDbService;
            private readonly ICosmosDbServiceT<Product> _productCosmosDbService;

            public UpdateOrderCommandHandler(ICosmosDbServiceT<Order> cosmosDbService, ICosmosDbServiceT<Product> productCosmosDbService)
            {
                _cosmosDbService = cosmosDbService;
                _productCosmosDbService = productCosmosDbService;
            }
            public async Task<string> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
            {
                //order details
                decimal total = 0;
                var orderDetails = new List<OrderDetail>();
                foreach (var item in request.OrderDetails)
                {
                    var product = await _productCosmosDbService.GetAsync(item.Key);
                    orderDetails.Add(new OrderDetail()
                    {
                        Product = product,
                        Qty = item.Value,
                    });
                    total += Math.Ceiling(product.UnitPrice * item.Value);
                }
                //payment
                var payment = new PaymentTransaction()
                {
                    IsComplete = true,
                    Total = total,
                };
                //order
                var order = new Order()
                {
                    Id = Guid.NewGuid().ToString(),
                    CustomerId = request.CustomerId,
                    OrderDate = DateTime.UtcNow,
                    OrderDetails = orderDetails,
                    PaymentTransaction = payment,
                };

                await _cosmosDbService.UpdateAsync(request.Id, order);
                return request.Id;
            }
        }
    }
}
