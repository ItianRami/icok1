using icok1.Domain.Entities;
using icok1.Persistence;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace icok1.Service.Features.ProductFeatures.Queries
{
    public class GetAllProductQuery : IRequest<IEnumerable<Product>>
    {
        public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQuery, IEnumerable<Product>>
        {
            private readonly ICosmosDbServiceT<Product> _cosmosDbService;
            public GetAllProductQueryHandler(ICosmosDbServiceT<Product> cosmosDbService) 
            {
                _cosmosDbService = cosmosDbService;
            }
            public async Task<IEnumerable<Product>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
            {
                return await _cosmosDbService.ListAsync("SELECT * FROM c");
            }
        }
    }
}
