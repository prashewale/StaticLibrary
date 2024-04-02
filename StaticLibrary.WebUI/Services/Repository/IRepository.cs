namespace StaticLibrary.WebUI.Services.Repository
{
    public interface IRepository<T>
    {
        Task<T?> Add(T item);
        Task<T?> Update(T item);
        Task<T?> Delete(int id);
        Task<T?> GetById(int id);
        Task<IEnumerable<T>?> GetAll();
    }
}
