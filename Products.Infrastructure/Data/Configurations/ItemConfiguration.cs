using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Products.Domain.Entities;

namespace Products.Infrastructure.Data.Configurations
{
    public class ItemConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            // Table Name
            builder.ToTable("Items");

            // Primary Key
            builder.HasKey(x => x.Id);

            // Properties
            builder.Property(x => x.Quantity)
                   .IsRequired();

            builder.Property(x => x.CreatedBy)
                   .IsRequired();

            builder.Property(x => x.CreatedOn)
                   .IsRequired();

            builder.Property(x => x.UpdatedBy);

            builder.Property(x => x.UpdatedOn);

            builder.Property(x => x.IsActive)
                   .HasDefaultValue(true);

            // Relationship
            builder.HasOne(x => x.Product)
                   .WithMany(x => x.Items)
                   .HasForeignKey(x => x.ProductId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}