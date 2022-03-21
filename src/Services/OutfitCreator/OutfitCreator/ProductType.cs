
using System.ComponentModel.DataAnnotations;

namespace OutfitCreator.Model
{
    public class ProductType 
    {
        [Required]
        public string TypeName { get; set; }
    }
}
