﻿using Ardalis.GuardClauses;

namespace ApplicationCore.Entities.OrderAggregate
{
    public class ProductOrdered //Value Object
    {
        public ProductOrdered(long productId, string productName, string pictureUri)
        {
            Guard.Against.Zero(productId, nameof(productId));
            Guard.Against.NullOrEmpty(productName, nameof(productName));
            Guard.Against.NullOrEmpty(pictureUri, nameof(pictureUri));

            ProductId = productId;
            ProductName = productName;
            PictureUri = pictureUri;
        }

        private ProductOrdered()
        {
            // required by EF
        }

        public long ProductId { get; private set; }
        public string ProductName { get; private set; }
        public string PictureUri { get; private set; }
    }
}
