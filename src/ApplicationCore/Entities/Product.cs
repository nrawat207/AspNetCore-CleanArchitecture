using Ardalis.GuardClauses;
using System;

namespace ApplicationCore.Entities
{
    public class Product:BaseEntity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public string PictureUri { get; private set; }
        public long ProductTypeId { get; private set; }
        public ProductType ProductType { get; private set; }
        public int BrandId { get; private set; }
        public Brand Brand { get; private set; }

        public Product(int productTypeId,
            int brandId,
            string description,
            string name,
            decimal price,
            string pictureUri)
        {
            ProductTypeId = productTypeId;
            BrandId = brandId;
            Description = description;
            Name = name;
            Price = price;
            PictureUri = pictureUri;
        }

        public void UpdateDetails(string name, string description, decimal price)
        {
            Guard.Against.NullOrEmpty(name, nameof(name));
            Guard.Against.NullOrEmpty(description, nameof(description));
            Guard.Against.NegativeOrZero(price, nameof(price));

            Name = name;
            Description = description;
            Price = price;
        }

        public void UpdateBrand(int brandId)
        {
            Guard.Against.Zero(brandId, nameof(brandId));
            BrandId = brandId;
        }

        public void UpdateType(int productTypeId)
        {
            Guard.Against.Zero(productTypeId, nameof(productTypeId));
            ProductTypeId = productTypeId;
        }

        public void UpdatePictureUri(string pictureName)
        {
            if (string.IsNullOrEmpty(pictureName))
            {
                PictureUri = string.Empty;
                return;
            }
            PictureUri = $"images\\products\\{pictureName}?{new DateTime().Ticks}";
        }


    }
}
