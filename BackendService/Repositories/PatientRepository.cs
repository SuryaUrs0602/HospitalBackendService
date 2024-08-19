using BackendService.Models;
using BackendService.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace BackendService.Repositories
{
    public class PatientRepository : GenericRepository<Patient>, IPatientRepository
    {
        private readonly HospitalDbContext _dbContext;

        public PatientRepository(HospitalDbContext dbContext) : base(dbContext) 
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Patient>> GetPatientsByLoaction(string Location)
        {
            return await _dbContext.Patients.Where(patient => patient.Location == Location).ToListAsync();
        }

        public async Task<IEnumerable<dynamic>> GroupByLocation()
        {
            var groupedPatients = await _dbContext.Patients
                .GroupBy(patient => patient.Location)
                .Select(group => new 
                {
                    location = group.Key,
                    count = group.Count(),
                    patient = group.ToList()
                }).ToListAsync();

            return groupedPatients;
        }

        public async Task<IEnumerable<Patient>> SortByNameAsc()
        {
            return await _dbContext.Patients.OrderBy(patient => patient.FullName).ToListAsync();
        }

        public async Task<IEnumerable<Patient>> SortByNameDesc()
        {
            return await _dbContext.Patients.OrderByDescending(patient => patient.FullName).ToListAsync();
        }
    }
}
