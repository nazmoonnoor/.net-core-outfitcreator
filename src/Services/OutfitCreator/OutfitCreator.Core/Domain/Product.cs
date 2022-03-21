using Microsoft.EntityFrameworkCore.Infrastructure;
using OutfitCreator.SharedKernel;
using System;

namespace OutfitCreator.Core.Domain
{
    /// <summary>
    /// Represents Product class object
    /// </summary>
    public class Product : BaseEntity
    {
        private ILazyLoader LazyLoader { get; set; }
        private Country _country;
        private ProductGroup _productGroup;
        private ProductType _productType;
        private ProductImage _productImage;

        public Product()
        {

        }

        public Product(ILazyLoader lazyLoader)
        {
            LazyLoader = lazyLoader;
        }

        public string? Code { get; set; }
        public Gender Gender { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public float Price { get; set; }  = 0;
        public bool IsAvailable { get; set; }
        public Guid? CountryId { get; set; }
        public Guid? ProductGroupId { get; set; }
        public Guid? ProductTypeId { get; set; }

        public Guid? ProductImageId { get; set; }

        public virtual Country Country
        {
            get => LazyLoader.Load(this, ref _country);
            set => _country = value;
        }
        public virtual ProductGroup ProductGroup
        {
            get => LazyLoader.Load(this, ref _productGroup);
            set => _productGroup = value;
        }

        public virtual ProductType ProductType
        {
            get => LazyLoader.Load(this, ref _productType);
            set => _productType = value;
        }

        public virtual ProductImage ProductImage
        {
            get => LazyLoader.Load(this, ref _productImage);
            set => _productImage = value;
        }
    }
}
