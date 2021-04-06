using System;

namespace WebApi.CartEndpoint
{
    public class GetByUserIdCartResponse: BaseResponse
    {
        public GetByUserIdCartResponse(Guid correlationId) : base(correlationId)
        {
        }

        public GetByUserIdCartResponse()
        {
        }

        public CartDto Cart { get; set; }
    }
}