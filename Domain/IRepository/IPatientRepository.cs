using DatabaseLayer.Models;
using Domain.Models;

namespace Domain.IRepository;

public interface IPatientRepository : IBaseRepository<Patient>
{
  
    public  Task<IEnumerable<Patient>> GetPatientsByCreateByAsync(Guid createBy);

    public Task<IEnumerable<Patient>> GetPatientsNew();

    
}
