namespace RememberTask.Interface
{
    public interface IProduct<T>
    {
        Task<List<T>> GetAllProduct();
        Task<T> GetProductByID(int id);
        Task<T> CreateProduct(T name);
        Task<T> UpdateProduct(int id,T name);
        Task<T> DeleteProduct(int id);
    }
}