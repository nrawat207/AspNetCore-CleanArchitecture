namespace WebApi.CartEndpoint
{
    public class UpdateCartRequest:BaseRequest
    {
        
        public CartDto Cart { get; set; }

    }
}