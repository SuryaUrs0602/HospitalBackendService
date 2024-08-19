using BackendService.Models;

namespace BackendService.Repositories.Contracts
{
    public interface IGenericRepository<T> where T : class
    {
        Task AddData(T obj);
        Task DeleteData(object ID);
        Task EditData(object ID, T obj);
        Task<T> GetData(object ID);
        Task<List<T>> GetAllData();
    }
}
