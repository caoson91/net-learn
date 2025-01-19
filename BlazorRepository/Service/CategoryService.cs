
using BlazorRepository.Model;
using BlazorRepository.Repository;

namespace BlazorRepository
{
    public class CategoryService : ICategoryService
    {
        protected readonly IUnitOfWork _unitOfWork;
        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> AddCategoryAsync(Category category)
        {
            await _unitOfWork.Category.AddAsync(category);
            await _unitOfWork.CompleteAsync();

            return true;
        }

        public async Task<IEnumerable<Category>> GetAllCategory()
        {
            return await _unitOfWork.Category.GetAllAsync();
        }
    }
}
