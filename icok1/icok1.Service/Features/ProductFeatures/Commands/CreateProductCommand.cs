using icok1.Domain.Entities;
using icok1.Persistence;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace icok1.Service.Features.ProductFeatures.Commands
{
    public class CreateProductCommand : IRequest<string>
    {
        public string ProductName { get; set; }
        public string Size { get; set; }
        public string Type { get; set; }
        public decimal UnitPrice { get; set; }

        public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, string>
        {
            private readonly ICosmosDbServiceT<Product> _cosmosDbService;

            public CreateProductCommandHandler(ICosmosDbServiceT<Product> cosmosDbService)
            {
                _cosmosDbService = cosmosDbService;
            }
            public async Task<string> Handle(CreateProductCommand request, CancellationToken cancellationToken)
            {
                var product = new Product()
                {
                    Id = Guid.NewGuid().ToString(),
                    ProductName = request.ProductName,
                    Size = request.Size,
                    Type = request.Type,
                    UnitPrice = request.UnitPrice
                };

                await _cosmosDbService.AddAsync(product);
                return product.Id;
            }
        }
    }
}
