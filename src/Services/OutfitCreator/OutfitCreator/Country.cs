
using System.ComponentModel.DataAnnotations;

namespace OutfitCreator.Model
{
    public class Country
    {
        [Required]
        public string CountryName { get; set; }
        [Required]
        public string CountryCode { get; set; }
    }
}
