using ApplicationCore.Entities.CartAggregate;
using ApplicationCore.Interfaces;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;

namespace WebApi.CartEndpoint
{
    public class AddToCart : BaseAsyncEndpoint
        .WithRequest<AddToCartRequest>
        .WithResponse<AddToCartResponse>
    {
        private readonly ICartService _cartService;
        private readonly IMapper _mapper;


        public AddToCart(ICartService cartService, IMapper mapper)
        {
            _cartService = cartService;
            _mapper = mapper;

        }

        [HttpPost("api/add-to-cart")]
        [SwaggerOperation(
            Summary = "Add items to cart",
            Description = "Add items to cart",
            OperationId = "cart.add",
            Tags = new[] { "CartEndpoints" })
        ]
        public override async Task<ActionResult<AddToCartResponse>> HandleAsync(AddToCartRequest request, CancellationToken cancellationToken = default)
        {
            var response = new AddToCartResponse(request.CorrelationId());

            var cart = await _cartService.GetOrCreateCart(request.UserId);
            await _cartService.AddItemToCart(cart.Id, request.Id, request.Price);
            cart = await _cartService.GetOrCreateCart(request.UserId);

            var dto = _mapper.Map<CartDto>(cart);
            response.Cart = dto;

            return response;
        }
    }
}
