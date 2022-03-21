
using System.ComponentModel.DataAnnotations;

namespace OutfitCreator.Model
{
    /// <summary>
    /// Represents ProductImage class object
    /// </summary>
    public class ProductImage
    {
        [Required]
        public string ImageUrl { get; set; }
        [Required]
        public string Resolution { get; set; }
        [Required]
        public string Frame { get; set; }
    }
}



