using System;

namespace WebApi.CartEndpoint
{
    public class UpdateCartResponse:BaseResponse
    {
        public UpdateCartResponse(Guid correlationId) : base(correlationId)
        {
        }

        public UpdateCartResponse()
        {
        }

        public CartDto Cart { get; set; }
    }
}