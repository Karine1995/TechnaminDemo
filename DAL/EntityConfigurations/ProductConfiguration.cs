using DAL.Entities;
using DAL.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.EntityConfigurations
{
    internal class ProductConfiguration : EntityConfiguration<Product>
    {
        public override void Configure(EntityTypeBuilder<Product> builder)
        {
            base.Configure(builder);

            builder.ToTable("Products");

            builder.HasKey(u => u.Id)
                .IsClustered()
                .HasName("PK_Products_Id");

          
            builder.HasIndex(u => u.Name)
                .IsUnique()
                .HasDatabaseName("UK_Products_Name");

            builder.Property(u => u.Name)
                .IsRequired()
                .HasMaxLength(50);
                
            builder.Property(u => u.Price)
                .IsRequired()
                .HasPrecision(20, 4);

            builder.Property(u => u.Available)
                .IsRequired();

            builder.Property(u => u.Description)
                .IsRequired(false)
                .HasMaxLength(1000);

        }
    }
}
