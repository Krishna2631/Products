using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Products.Domain.Entities;

namespace Products.Infrastructure.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            // Table Name
            builder.ToTable("Users");

            // Primary Key
            builder.HasKey(x => x.Id);

            // Properties
            builder.Property(x => x.FirstName)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(x => x.LastName)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(x => x.UserName)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(x => x.Email)
                   .IsRequired()
                   .HasMaxLength(255);

            builder.Property(x => x.PasswordHash)
                   .IsRequired();

            builder.Property(x => x.Role)
                   .IsRequired();

            // Audit Fields
            builder.Property(x => x.CreatedBy)
                   .IsRequired();

            builder.Property(x => x.CreatedOn)
                   .IsRequired();

            builder.Property(x => x.UpdatedBy);

            builder.Property(x => x.UpdatedOn);

            builder.Property(x => x.IsActive)
                   .HasDefaultValue(true);

            // Unique Constraints
            builder.HasIndex(x => x.Email)
                   .IsUnique();

            builder.HasIndex(x => x.UserName)
                   .IsUnique();

            // Relationship
            builder.HasMany(x => x.RefreshTokens)
                   .WithOne(x => x.User)
                   .HasForeignKey(x => x.UserId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}