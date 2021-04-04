using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using ApplicationCore.Specifications;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WebApi.ProductEndpoint
{
    public class ListPaged : BaseAsyncEndpoint
        .WithRequest<ListPagedProductRequest>
        .WithResponse<ListPagedProductResponse>
    {
        private readonly IRepository<Product> _productRepository;        
        private readonly IMapper _mapper;

        public ListPaged(IRepository<Product> productRepository,IMapper mapper)
        {
            _productRepository = productRepository;  
            _mapper = mapper;
        }

        [HttpGet("api/products")]
        [SwaggerOperation(
            Summary = "List Products (paged)",
            Description = "List Products (paged)",
            OperationId = "products.ListPaged",
            Tags = new[] { "ProductEndpoints" })
        ]
        public override async Task<ActionResult<ListPagedProductResponse>> HandleAsync([FromQuery] ListPagedProductRequest request, CancellationToken cancellationToken = default)
        {
            var response = new ListPagedProductResponse(request.CorrelationId());
            var filterSpec = new ProductListFilterSpecification(request.BrandId, request.ProductTypeId);
            int totalItems = await _productRepository.CountAsync(filterSpec, cancellationToken);

            var pagedSpec = new ProductListFilterPaginatedSpecification(
            skip: request.PageIndex * request.PageSize,
            take: request.PageSize,
            brandId: request.BrandId,
            typeId: request.ProductTypeId
            );

            var productList = await _productRepository.ListAsync(pagedSpec, cancellationToken);
            response.Products.AddRange(productList.Select(_mapper.Map<ProductDto>));
            response.PageCount = int.Parse(Math.Ceiling((decimal)totalItems / request.PageSize).ToString());
            return Ok(response);
        }
    }
}
