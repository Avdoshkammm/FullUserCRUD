namespace RememberTask.Interface
{
    public interface IUser<T>
    {
        Task<List<T>> GetAllUsers();
        Task<T> GetUser(int id);
        Task<T> CreateUser(T name);
        Task<T> UpdateUser(int id, T name);
        Task<T> DeleteUser(int id);
    }
}
