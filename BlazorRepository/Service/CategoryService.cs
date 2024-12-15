
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

        public async Task<IEnumerable<Category>> GetAllCategory()
        {
           return await _unitOfWork.Category.GetAllAsync();
        }
    }
}
