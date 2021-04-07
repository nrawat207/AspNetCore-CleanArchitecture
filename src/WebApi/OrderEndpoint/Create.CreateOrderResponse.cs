using System;

namespace WebApi.OrderEndpoint
{
    public class CreateOrderResponse:BaseResponse
    {
        public CreateOrderResponse(Guid correlationId) : base(correlationId)
        {
        }

        public CreateOrderResponse()
        {
        }

        public string Status { get; set; } = "Created";
    }
}