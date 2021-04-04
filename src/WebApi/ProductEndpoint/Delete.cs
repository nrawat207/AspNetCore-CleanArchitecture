using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;

namespace WebApi.ProductEndpoint
{
    public class Delete : BaseAsyncEndpoint
    .WithRequest<DeleteProductRequest>
    .WithResponse<DeleteProductResponse>
    {

        private readonly IRepository<Product> _productRepository;

        public Delete(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpDelete("api/products/{ProductId}")]
        [SwaggerOperation(
            Summary = "Deletes a Product",
            Description = "Deletes a Product",
            OperationId = "products.Delete",
            Tags = new[] { "ProductEndpoints" })
        ]
        public override async Task<ActionResult<DeleteProductResponse>> HandleAsync([FromRoute] DeleteProductRequest request, CancellationToken cancellationToken = default)
        {
            var response = new DeleteProductResponse(request.CorrelationId());

            var itemToDelete = await _productRepository.GetByIdAsync(request.ProductId, cancellationToken);
            if (itemToDelete is null) return NotFound();

            await _productRepository.DeleteAsync(itemToDelete, cancellationToken);

            return Ok(response);
        }
    }
}
