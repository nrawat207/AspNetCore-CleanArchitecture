using System;
using System.Collections.Generic;

namespace WebApi.ProductEndpoint
{
    public class ListPagedProductResponse:BaseResponse
    {
        public ListPagedProductResponse(Guid correlationId) : base(correlationId)
        {
        }

        public ListPagedProductResponse()
        {
        }

        public List<ProductDto> Products { get; set; } = new List<ProductDto>();
        public int PageCount { get; set; }
    }
}