using System;

namespace WebApi.ProductEndpoint
{
    public class GetByIdProductResponse:BaseResponse
    {
        public GetByIdProductResponse(Guid correlationId) : base(correlationId)
        {
        }

        public GetByIdProductResponse()
        {
        }

        public ProductDto Product { get; set; }
    }
}