using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OutfitCreator.Core.Domain;
using System;

namespace OutfitCreator.Infrastructure.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Description).IsRequired();

            builder.Property(c => c.Price).IsRequired();

            builder.HasOne(s => s.ProductImage)
            .WithMany(ad => ad.Products)
            .HasForeignKey(ad => ad.ProductImageId);

            builder.HasOne(s => s.ProductType)
            .WithMany(ad => ad.Products)
            .HasForeignKey(ad => ad.ProductTypeId);

            builder.HasOne(s => s.ProductGroup)
            .WithMany(ad => ad.Products)
            .HasForeignKey(ad => ad.ProductGroupId);

            builder.HasData(
                new
                {
                    Id = Guid.NewGuid(),
                    Code = "06.04.101.1636",
                    Price = 33.45F,
                    Description = "nunc viverra dapibus nulla",
                    Gender = Gender.Male,
                    CountryId = new Guid("caebd473-c4b6-4a3d-8e24-ff4769c8af6a"),
                    ProductGroupId = new Guid("67de6eba-2097-41b4-9d1b-f9d9aa4ff3c4"),
                    ProductTypeId = new Guid("c8528a09-c88f-4b09-b150-5437b2a66ac3"),
                    ProductImageId = new Guid("6431e8e8-8644-4d70-bdcd-d61316da4494"),
                    Created = DateTime.UtcNow,
                    IsAvailable = true
                },
                new
                {
                    Id = Guid.NewGuid(),
                    Code = "06.04.101.1636",
                    Price = 32.45F,
                    Description = "Tunc viverra dapibus nulla",
                    Gender = Gender.Female,
                    CountryId = new Guid("caebd473-c4b6-4a3d-8e24-ff4769c8af6a"),
                    ProductGroupId = new Guid("67de6eba-2097-41b4-9d1b-f9d9aa4ff3c4"),
                    ProductTypeId = new Guid("c8528a09-c88f-4b09-b150-5437b2a66ac3"),
                    ProductImageId = new Guid("6431e8e8-8644-4d70-bdcd-d61316da4494"),
                    Created = DateTime.UtcNow,
                    IsAvailable = true
                },
                new
                {
                    Id = Guid.NewGuid(),
                    Code = "03.04.101.1635",
                    Price = 23.45F,
                    Description = "volutpat convallis morbi odio",
                    Gender = Gender.Male,
                    CountryId = new Guid("caebd473-c4b6-4a3d-8e24-ff4769c8af6a"),
                    ProductGroupId = new Guid("0e19d44e-217a-403a-88a5-349e6a7713a7"),
                    ProductTypeId = new Guid("c8528a09-c88f-4b09-b150-5437b2a66ac3"),
                    ProductImageId = new Guid("6431e8e8-8644-4d70-bdcd-d61316da4494"),
                    Created = DateTime.UtcNow,
                    IsAvailable = true
                },
                new
                {
                    Id = Guid.NewGuid(),
                    Code = "01.04.101.1233",
                    Price = 12.45F,
                    Description = "platea dictumst aliquam augue quam",
                    Gender = Gender.Male,
                    CountryId = new Guid("caebd473-c4b6-4a3d-8e24-ff4769c8af6a"),
                    ProductGroupId = new Guid("67de6eba-2097-41b4-9d1b-f9d9aa4ff3c4"),
                    ProductTypeId = new Guid("c8528a09-c88f-4b09-b150-5437b2a66ac3"),
                    ProductImageId = new Guid("6431e8e8-8644-4d70-bdcd-d61316da4494"),
                    Created = DateTime.UtcNow,
                    IsAvailable = true
                },
                new
                {
                    Id = Guid.NewGuid(),
                    Code = "19.04.101.1621",
                    Price = 43.45F,
                    Description = "at vulputate vitae nisl",
                    Gender = Gender.Male,
                    CountryId = new Guid("caebd473-c4b6-4a3d-8e24-ff4769c8af6a"),
                    ProductGroupId = new Guid("0e19d44e-217a-403a-88a5-349e6a7713a7"),
                    ProductTypeId = new Guid("47861db8-56d6-4b79-9ff9-90e7d01c77f4"),
                    ProductImageId = new Guid("72b0b605-e3e0-41ad-8cb5-1ea7ea72bbb4"),
                    Created = DateTime.UtcNow,
                    IsAvailable = true
                },
                new
                {
                    Id = Guid.NewGuid(),
                    Code = "08.08.101.1639",
                    Price = 39.45F,
                    Description = "habitasse platea dictumst etiam",
                    Gender = Gender.Male,
                    CountryId = new Guid("caebd473-c4b6-4a3d-8e24-ff4769c8af6a"),
                    ProductGroupId = new Guid("9a545b7a-bd39-45e8-980e-14e9b51189c6"),
                    ProductTypeId = new Guid("47861db8-56d6-4b79-9ff9-90e7d01c77f4"),
                    ProductImageId = new Guid("c66d5f67-5f60-48d5-8d9d-9379fbb43460"),
                    Created = DateTime.UtcNow,
                    IsAvailable = true
                }, 
                new
                {
                    Id = Guid.NewGuid(),
                    Code = "07.04.101.1566",
                    Price = 51.45F,
                    Description = "quis justo maecenas rhoncus",
                    Gender = Gender.Male,
                    CountryId = new Guid("caebd473-c4b6-4a3d-8e24-ff4769c8af6a"),
                    ProductGroupId = new Guid("9a545b7a-bd39-45e8-980e-14e9b51189c6"),
                    ProductTypeId = new Guid("47861db8-56d6-4b79-9ff9-90e7d01c77f4"),
                    ProductImageId = new Guid("d7d2e620-8dd8-4f28-a569-48c2130dd70c"),
                    Created = DateTime.UtcNow,
                    IsAvailable = true
                },
                new
                {
                    Id = Guid.NewGuid(),
                    Code = "07.04.151.1652",
                    Price = 11.45F,
                    Description = "phasellus in felis donec",
                    Gender = Gender.Female,
                    CountryId = new Guid("caebd473-c4b6-4a3d-8e24-ff4769c8af6a"),
                    ProductGroupId = new Guid("6f9e028c-e2d4-487a-9404-8abe0cd7b9b0"),
                    ProductImageId = new Guid("af3a007b-8722-4f8c-bb4f-dfdc4e75671c"),
                    ProductTypeId = new Guid("47861db8-56d6-4b79-9ff9-90e7d01c77f4"),
                    Created = DateTime.UtcNow,
                    IsAvailable = true
                },
                new
                {
                    Id = Guid.NewGuid(),
                    Code = "78.04.101.1854",
                    Price = 21.45F,
                    Description = "odio odio elementum eu",
                    Gender = Gender.Female,
                    CountryId = new Guid("caebd473-c4b6-4a3d-8e24-ff4769c8af6a"),
                    ProductGroupId = new Guid("6f9e028c-e2d4-487a-9404-8abe0cd7b9b0"),
                    ProductImageId = new Guid("fa5267c1-d527-4a21-9647-df5bb088716a"),
                    ProductTypeId = new Guid("47861db8-56d6-4b79-9ff9-90e7d01c77f4"),
                    Created = DateTime.UtcNow,
                    IsAvailable = true
                },
                new
                {
                    Id = Guid.NewGuid(),
                    Code = "66.04.101.8536",
                    Price = 51.45F,
                    Description = "lobortis est phasellus sit amet",
                    Gender = Gender.Female,
                    CountryId = new Guid("caebd473-c4b6-4a3d-8e24-ff4769c8af6a"),
                    ProductGroupId = new Guid("37423833-1ff7-407f-ac86-efbfc0bae2ab"),
                    ProductTypeId = new Guid("47861db8-56d6-4b79-9ff9-90e7d01c77f4"),
                    ProductImageId = new Guid("1d18b480-765a-401f-8be7-0222e36f908e"),
                    Created = DateTime.UtcNow,
                    IsAvailable = true
                },
                new
                {
                    Id = Guid.NewGuid(),
                    Code = "12.04.101.1786",
                    Price = 22.45F,
                    Description = "quam pede lobortis ligula sit",
                    Gender = Gender.Female,
                    CountryId = new Guid("caebd473-c4b6-4a3d-8e24-ff4769c8af6a"),
                    ProductGroupId = new Guid("37423833-1ff7-407f-ac86-efbfc0bae2ab"),
                    ProductTypeId = new Guid("47861db8-56d6-4b79-9ff9-90e7d01c77f4"),
                    ProductImageId = new Guid("f408ad8c-1740-439c-a61b-a2d5acd30022"),
                    Created = DateTime.UtcNow,
                    IsAvailable = true
                },
                new
                {
                    Id = Guid.NewGuid(),
                    Code = "46.04.101.4566",
                    Price = 11.45F,
                    Description = "erat tortor sollicitudin mi sit",
                    Gender = Gender.Female,
                    CountryId = new Guid("caebd473-c4b6-4a3d-8e24-ff4769c8af6a"),
                    ProductGroupId = new Guid("21cdad5e-56fb-4fcf-84bb-4c9d53fd4b46"),
                    ProductTypeId = new Guid("47861db8-56d6-4b79-9ff9-90e7d01c77f4"),
                    ProductImageId = new Guid("3ea4bd58-1e8b-4a51-817a-c1e1455110ae"),
                    Created = DateTime.UtcNow,
                    IsAvailable = true
                },
                new
                {
                    Id = Guid.NewGuid(),
                    Code = "88.04.551.5536",
                    Price = 14.45F,
                    Description = "sed sagittis nam congue risus",
                    Gender = Gender.Female,
                    CountryId = new Guid("caebd473-c4b6-4a3d-8e24-ff4769c8af6a"),
                    ProductGroupId = new Guid("21cdad5e-56fb-4fcf-84bb-4c9d53fd4b46"),
                    ProductTypeId = new Guid("dce52991-2683-4ad6-ae5c-43a5b556d0f5"),
                    ProductImageId = new Guid("c7bff360-14d7-490e-b6e4-a3a81eccd334"),
                    Created = DateTime.UtcNow,
                    IsAvailable = true
                },





                new
                {
                    Id = Guid.NewGuid(),
                    Code = "32.04.101.1242",
                    Price = 32.45F,
                    Description = "vel pede morbi porttitor lorem",
                    Gender = Gender.Male,
                    CountryId = new Guid("caebd473-c4b6-4a3d-8e24-ff4769c8af6a"),
                    ProductGroupId = new Guid("adfa898e-c67a-4a49-a154-bab1bc250d03"),
                    ProductTypeId = new Guid("dce52991-2683-4ad6-ae5c-43a5b556d0f5"),
                    ProductImageId = new Guid("31327a0b-14ec-4966-85dd-ee6650cc4569"),
                    Created = DateTime.UtcNow,
                    IsAvailable = true
                },
                new
                {
                    Id = Guid.NewGuid(),
                    Code = "64.04.151.1434",
                    Price = 31.45F,
                    Description = "nascetur ridiculus mus vivamus vestibulum",
                    Gender = Gender.Female,
                    CountryId = new Guid("caebd473-c4b6-4a3d-8e24-ff4769c8af6a"),
                    ProductGroupId = new Guid("adfa898e-c67a-4a49-a154-bab1bc250d03"),
                    ProductTypeId = new Guid("dce52991-2683-4ad6-ae5c-43a5b556d0f5"),
                    ProductImageId = new Guid("825d73b2-d986-49ac-8a51-4bb8d71ca6ce"),
                    Created = DateTime.UtcNow,
                    IsAvailable = true
                },
                new
                {
                    Id = Guid.NewGuid(),
                    Code = "34.04.101.4242",
                    Price = 67.45F,
                    Description = "adipiscing elit proin risus praesent",
                    Gender = Gender.Female,
                    CountryId = new Guid("caebd473-c4b6-4a3d-8e24-ff4769c8af6a"),
                    ProductGroupId = new Guid("c7035d03-111c-4071-a27a-64bbabc53d32"),
                    ProductTypeId = new Guid("dce52991-2683-4ad6-ae5c-43a5b556d0f5"),
                    ProductImageId = new Guid("bbed4ad2-dd5e-459a-933f-b09e3c5e662a"),
                    Created = DateTime.UtcNow,
                    IsAvailable = true
                },
                new
                {
                    Id = Guid.NewGuid(),
                    Code = "52.04.122.8536",
                    Price = 56.45F,
                    Description = "aenean sit amet justo morbi",
                    Gender = Gender.Female,
                    ProductGroupId = new Guid("c7035d03-111c-4071-a27a-64bbabc53d32"),
                    ProductTypeId = new Guid("dce52991-2683-4ad6-ae5c-43a5b556d0f5"),
                    ProductImageId = new Guid("03e4522c-f894-4f2f-b6be-8049c5961a35"),
                    Created = DateTime.UtcNow,
                    IsAvailable = true
                },
                new
                {
                    Id = Guid.NewGuid(),
                    Code = "15.04.101.1543",
                    Price = 22.45F,
                    Description = "orci luctus et ultrices posuere",
                    Gender = Gender.Female,
                    CountryId = new Guid("caebd473-c4b6-4a3d-8e24-ff4769c8af6a"),
                    ProductGroupId = new Guid("09f0a1bd-77d9-4c76-a915-a49b93aefcbc"),
                    ProductTypeId = new Guid("c8528a09-c88f-4b09-b150-5437b2a66ac3"),
                    ProductImageId = new Guid("383bce15-be2a-4a40-b288-5e67bd05d359"),
                    Created = DateTime.UtcNow,
                    IsAvailable = true
                },
                new
                {
                    Id = Guid.NewGuid(),
                    Code = "52.04.101.4535",
                    Price = 21.45F,
                    Description = "facilisi cras non velit nec",
                    Gender = Gender.Female,
                    CountryId = new Guid("caebd473-c4b6-4a3d-8e24-ff4769c8af6a"),
                    ProductGroupId = new Guid("09f0a1bd-77d9-4c76-a915-a49b93aefcbc"),
                    ProductTypeId = new Guid("c8528a09-c88f-4b09-b150-5437b2a66ac3"),
                    ProductImageId = new Guid("535154ee-66f8-49fc-9d5b-c4f7c3146b29"),
                    Created = DateTime.UtcNow,
                    IsAvailable = true
                },
                new
                {
                    Id = Guid.NewGuid(),
                    Code = "42.04.551.2556",
                    Price = 11.45F,
                    Description = "at diam nam tristique",
                    Gender = Gender.Female,
                    CountryId = new Guid("caebd473-c4b6-4a3d-8e24-ff4769c8af6a"),
                    ProductGroupId = new Guid("2a13b6aa-7fd4-4db9-a022-515938ab9071"),
                    ProductTypeId = new Guid("c8528a09-c88f-4b09-b150-5437b2a66ac3"),
                    ProductImageId = new Guid("d17e519c-99cb-4862-bdcf-3fe92cb457fa"),
                    Created = DateTime.UtcNow,
                    IsAvailable = true
                }
            );
        }
    }
}
