using BlazorRepository.Model;

namespace BlazorRepository
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllCategory();
    }
}
