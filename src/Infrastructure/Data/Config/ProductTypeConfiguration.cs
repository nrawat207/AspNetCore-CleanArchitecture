using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class ProductTypeConfiguration : IEntityTypeConfiguration<ProductType>
    {
        public void Configure(EntityTypeBuilder<ProductType> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
               .UseHiLo("product_type_hilo")
               .IsRequired();

            builder.Property(p => p.Type)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
