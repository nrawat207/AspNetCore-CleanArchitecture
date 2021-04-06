using ApplicationCore.Entities.CartAggregate;
using ApplicationCore.Interfaces;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;

namespace WebApi.CartEndpoint
{
    public class Delete : BaseAsyncEndpoint
    .WithRequest<DeleteCartRequest>
    .WithResponse<DeleteCartResponse>
    {
        private readonly IRepository<Cart> _cartRepository;

        public Delete(IRepository<Cart> cartRepository)
        {
            _cartRepository = cartRepository;
        }

        [HttpDelete("api/cart/{CartId}")]
        [SwaggerOperation(
            Summary = "Deletes a Cart",
            Description = "Deletes a Cart",
            OperationId = "cart.Delete",
            Tags = new[] { "CartEndpoints" })
        ]
        public override async Task<ActionResult<DeleteCartResponse>> HandleAsync([FromRoute] DeleteCartRequest request, CancellationToken cancellationToken = default)
        {
            var response = new DeleteCartResponse(request.CorrelationId());

            var cart = await _cartRepository.GetByIdAsync(request.CartId);
            if (cart is null) return NotFound();

            await _cartRepository.DeleteAsync(cart);

            return Ok(response);
        }
    }
}
