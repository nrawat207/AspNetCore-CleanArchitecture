using System.ComponentModel.DataAnnotations;

namespace WebApi.ProductEndpoint
{
    public class UpdateProductRequest : BaseRequest
    {
        [Range(1, 10000)]
        public int Id { get; set; }
        [Range(1, 10000)]
        public int BrandId { get; set; }
        [Range(1, 10000)]
        public int ProductTypeId { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Name { get; set; }
        public string PictureBase64 { get; set; }
        public string PictureUri { get; set; }
        public string PictureName { get; set; }
        [Range(0.01, 10000)]
        public decimal Price { get; set; }
    }
}