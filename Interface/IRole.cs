namespace RememberTask.Interface
{
    public interface IRole<T>
    {
        Task<List<T>> GetAllRole();
        Task<T> GetRoleByID(int id);
        Task<T> CreateRole(T name);
        Task<T> UpdateRole(int id,T name);
        Task<T> DeleteRole(int id);
    }
}
