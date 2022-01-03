using icok1.Domain.Entities;
using icok1.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace icok1.Service.Features.OrderFeatures.Queries
{
    public class GetAllOrderQuery : IRequest<IEnumerable<Order>>
    {
        public class GetAllOrderQueryHandler : IRequestHandler<GetAllOrderQuery, IEnumerable<Order>>
        {
            private readonly ICosmosDbServiceT<Order> _cosmosDbService;
            public GetAllOrderQueryHandler(ICosmosDbServiceT<Order> cosmosDbService) 
            {
                _cosmosDbService = cosmosDbService;
            }
            public async Task<IEnumerable<Order>> Handle(GetAllOrderQuery request, CancellationToken cancellationToken)
            {
                return await _cosmosDbService.ListAsync("SELECT * FROM c");
            }
        }
    }
}
