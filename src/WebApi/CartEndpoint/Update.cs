using ApplicationCore.Interfaces;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WebApi.CartEndpoint
{
    public class Update : BaseAsyncEndpoint
        .WithRequest<UpdateCartRequest>
        .WithResponse<UpdateCartResponse>
    {
        private readonly ICartService _cartService;
        private readonly IMapper _mapper;


        public Update(ICartService cartService, IMapper mapper)
        {
            _cartService = cartService;
            _mapper = mapper;

        }

        [HttpPut("api/cart")]
        [SwaggerOperation(
            Summary = "Updates Cart",
            Description = "Updates Cart",
            OperationId = "cart.update",
            Tags = new[] { "CartEndpoints" })
        ]
        public override async Task<ActionResult<UpdateCartResponse>> HandleAsync(UpdateCartRequest request, CancellationToken cancellationToken = default)
        {
            var response = new UpdateCartResponse(request.CorrelationId());

            var updateItemQty = request.Cart.Items.ToDictionary(b => b.Id.ToString(), b => b.Quantity);
            await _cartService.SetQuantities(request.Cart.Id, updateItemQty);

            var cart = await _cartService.GetOrCreateCart(request.Cart.CustomerId);

            var dto = _mapper.Map<CartDto>(cart);
            response.Cart = dto;
            return response;
        }
    }
}
