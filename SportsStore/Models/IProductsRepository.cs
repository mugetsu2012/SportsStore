using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Models
{
    public interface IProductsRepository
    {
        IQueryable<Product> Products { get; }
    }
}
