namespace WebApi.CartEndpoint
{
    public class CartItemDto
    {
        public long Id { get; set; }
        public int ProductId { get; set; }
        public int CartId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }        
    }
}
