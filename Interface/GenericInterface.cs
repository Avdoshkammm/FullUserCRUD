namespace RememberTask.Interface
{
    public interface GenericInterface <T, T2>
    {
        Task<T2> Login (T login, T password);
        Task<T2> Register (T2 name);
    }
}