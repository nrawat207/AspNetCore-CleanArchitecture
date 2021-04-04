namespace WebApi.ProductEndpoint
{
    public class ProductDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureUri { get; set; }
        public long ProductTypeId { get; set; }
        public int BrandId { get; set; }

    }
}
