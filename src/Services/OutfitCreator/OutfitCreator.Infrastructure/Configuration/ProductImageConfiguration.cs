
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OutfitCreator.Core.Domain;
using System;

namespace OutfitCreator.Infrastructure.Configuration
{
    public class ProductImageConfiguration : IEntityTypeConfiguration<ProductImage>
    {
        public void Configure(EntityTypeBuilder<ProductImage> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.ImageUrl).IsRequired();

            builder.HasData(
                new ProductImage { Id = new Guid("6431e8e8-8644-4d70-bdcd-d61316da4494"), Resolution = "low", Frame = "1_1", ImageUrl = ".\\public\\images\\random_image.jpg", Created = DateTime.UtcNow },
                new ProductImage { Id = new Guid("d17e519c-99cb-4862-bdcf-3fe92cb457fa"), Resolution = "low", Frame = "1_1", ImageUrl = ".\\public\\images\\random_image.jpg", Created = DateTime.UtcNow },
                new ProductImage { Id = new Guid("535154ee-66f8-49fc-9d5b-c4f7c3146b29"), Resolution = "low", Frame = "1_1", ImageUrl = ".\\public\\images\\random_image.jpg", Created = DateTime.UtcNow },
                new ProductImage { Id = new Guid("383bce15-be2a-4a40-b288-5e67bd05d359"), Resolution = "mid", Frame = "2_3", ImageUrl = ".\\public\\images\\random_image.jpg", Created = DateTime.UtcNow },
                new ProductImage { Id = new Guid("03e4522c-f894-4f2f-b6be-8049c5961a35"), Resolution = "mid", Frame = "2_3", ImageUrl = ".\\public\\images\\random_image.jpg", Created = DateTime.UtcNow },
                new ProductImage { Id = new Guid("bbed4ad2-dd5e-459a-933f-b09e3c5e662a"), Resolution = "mid", Frame = "2_3", ImageUrl = ".\\public\\images\\random_image.jpg", Created = DateTime.UtcNow },
                new ProductImage { Id = new Guid("825d73b2-d986-49ac-8a51-4bb8d71ca6ce"), Resolution = "high", Frame = "2_3", ImageUrl = ".\\public\\images\\random_image.jpg", Created = DateTime.UtcNow },
                new ProductImage { Id = new Guid("31327a0b-14ec-4966-85dd-ee6650cc4569"), Resolution = "high", Frame = "9_16", ImageUrl = ".\\public\\images\\random_image.jpg", Created = DateTime.UtcNow },
                                                                                                                            
                new ProductImage { Id = new Guid("c7bff360-14d7-490e-b6e4-a3a81eccd334"), Resolution = "high", Frame = "9_16", ImageUrl = ".\\public\\images\\random_image.jpg", Created = DateTime.UtcNow },
                new ProductImage { Id = new Guid("3ea4bd58-1e8b-4a51-817a-c1e1455110ae"), Resolution = "high", Frame = "9_16", ImageUrl = ".\\public\\images\\random_image.jpg", Created = DateTime.UtcNow },
                new ProductImage { Id = new Guid("f408ad8c-1740-439c-a61b-a2d5acd30022"), Resolution = "higher", Frame = "9_16", ImageUrl = ".\\public\\images\\random_image.jpg", Created = DateTime.UtcNow },
                new ProductImage { Id = new Guid("1d18b480-765a-401f-8be7-0222e36f908e"), Resolution = "higher", Frame = "9_16", ImageUrl = ".\\public\\images\\random_image.jpg", Created = DateTime.UtcNow },
                new ProductImage { Id = new Guid("fa5267c1-d527-4a21-9647-df5bb088716a"), Resolution = "higher", Frame = "9_16", ImageUrl = ".\\public\\images\\random_image.jpg", Created = DateTime.UtcNow },
                new ProductImage { Id = new Guid("af3a007b-8722-4f8c-bb4f-dfdc4e75671c"), Resolution = "higher", Frame = "9_16", ImageUrl = ".\\public\\images\\random_image.jpg", Created = DateTime.UtcNow },
                new ProductImage { Id = new Guid("d7d2e620-8dd8-4f28-a569-48c2130dd70c"), Resolution = "higher", Frame = "9_16", ImageUrl = ".\\public\\images\\random_image.jpg", Created = DateTime.UtcNow },
                new ProductImage { Id = new Guid("c66d5f67-5f60-48d5-8d9d-9379fbb43460"), Resolution = "higher", Frame = "9_16", ImageUrl = ".\\public\\images\\random_image.jpg", Created = DateTime.UtcNow },
                new ProductImage { Id = new Guid("72b0b605-e3e0-41ad-8cb5-1ea7ea72bbb4"), Resolution = "higher", Frame = "9_16", ImageUrl = ".\\public\\images\\random_image.jpg", Created = DateTime.UtcNow }
            );
        }
    }
}
