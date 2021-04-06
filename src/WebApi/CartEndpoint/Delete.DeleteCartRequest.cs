namespace WebApi.CartEndpoint
{
    public class DeleteCartRequest:BaseRequest
    {
        public long CartId { get; set; }
    }
}