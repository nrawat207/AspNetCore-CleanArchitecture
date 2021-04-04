using System;

namespace WebApi.ProductEndpoint
{
    public class DeleteProductResponse:BaseResponse
    {
        public DeleteProductResponse(Guid correlationId) : base(correlationId)
        {
        }

        public DeleteProductResponse()
        {
        }

        public string Status { get; set; } = "Deleted";
    }
}