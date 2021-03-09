using System;
using System.Collections.Generic;

namespace WebApi.BrandEndpoint
{
    public class ListBrandResponse : BaseResponse
    {
        public ListBrandResponse(Guid correlationId) : base(correlationId)
        {
        }

        public ListBrandResponse()
        {
        }

        public List<BrandDto> Brands { get; set; } = new List<BrandDto>();
    }
}
