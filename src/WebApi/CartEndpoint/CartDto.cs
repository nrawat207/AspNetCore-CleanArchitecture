using System.Collections.Generic;

namespace WebApi.CartEndpoint
{
    public class CartDto
    {
        public long Id { get; set; }
        public IEnumerable<CartItemDto> Items { get; set; } = new List<CartItemDto>();
        public string CustomerId { get; set; }
    }
}
