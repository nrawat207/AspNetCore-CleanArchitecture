using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WebApi.ProductTypeEndpoint
{
    public class List : BaseAsyncEndpoint
        .WithoutRequest
        .WithResponse<ListProductTypeResponse>
    {
        private readonly IRepository<ProductType> _productTypeRepository;
        private readonly IMapper _mapper;

        public List(IRepository<ProductType> productTypeRepository,
            IMapper mapper)
        {
            _productTypeRepository = productTypeRepository;
            _mapper = mapper;
        }

        [HttpGet("api/product-types")]
        [SwaggerOperation(
            Summary = "List Product Types",
            Description = "List Product Types",
            OperationId = "product-types.List",
            Tags = new[] { "ProductTypeEndpoints" })
        ]
        public override async Task<ActionResult<ListProductTypeResponse>> HandleAsync(CancellationToken cancellationToken = default)
        {
            var response = new ListProductTypeResponse();

            var products = await _productTypeRepository.ListAllAsync(cancellationToken);

            response.productTypes.AddRange(products.Select(_mapper.Map<ProductTypeDto>));

            return Ok(response);

        }
    }
}
