using System;

namespace WebApi.ProductEndpoint
{
    public class UpdateProductResponse:BaseResponse
    {
        public UpdateProductResponse(Guid correlationId) : base(correlationId)
        {
        }

        public UpdateProductResponse()
        {
        }

        public ProductDto Product { get; set; }
    }
}