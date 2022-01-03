using icok1.Domain.Entities;
using icok1.Persistence;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace icok1.Service.Features.ProductFeatures.Commands
{
    public class UpdateProductCommand : IRequest<string>
    {
        public string Id { get; set; }
        public string ProductName { get; set; }
        public string Size { get; set; }
        public string Type { get; set; }
        public decimal UnitPrice { get; set; }

        public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, string>
        {
            private readonly ICosmosDbServiceT<Product> _cosmosDbService;
            public UpdateProductCommandHandler(ICosmosDbServiceT<Product> cosmosDbService)
            {
                _cosmosDbService = cosmosDbService;
            }
            public async Task<string> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
            {
                var product = new Product()
                {
                    Id = request.Id,
                    ProductName = request.ProductName,
                    Size = request.Size,
                    Type = request.Type,
                    UnitPrice = request.UnitPrice
                };

                await _cosmosDbService.UpdateAsync(request.Id, product);
                return request.Id;
            }
        }
    }
}
