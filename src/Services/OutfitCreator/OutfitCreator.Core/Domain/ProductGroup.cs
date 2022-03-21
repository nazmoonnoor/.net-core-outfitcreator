using OutfitCreator.SharedKernel;
using System;
using System.Collections.Generic;

namespace OutfitCreator.Core.Domain
{
    /// <summary>
    /// Represents ProductGroup class object
    /// </summary>
    public class ProductGroup : BaseEntity
    {
        public string WebCategory { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}



