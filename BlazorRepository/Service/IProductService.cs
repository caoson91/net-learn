using BlazorRepository.Model;

namespace BlazorRepository.Service
{
    public interface IProductService
    {
        Task<bool> AddProductAsync(Product product);
    }
}
