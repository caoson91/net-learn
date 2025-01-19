using BlazorRepository.Model;

namespace BlazorRepository
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllCategory();
        Task<bool> AddCategoryAsync(Category category);
    }
}
