
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OutfitCreator.Core.Domain;
using System;

namespace OutfitCreator.Infrastructure.Configuration
{
    public class ProductGroupConfiguration : IEntityTypeConfiguration<ProductGroup>
    {
        public void Configure(EntityTypeBuilder<ProductGroup> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.WebCategory).IsRequired();

            builder.HasData(
                new ProductGroup { Id = new Guid("fd698e16-dcc1-4891-b863-74904446e0d7"), WebCategory = "Accessories", Created = DateTime.UtcNow },
                new ProductGroup { Id = new Guid("cfc310f3-a8da-4f32-972a-6f12bf84199e"), WebCategory = "Blouses", Created = DateTime.UtcNow },
                new ProductGroup { Id = new Guid("abb4ee60-2f39-4c07-a0fb-3c156f2159dd"), WebCategory = "Sweatshirts", Created = DateTime.UtcNow },
                new ProductGroup { Id = new Guid("a3c7bfdb-23fc-487a-93a7-91f64f49c77c"), WebCategory = "Pants", Created = DateTime.UtcNow },
                new ProductGroup { Id = new Guid("1cdd9999-0963-49ef-98c4-93d21a3b9d38"), WebCategory = "Denim", Created = DateTime.UtcNow },

                new ProductGroup { Id = new Guid("67de6eba-2097-41b4-9d1b-f9d9aa4ff3c4"), WebCategory = "WCA01156", Created = DateTime.UtcNow },
                new ProductGroup { Id = new Guid("0e19d44e-217a-403a-88a5-349e6a7713a7"), WebCategory = "WCA01159", Created = DateTime.UtcNow },
                new ProductGroup { Id = new Guid("9a545b7a-bd39-45e8-980e-14e9b51189c6"), WebCategory = "WCA01155", Created = DateTime.UtcNow },
                new ProductGroup { Id = new Guid("060a878b-078d-479e-9d91-6d73b5c6d18b"), WebCategory = "WCA01152", Created = DateTime.UtcNow },
                new ProductGroup { Id = new Guid("e688b9fe-0247-4167-90c1-ae5bbbbe2d9c"), WebCategory = "WCA01158", Created = DateTime.UtcNow },
                new ProductGroup { Id = new Guid("f71a9dbd-8bfd-46a8-9316-1825f9684070"), WebCategory = "WCA01153", Created = DateTime.UtcNow },

                new ProductGroup { Id = new Guid("6f9e028c-e2d4-487a-9404-8abe0cd7b9b0"), WebCategory = "WCA00122", Created = DateTime.UtcNow },
                new ProductGroup { Id = new Guid("37423833-1ff7-407f-ac86-efbfc0bae2ab"), WebCategory = "WCA00121", Created = DateTime.UtcNow },

                new ProductGroup { Id = new Guid("21cdad5e-56fb-4fcf-84bb-4c9d53fd4b46"), WebCategory = "WCA00132", Created = DateTime.UtcNow },
                new ProductGroup { Id = new Guid("adfa898e-c67a-4a49-a154-bab1bc250d03"), WebCategory = "WCA00131", Created = DateTime.UtcNow },
                new ProductGroup { Id = new Guid("c7035d03-111c-4071-a27a-64bbabc53d32"), WebCategory = "WCA00172", Created = DateTime.UtcNow },
                new ProductGroup { Id = new Guid("b32ed022-7194-4381-b9c4-609a0f202477"), WebCategory = "WCA00173", Created = DateTime.UtcNow },

                new ProductGroup { Id = new Guid("09f0a1bd-77d9-4c76-a915-a49b93aefcbc"), WebCategory = "WCA02246", Created = DateTime.UtcNow },
                new ProductGroup { Id = new Guid("2a13b6aa-7fd4-4db9-a022-515938ab9071"), WebCategory = "WCA02242", Created = DateTime.UtcNow },
                new ProductGroup { Id = new Guid("bcbd6491-3eeb-4069-be99-869600137c6c"), WebCategory = "WCA02241", Created = DateTime.UtcNow },
                new ProductGroup { Id = new Guid("cd6017a8-33eb-421a-a642-e769d70ecf9f"), WebCategory = "WCA02243", Created = DateTime.UtcNow }
            );
        }
    }
}
