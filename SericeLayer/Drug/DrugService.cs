using Domain.IRepository;
using ServiceLayer.Drug.Dtos;
using ServiceLayer.Drug.Interfaces;
using Domain.Models;
using Domain.IUnitOfWork;

namespace ServiceLayer.Drug
{
    public class DrugService : IDrugService
    {
        private readonly IUnitOfWork _unitOfWork;
        public DrugService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
      public async Task<List<DrugDto>> GetDrugsAsync(string SearchTerm)
        {
           var drugs=await _unitOfWork.DrugRepository.FindAllAsync(d => d.CommercialNameEn.Contains(SearchTerm) || d.CommercialNameAr.Contains(SearchTerm));

            var res = drugs.Select(d => new DrugDto { 
            Id = d.Id,
            Manufacturer = d.Manufacturer,
            CommercialNameAr=d.CommercialNameAr,
            DrugClass = d.DrugClass,
            CommercialNameEn=d.CommercialNameEn,
            PriceEgp=d.PriceEgp,
            ScientificName=d.ScientificName,
            Route=d.Route
            }).ToList();
            return res;

        }


    }
}
