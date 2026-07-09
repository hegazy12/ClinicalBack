using ServiceLayer.Drug.Dtos;


namespace ServiceLayer.Drug.Interfaces
{
    public interface IDrugService
    {
        public Task<List<DrugDto>> GetDrugsAsync(string SearchTerm);
    }
}
