namespace BlazorRepository.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IProductRepository Product { get; }
        public ICategoryRepository Category { get; }
        public UnitOfWork(ApplicationDbContext context, 
            IProductRepository product,
            ICategoryRepository category)
        {
            _context = context;
            Product = product;
            Category = category;
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
    }
}
