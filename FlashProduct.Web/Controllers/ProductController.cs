using Application.ProductUseCase.Command;
using Domain.Dtos.Product;
using Domain.Services;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Domain;
using Application.ProductUseCase.Queries;
using Domain.Repositries.Common;
using Domain.Dtos.Product.CreateProductDtos;
using Application.ProductUseCase.Handler.CommandHandler;

namespace FlashProduct.Web.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProductDto createProductDto)
        {
            await _mediator.Publish(new CreateProductCommand(createProductDto));
            return Ok();
        }
        [HttpGet("AllProducts")]
        public async Task<ActionResult<PageResult<ProductDto>>> GetProducts([FromQuery] PageRequest pageRequest, [FromHeader(Name = "Accept-Language")] string acceptLanguage)
        {
            return Ok(await _mediator.Send(new GetProductQuery(pageRequest)));
        }
        [HttpGet]
        public async Task<ActionResult<PageResult<ProductDto>>> GetProductsBasedOnCurrentDate([FromQuery] PageRequest pageRequest, [FromHeader(Name = "Accept-Language")] string acceptLanguage)
        {
            return Ok(await _mediator.Send(new GetProductBasedOnCurrentTimeQuery(pageRequest)));
        }
        [HttpGet("{productId:guid}")]
        public async Task<ActionResult<ProductDto>> GetById(Guid productId)
        {
            return Ok(await _mediator.Send(new GetProductByIdQuery(productId)));
        }
        [HttpDelete("{productId:guid}")]
        public async Task<IActionResult> Delete([FromQuery] Guid productId)
        {
            await _mediator.Publish(new DeleteProductCommand(productId));
            return Ok();
        }
        [HttpPut("{productId:guid}")]
        public async Task<ActionResult> Update(Guid productId, [FromBody] CreateProductDto createProductDto)
        {
            var updateProductDto = new UpdateProductDto(createProductDto, productId);
            await _mediator.Publish(new UpdateProductCommand(updateProductDto));
            return Ok();
        }
    }
}
