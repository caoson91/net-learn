
namespace BlazorRepository
{
    public class ProductService : IProductService
    {

        protected readonly IUnitOfWork _unitOfWork;
        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> AddProductAsync(Product product)
        {
            await _unitOfWork.Product.AddAsync(product);
            await _unitOfWork.CompleteAsync();
            return true;
        }
    }
}
