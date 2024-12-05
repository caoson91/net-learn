namespace BlazorRepository
{
    public interface IUnitOfWork
    {
        IProductRepository Product { get; }
        Task<int> CompleteAsync();
    }
}
