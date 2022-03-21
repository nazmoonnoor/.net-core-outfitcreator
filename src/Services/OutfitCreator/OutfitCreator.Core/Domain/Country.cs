using OutfitCreator.SharedKernel;
using OutfitCreator.SharedKernel.Interfaces;
using System;

namespace OutfitCreator.Core.Domain
{
    /// <summary>
    /// Represents Country class object
    /// </summary>
    public class Country: BaseEntity
    {
        public string CountryName { get; set; }
        public string CountryCode { get; set; }
    }
}
