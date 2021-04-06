using System;

namespace WebApi.CartEndpoint
{
    public class DeleteCartResponse:BaseResponse
    {
        public DeleteCartResponse(Guid correlationId) : base(correlationId)
        {
        }

        public DeleteCartResponse()
        {
        }

        public string Status { get; set; } = "Deleted";
    }
}