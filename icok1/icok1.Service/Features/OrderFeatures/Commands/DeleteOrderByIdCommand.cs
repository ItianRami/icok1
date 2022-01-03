using icok1.Domain.Entities;
using icok1.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace icok1.Service.Features.OrderFeatures.Commands
{
    public class DeleteOrderByIdCommand : IRequest<string>
    {
        public string Id { get; set; }

        public class DeleteOrderByIdCommandHandler : IRequestHandler<DeleteOrderByIdCommand, string>
        {
            private readonly ICosmosDbServiceT<Order> _cosmosDbService;
            public DeleteOrderByIdCommandHandler(ICosmosDbServiceT<Order> cosmosDbService)
            {
                _cosmosDbService = cosmosDbService;
            }
            public async Task<string> Handle(DeleteOrderByIdCommand request, CancellationToken cancellationToken)
            {
                await _cosmosDbService.DeleteAsync(request.Id);
                return request.Id;
            }
        }
    }
}
