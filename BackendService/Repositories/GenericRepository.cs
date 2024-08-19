using BackendService.Helpers;
using BackendService.Models;
using BackendService.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace BackendService.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly HospitalDbContext _dbContext;
        private DbSet<T> _dbSet;

        public GenericRepository(HospitalDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        public async Task AddData(T obj)
        {
            _dbSet.Add(obj);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteData(object ID)
        {
            var data = await _dbSet.FindAsync(ID);

            if (data != null)
            {
                _dbSet.Remove(data);
                await _dbContext.SaveChangesAsync();
            }

            if (data == null)
                throw new DomainInternalServerError("Could not process due some error");

        }

        public async Task EditData(object ID, T obj)
        {
            var data = await _dbSet.FindAsync(ID);

            if (data != null)
            {
                _dbContext.Entry(data).CurrentValues.SetValues(obj);
                await _dbContext.SaveChangesAsync();
            }

            if (data == null)
                throw new DomainInternalServerError("Could not process due some error");
        }

        public async Task<List<T>> GetAllData()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetData(object ID)
        {
            return await _dbSet.FindAsync(ID);
        }
    }
}
