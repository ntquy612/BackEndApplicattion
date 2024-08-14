namespace BackEndApplicattion.Services.DataInputService
{
    public interface DataInputService<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task CreateAsync(T t);
        Task UpdateAsync(T t);
        Task DeleteAsync(int t);
    }
}
