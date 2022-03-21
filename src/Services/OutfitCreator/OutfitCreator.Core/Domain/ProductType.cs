using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using OutfitCreator.SharedKernel;
using OutfitCreator.SharedKernel.Interfaces;
using System;

namespace OutfitCreator.Core.Domain
{
    /// <summary>
    /// Represents ProductType class object
    /// </summary>
    public class ProductType : BaseEntity
    {
        public string TypeName { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
