using System.Text.Json.Serialization;

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
}
