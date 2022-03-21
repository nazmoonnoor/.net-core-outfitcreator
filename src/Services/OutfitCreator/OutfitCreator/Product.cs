
using System.ComponentModel.DataAnnotations;

namespace OutfitCreator.Model
{
    /// <summary>
    /// Represents Product class object
    /// </summary>
    public class Product
    {
        [Required]
        public string Code { get; set; }
        
        public string? Name { get; set; }
        public Gender Gender { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public Country Country { get; set; }
        [Required]
        public float Price { get; set; }  = 0;
        [Required]
        public ProductType ProductType{ get; set; } = new ProductType();
        [Required]
        public bool IsAvailable { get; set; }
        [Required]
        public ProductImage? ProductImage { get; set; } = new ProductImage();
        [Required]
        public ProductGroup ProductGroup { get; set; } = new ProductGroup();
    }
}
