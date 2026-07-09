
using System.Text.Json;
using DatabaseLayer;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.Drug.Interfaces;
using Domain.Models;
namespace ServiceLayer.Drug
{
    public class DrugImportService : IDrugImportService
    {
        private readonly AppDbContext _context;

        public DrugImportService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> ImportFromJsonAsync(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException("File not found", filePath);

            var json = await File.ReadAllTextAsync(filePath);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var drugs = JsonSerializer.Deserialize<List<Domain.Models.Drug>>(json, options);

            if (drugs == null || drugs.Count == 0)
                return 0;

            //var existingNames = await _context.drugs
            //    .Select(d => d.CommercialNameEn)
            //    .ToListAsync();

            //var existingSet = existingNames
            //    .Where(x => x != null)
            //    .Select(x => x.ToLower())
            //    .ToHashSet();

            var newDrugs = new List<Domain.Models.Drug>();

            foreach (var drug in drugs)
            {
                if (string.IsNullOrWhiteSpace(drug.CommercialNameEn))
                    continue;

                var name = drug.CommercialNameEn.Trim();

                //if (existingSet.Contains(name.ToLower()))
                //    continue;
                drug.CommercialNameEn = name;
                drug.CommercialNameAr = drug.CommercialNameAr?.Trim();
                drug.ScientificName = drug.ScientificName?.Trim();
                drug.Manufacturer = drug.Manufacturer?.Trim();
                drug.DrugClass = drug.DrugClass?.Trim();
                drug.Route = drug.Route?.Trim();
                if (drug.Id == Guid.Empty)
                    drug.Id = Guid.NewGuid();

                newDrugs.Add(drug);
            }

            if (newDrugs.Count == 0)
                return 0;
            int take = 100;
            List<Domain.Models.Drug> drugsToadd =new List<Domain.Models.Drug>();


            for (int i=21300;i< 24818;i+=50)
            {
                
              
                await _context.Drugs.AddRangeAsync(newDrugs.Skip(i).Take(50).ToList());
                _context.SaveChanges();
               //await _context.Database.CloseConnectionAsync();
                Thread.Sleep(10000);
               //await _context.Database.OpenConnectionAsync();
                
            }


            return newDrugs.Count;
        }
    }
}
