
using System.ComponentModel.DataAnnotations;

namespace OutfitCreator.Model
{
    /// <summary>
    /// Represents ProductGroup class object
    /// </summary>
    public class ProductGroup 
    {
        [Required]
        public string WebCategory { get; set; }
    }
}