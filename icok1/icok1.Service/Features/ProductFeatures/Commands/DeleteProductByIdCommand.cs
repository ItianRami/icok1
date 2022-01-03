using icok1.Domain.Entities;
using icok1.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace icok1.Service.Features.ProductFeatures.Commands
{
    public class DeleteProductByIdCommand : IRequest<string>
    {
        public string Id { get; set; }

        public class DeleteProductByIdCommandHandler : IRequestHandler<DeleteProductByIdCommand, string>
        {
            private readonly ICosmosDbServiceT<Product> _cosmosDbService;
            public DeleteProductByIdCommandHandler(ICosmosDbServiceT<Product> cosmosDbService)
            {
                _cosmosDbService = cosmosDbService;
            }
            public async Task<string> Handle(DeleteProductByIdCommand request, CancellationToken cancellationToken)
            {
                await _cosmosDbService.DeleteAsync(request.Id);
                return request.Id;
            }
        }
    }
}
