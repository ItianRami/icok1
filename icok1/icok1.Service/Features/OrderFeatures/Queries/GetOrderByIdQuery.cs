using icok1.Domain.Entities;
using icok1.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace icok1.Service.Features.OrderFeatures.Queries
{
    public class GetOrderByIdQuery : IRequest<Order>
    {
        public string Id { get; set; }
        public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, Order>
        {
            private readonly ICosmosDbServiceT<Order> _cosmosDbService;
            public GetOrderByIdQueryHandler(ICosmosDbServiceT<Order> cosmosDbService)
            {
                _cosmosDbService = cosmosDbService;
            }
            public async Task<Order> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
            {
                return await _cosmosDbService.GetAsync(request.Id);
            }
        }
    }
}
