namespace ServiceLayer.Drug.Interfaces
{
    public interface IDrugImportService
    {
        Task<int> ImportFromJsonAsync(string filePath);
    }
}
