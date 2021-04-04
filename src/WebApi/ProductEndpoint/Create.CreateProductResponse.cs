using System;

namespace WebApi.ProductEndpoint
{
    public class CreateProductResponse : BaseResponse
    {
        public CreateProductResponse(Guid correlationId) : base(correlationId)
        {
        }

        public CreateProductResponse()
        {
        }

        public ProductDto Product { get; set; }
    }
}
