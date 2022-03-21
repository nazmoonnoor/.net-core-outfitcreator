
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OutfitCreator.Core.Domain;
using System;

namespace OutfitCreator.Infrastructure.Configuration
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.CountryName).IsRequired();
            builder.Property(c => c.CountryCode).IsRequired();

            builder.HasData(
                new Country { Id = new Guid("caebd473-c4b6-4a3d-8e24-ff4769c8af6a"), CountryName = "Germany", CountryCode = "DE", Created = DateTime.UtcNow },
                new Country { Id = Guid.NewGuid(), CountryName = "France", CountryCode = "FR", Created = DateTime.UtcNow },
                new Country { Id = Guid.NewGuid(), CountryName = "United Kingdom", CountryCode = "UK", Created = DateTime.UtcNow },
                new Country { Id = Guid.NewGuid(), CountryName = "Netherlands", CountryCode = "NL", Created = DateTime.UtcNow },
                new Country { Id = Guid.NewGuid(), CountryName = "Norway", CountryCode = "NO", Created = DateTime.UtcNow }
            );
        }
    }
}
