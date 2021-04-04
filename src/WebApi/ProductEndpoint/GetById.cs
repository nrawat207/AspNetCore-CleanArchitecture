using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace WebApi.ProductEndpoint
{
    public class GetById : BaseAsyncEndpoint
        .WithRequest<GetByIdProductRequest>
        .WithResponse<GetByIdProductResponse>
    {
        private readonly IRepository<Product> _productRepository;

        public GetById(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet("api/products/{ProductId}")]
        [SwaggerOperation(
           Summary = "Get a Product by Id",
           Description = "Gets a Product by Id",
           OperationId = "product.GetById",
           Tags = new[] { "ProductEndpoints" })
       ]
        public override async Task<ActionResult<GetByIdProductResponse>> HandleAsync([FromRoute] GetByIdProductRequest request, CancellationToken cancellationToken = default)
        {
            var response = new GetByIdProductResponse(request.CorrelationId());

            var product = await _productRepository.GetByIdAsync(request.ProductId, cancellationToken);
            if (product is null) return NotFound();

            response.Product= new ProductDto
            {
                Id = product.Id,
                BrandId = product.BrandId,
                ProductTypeId = product.ProductTypeId,
                Description = product.Description,
                Name = product.Name,
                PictureUri = product.PictureUri,
                Price = product.Price
            };
            return Ok(response);
        }
    }
}
