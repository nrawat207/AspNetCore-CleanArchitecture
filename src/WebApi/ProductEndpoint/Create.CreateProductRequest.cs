namespace WebApi.ProductEndpoint
{
    public class CreateProductRequest:BaseRequest
    {
        public int BrandId { get; set; }
        public int ProductTypeId { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string PictureUri { get; set; }
        public string PictureBase64 { get; set; }
        public string PictureName { get; set; }
        public decimal Price { get; set; }
    }
}