using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorRepository
{
    public interface IUnitOfWork
    {
        IUsersRepository Users { get; }
        Task<int> CompleteAsync();
    }
}
