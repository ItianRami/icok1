using icok1.Domain.Entities;
using icok1.Persistence;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace icok1.Service.Features.OrderFeatures.Queries
{
    public class GetAllOrderByUserIdQuery : IRequest<IEnumerable<Order>>
    {
        public string CustomerId { get; set; }
        public class GetAllOrderByUserIdQueryHandler : IRequestHandler<GetAllOrderByUserIdQuery, IEnumerable<Order>>
        {
            private readonly ICosmosDbServiceT<Order> _cosmosDbService;
            public GetAllOrderByUserIdQueryHandler(ICosmosDbServiceT<Order> cosmosDbService)
            {
                _cosmosDbService = cosmosDbService;
            }
            public async Task<IEnumerable<Order>> Handle(GetAllOrderByUserIdQuery request, CancellationToken cancellationToken)
            {
                return await _cosmosDbService.ListAsync("SELECT * FROM c WHERE c.CustomerId = '" + request.CustomerId + "'");
            }
        }
    }
}
