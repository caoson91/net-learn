using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorRepository.Model;

namespace BlazorRepository.Repository
{
    public interface IProductRepository : IGenericRepository<Product>
    {
    }
}
