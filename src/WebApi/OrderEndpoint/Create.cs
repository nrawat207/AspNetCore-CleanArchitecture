using ApplicationCore.Entities.OrderAggregate;
using ApplicationCore.Interfaces;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace WebApi.OrderEndpoint
{
    public class Create : BaseAsyncEndpoint
        .WithRequest<CreateOrderRequest>
        .WithResponse<CreateOrderResponse>
    {
        private readonly IOrderService _orderService;      

        public Create(IOrderService orderService)
        {
            _orderService = orderService;          
        }

        [HttpPost("api/order")]
        [SwaggerOperation(
            Summary = "Creates the order",
            Description = "Creates the order",
            OperationId = "order.create",
            Tags = new[] { "OrderEndpoints" })
        ]
        public override async Task<ActionResult<CreateOrderResponse>> HandleAsync(CreateOrderRequest request, CancellationToken cancellationToken = default)
        {
            var response = new CreateOrderResponse(request.CorrelationId());
            var shippingAddress = new Address(request.Street, request.City, request.State, request.Country, request.ZipCode);
            await _orderService.CreateOrderAsync(request.CartId, shippingAddress);

            return Ok(response);
        }
    }
}
