using System;

namespace WebApi.CartEndpoint
{
    public class AddToCartResponse : BaseResponse
    {
        public AddToCartResponse(Guid correlationId) : base(correlationId)
        {
        }

        public AddToCartResponse()
        {
        }

        public CartDto Cart { get; set; }
    }
}