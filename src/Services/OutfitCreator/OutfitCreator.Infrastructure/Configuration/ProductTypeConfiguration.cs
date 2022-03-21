
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OutfitCreator.Core.Domain;
using System;

namespace OutfitCreator.Infrastructure.Configuration
{
    public class ProductTypeConfiguration : IEntityTypeConfiguration<ProductType>
    {
        public void Configure(EntityTypeBuilder<ProductType> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.TypeName).IsRequired();

            //builder.HasOne<Product>(s => s.Product)
            //.WithOne(ad => ad.ProductType)
            //.HasForeignKey<Product>(ad => ad.ProductTypeId);

            builder.HasData(
                new ProductType { Id = new Guid("c8528a09-c88f-4b09-b150-5437b2a66ac3"), TypeName = "Outerwear", Created = DateTime.UtcNow },
                new ProductType { Id = new Guid("47861db8-56d6-4b79-9ff9-90e7d01c77f4"), TypeName = "Underwear", Created = DateTime.UtcNow },
                new ProductType { Id = new Guid("dce52991-2683-4ad6-ae5c-43a5b556d0f5"), TypeName = "Accessories", Created = DateTime.UtcNow }
            );
        }
    }
}
