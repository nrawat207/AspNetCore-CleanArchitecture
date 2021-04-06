using ApplicationCore.Interfaces;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;

namespace WebApi.CartEndpoint
{
    public class GetByUserId : BaseAsyncEndpoint
        .WithRequest<GetByUserIdCartRequest>
        .WithResponse<GetByUserIdCartResponse>
    {
        private readonly ICartService _cartService;
        private readonly IMapper _mapper;

        public GetByUserId(ICartService cartService, IMapper mapper)
        {
            _cartService = cartService;
            _mapper = mapper;

        }

        [HttpGet("api/cart/{UserId}")]
        [SwaggerOperation(
           Summary = "Get a Cart by User Id",
           Description = "Get a Cart by User Id",
           OperationId = "cart.GetByUserId",
           Tags = new[] { "CartEndpoints" })
       ]
        public override async Task<ActionResult<GetByUserIdCartResponse>> HandleAsync([FromRoute] GetByUserIdCartRequest request, CancellationToken cancellationToken = default)
        {
            var response = new GetByUserIdCartResponse(request.CorrelationId());

            var cart = await _cartService.GetOrCreateCart(request.UserId, cancellationToken);
            if (cart is null) return NotFound();

            var dto = _mapper.Map<CartDto>(cart);
            response.Cart = dto;

            return response;
        }
    }
}
