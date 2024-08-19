using BackendService.Models;

namespace BackendService.Repositories.Contracts
{
    public interface IPatientRepository : IGenericRepository<Patient>
    {
        Task<IEnumerable<Patient>> SortByNameAsc();
        Task<IEnumerable<Patient>> SortByNameDesc();
        Task<IEnumerable<dynamic>> GroupByLocation();
        Task<IEnumerable<Patient>> GetPatientsByLoaction(string Location);
    }
}
