using ApplicationCore.Entities.CartAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class CartConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            var navigation = builder.Metadata.FindNavigation(nameof(Cart.Items));
            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);

            builder.Property(c => c.CustomerId)
            .IsRequired()
            .HasMaxLength(40);
        }
    }
}
