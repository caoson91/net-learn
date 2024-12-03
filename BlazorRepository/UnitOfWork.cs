using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorRepository
{
    public class UnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IUsersRepository Users { get; }
        public UnitOfWork(ApplicationDbContext context, IUsersRepository usersRepository)
        {
            _context = context;
            Users = usersRepository;
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
