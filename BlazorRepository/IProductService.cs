namespace BlazorRepository
{
    public interface IProductService
    {
        Task<bool> AddProductAsync(Product product);
    }
}
