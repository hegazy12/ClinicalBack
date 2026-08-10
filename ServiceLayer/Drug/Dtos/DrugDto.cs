using System.Text.Json.Serialization;
using Domain.Models;
namespace ServiceLayer.Drug.Dtos
{
    public class DrugDto
    {
        public Guid Id { get; set; } 
        public string CommercialNameEn { get; set; }

        public string CommercialNameAr { get; set; }
        public string ScientificName { get; set; }
        public string Manufacturer { get; set; }
        public string DrugClass { get; set; }
        public string Route { get; set; }
        public decimal? PriceEgp { get; set; }
    }

    public static partial class AdHocMapper
    {
        public static DrugDto ToDrugDto(this Domain.Models.Drug drug)
        {
            return new DrugDto()
            {
                Id = drug.Id,
                CommercialNameAr = drug.CommercialNameAr,
                CommercialNameEn = drug.CommercialNameEn,
                DrugClass = drug.DrugClass,
                Manufacturer = drug.Manufacturer,
               // PriceEgp = drug.PriceEgp,
                Route = drug.Route,
                ScientificName = drug.ScientificName,
            };
        }
    }
}
