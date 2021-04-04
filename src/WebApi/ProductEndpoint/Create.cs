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
    public class Create : BaseAsyncEndpoint
        .WithRequest<CreateProductRequest>
        .WithResponse<CreateProductResponse>
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IFileService _fileService;

        public Create(IRepository<Product> productRepository, IFileService fileService)
        {
            _productRepository = productRepository;
            _fileService = fileService;
        }

        [HttpPost("api/products")]
        [SwaggerOperation(
            Summary = "Creates a new Product Item",
            Description = "Creates a new Product Item",
            OperationId = "product.create",
            Tags = new[] { "ProductEndpoints" })
        ]
        public override async Task<ActionResult<CreateProductResponse>> HandleAsync(CreateProductRequest request, CancellationToken cancellationToken = default)
        {
            var response = new CreateProductResponse(request.CorrelationId());
            var newProduct = new Product(request.ProductTypeId, request.BrandId,request.Description, request.Name, request.Price, request.PictureUri);
            newProduct = await _productRepository.AddAsync(newProduct, cancellationToken);

            if(newProduct.Id != 0)
            {
                var picName = $"{newProduct.Id}{Path.GetExtension(request.PictureName)}";
                if(await _fileService.SavePicture(picName, request.PictureBase64, cancellationToken))
                {
                    newProduct.UpdatePictureUri(picName);
                    await _productRepository.UpdateAsync(newProduct, cancellationToken);
                }
            }

            var dto = new ProductDto
            {
                Id = newProduct.Id,
                BrandId = newProduct.BrandId,
                ProductTypeId = newProduct.ProductTypeId,
                Description = newProduct.Description,
                Name = newProduct.Name,
                PictureUri = newProduct.PictureUri,
                Price = newProduct.Price
            };

            response.Product = dto;
            return response;
        }
    }
}
