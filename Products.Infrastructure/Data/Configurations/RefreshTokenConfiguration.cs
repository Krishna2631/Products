using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Products.Domain.Entities;

namespace Products.Infrastructure.Data.Configurations
{
    public class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
    {
        public void Configure(EntityTypeBuilder<RefreshToken> builder)
        {
            // Table Name
            builder.ToTable("RefreshTokens");

            // Primary Key
            builder.HasKey(x => x.Id);

            // Properties
            builder.Property(x => x.Token)
                   .IsRequired()
                   .HasMaxLength(500);

            builder.Property(x => x.Expires)
                   .IsRequired();

            builder.Property(x => x.Created)
                   .IsRequired();

            builder.Property(x => x.Revoked);

            // Audit Fields
            builder.Property(x => x.CreatedBy)
                   .IsRequired();

            builder.Property(x => x.CreatedOn)
                   .IsRequired();

            builder.Property(x => x.UpdatedBy);

            builder.Property(x => x.UpdatedOn);

            builder.Property(x => x.IsActive)
                   .HasDefaultValue(true);

            // Relationship
            builder.HasOne(x => x.User)
                   .WithMany(x => x.RefreshTokens)
                   .HasForeignKey(x => x.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Index
            builder.HasIndex(x => x.Token)
                   .IsUnique();
        }
    }
}