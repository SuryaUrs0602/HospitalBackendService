using BackendService.Models;
using BackendService.Repositories.Contracts;
using BackendService.Services.Contracts;

namespace BackendService.Services
{
    public class PatientService : IPatientService
    {

        private readonly IPatientRepository _repository;

        public PatientService(IPatientRepository repository)
        {
            _repository = repository;
        }

        public async Task AddData(Patient obj)
        {
            await _repository.AddData(obj);
        }

        public async Task DeleteData(object ID)
        {
            await _repository.DeleteData(ID);
        }

        public async Task EditData(object ID, Patient obj)
        {
            await _repository.EditData(ID, obj);
        }

        public async Task<List<Patient>> GetAllData()
        {
            return await _repository.GetAllData();
        }

        public async Task<Patient> GetData(object ID)
        {
            return await _repository.GetData(ID);
        }

        public async Task<IEnumerable<Patient>> GetPatientsByLoaction(string Location)
        {
            return await _repository.GetPatientsByLoaction(Location);
        }

        public async Task<IEnumerable<dynamic>> GroupByLocation()
        {
            return await _repository.GroupByLocation();
        }

        public async Task<IEnumerable<Patient>> SortByNameAsc()
        {
            return await _repository.SortByNameAsc();
        }

        public async Task<IEnumerable<Patient>> SortByNameDesc()
        {
            return await _repository.SortByNameDesc();
        }
    }
}
