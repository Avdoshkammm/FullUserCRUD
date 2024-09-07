namespace RememberTask.Interface
{
    public interface ICRUD <T>
    {
        Task<List<T>> GetAll();
        Task<T> GetByID (int id);
        Task<T> Create (T name);
        Task<T> Update (int id, T name);
        Task<T> Delete (int id);
    }
}
