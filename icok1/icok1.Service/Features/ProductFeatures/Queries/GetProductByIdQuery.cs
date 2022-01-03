using icok1.Domain.Entities;
using icok1.Persistence;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace icok1.Service.Features.ProductFeatures.Queries
{
    public class GetProductByIdQuery : IRequest<Product>
    {
        public string Id { get; set; }
        public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Product>
        {
            private readonly ICosmosDbServiceT<Product> _cosmosDbService;
            public GetProductByIdQueryHandler(ICosmosDbServiceT<Product> cosmosDbService)
            {
                _cosmosDbService = cosmosDbService;
            }
            public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
            {
                return await _cosmosDbService.GetAsync(request.Id);
            }
        }
    }
}
