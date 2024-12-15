namespace BlazorRepository.Repository
{
    public interface IUnitOfWork
    {
        IProductRepository Product { get; }
        ICategoryRepository Category { get; }
        Task<int> CompleteAsync();
    }
}
