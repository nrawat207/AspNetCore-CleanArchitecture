namespace WebApi.ProductEndpoint
{
    public class ListPagedProductRequest:BaseRequest
    {
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public int? BrandId { get; set; }
        public int? ProductTypeId { get; set; }
    }
}