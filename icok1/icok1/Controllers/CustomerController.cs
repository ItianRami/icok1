//using icok1.Service.Features.CustomerFeatures.Commands;
//using icok1.Service.Features.CustomerFeatures.Queries;
//using MediatR;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.DependencyInjection;
//using System.Threading.Tasks;

//namespace icok1.Controllers
//{
//    [Authorize]
//    [ApiController]
//    [Route("api/v{version:apiVersion}/Customer")]
//    [ApiVersion("1.0")]
//    public class CustomerController : ControllerBase
//    {
//        private IMediator _mediator;
//        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

//        [HttpPost]
//        public async Task<IActionResult> Create(CreateProductCommand command)
//        {
//            return Ok(await Mediator.Send(command));
//        }

//        [HttpGet]
//        [Route("")]
//        public async Task<IActionResult> GetAll()
//        {
//            return Ok(await Mediator.Send(new GetAllProductQuery()));
//        }

//        [HttpGet("{id}")]
//        public async Task<IActionResult> GetById(string id)
//        {
//            return Ok(await Mediator.Send(new GetProductByIdQuery { Id = id }));
//        }

//        [HttpDelete("{id}")]
//        public async Task<IActionResult> Delete(string id)
//        {
//            return Ok(await Mediator.Send(new DeleteProductByIdCommand { Id = id }));
//        }


//        [HttpPut("{id}")]
//        public async Task<IActionResult> Update(string id, UpdateProductCommand command)
//        {
//            if (id != command.Id)
//            {
//                return BadRequest();
//            }
//            return Ok(await Mediator.Send(command));
//        }
//    }
//}
