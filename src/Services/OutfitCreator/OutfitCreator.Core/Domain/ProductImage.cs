using OutfitCreator.SharedKernel;
using System;
using System.Collections.Generic;

namespace OutfitCreator.Core.Domain
{
    /// <summary>
    /// Represents ProductImage class object
    /// </summary>
    public class ProductImage : BaseEntity
    {
        public string ImageUrl { get; set; }
        public string Resolution { get; set; }
        public string Frame{ get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}



