using System;
using System.Collections.Generic;

namespace WebApi.ProductTypeEndpoint
{
    public class ListProductTypeResponse : BaseResponse
    {
        public ListProductTypeResponse(Guid correlationId) : base(correlationId)
        {
        }

        public ListProductTypeResponse()
        {
        }

        public List<ProductTypeDto> productTypes { get; set; } = new List<ProductTypeDto>();
    }
}