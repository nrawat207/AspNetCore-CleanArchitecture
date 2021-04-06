namespace WebApi.CartEndpoint
{
    public class AddToCartRequest:BaseRequest
    {
        public string UserId { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string PictureUri { get; set; }
        public decimal Price { get; set; }
    }
}