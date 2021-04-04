namespace WebApi.ProductEndpoint
{
    public class GetByIdProductRequest:BaseRequest
    {
        public int ProductId { get; set; }
    }
}