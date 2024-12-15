using BlazorRepository.Model;
using BlazorRepository.Repository;

namespace BlazorRepository
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
