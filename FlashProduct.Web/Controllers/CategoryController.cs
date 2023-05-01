using Application.CategoryUseCase.Command;
using Application.CategoryUseCase.Queries;
using Application.ProductUseCase.Queries;
using Domain.Dtos.Category;
using Domain.Dtos.Product;
using Domain.Repositries.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FlashProduct.Web.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<ActionResult<PageResult<CategoryDto>>> GetCategories([FromQuery] PageRequest pageRequest)
        {
            return Ok(await _mediator.Send(new GetCategoryQuery(pageRequest)));
        }
        [HttpGet("{categoryId:guid}/products")]
        public async Task<ActionResult<PageResult<ProductDto>>> GetCategoryProducts(Guid categoryId, [FromQuery] PageRequest pageRequest)
        {
            return Ok(await _mediator.Send(new GetProductByCategoryQuery(categoryId, pageRequest)));
        }
        [HttpDelete("{categoryId:guid}")]
        public async Task<ActionResult> DeleteCategory(Guid categoryId)
        {
            await _mediator.Publish(new DeleteCategoryCommand(categoryId));
            return Ok();
        }
    }
}
