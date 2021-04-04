using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace WebApi.ProductEndpoint
{
    public class Update : BaseAsyncEndpoint
        .WithRequest<UpdateProductRequest>
        .WithResponse<UpdateProductResponse>
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IFileService _fileService;

        public Update(IRepository<Product> productRepository, IFileService fileService)
        {
            _productRepository = productRepository;
            _fileService = fileService;
        }

        [HttpPut("api/products")]
        [SwaggerOperation(
            Summary = "Updates a Product",
            Description = "Updates a Product",
            OperationId = "products.update",
            Tags = new[] { "ProductEndpoints" })
        ]
        public override async Task<ActionResult<UpdateProductResponse>> HandleAsync(UpdateProductRequest request, CancellationToken cancellationToken = default)
        {
            var response = new UpdateProductResponse(request.CorrelationId());

            var existingProduct = await _productRepository.GetByIdAsync(request.Id, cancellationToken);
            existingProduct.UpdateDetails(request.Name, request.Description, request.Price);
            existingProduct.UpdateBrand(request.BrandId);
            existingProduct.UpdateType(request.ProductTypeId);

            if (string.IsNullOrEmpty(request.PictureBase64) && string.IsNullOrEmpty(request.PictureUri))
            {
                existingProduct.UpdatePictureUri(string.Empty);
            }
            else
            {
                var picName = $"{existingProduct.Id}{Path.GetExtension(request.PictureName)}";
                if (await _fileService.SavePicture($"{picName}", request.PictureBase64, cancellationToken))
                {
                    existingProduct.UpdatePictureUri(picName);
                }
            }

            await _productRepository.UpdateAsync(existingProduct, cancellationToken);

            var dto = new ProductDto
            {
                Id = existingProduct.Id,
                BrandId = existingProduct.BrandId,
                ProductTypeId = existingProduct.ProductTypeId,
                Description = existingProduct.Description,
                Name = existingProduct.Name,
                PictureUri = existingProduct.PictureUri,
                Price = existingProduct.Price
            };
            response.Product = dto;

            return response;
        }
    }
}
