using BackendService.Models;
using BackendService.Repositories.Contracts;

namespace BackendService.Services.Contracts
{
    public interface IPatientService : IPatientRepository
    {
        //Task<IEnumerable<dynamic>> GroupPatientsByLocation();
        //Task<IEnumerable<Patient>> SortAsc();
        //Task<IEnumerable<Patient>> SortDesc();
        //Task<IEnumerable<Patient>> GetPatientByLocation(string Location);
    }
}
