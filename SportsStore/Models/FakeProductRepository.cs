﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Models
{
    public class FakeProductRepository:IProductsRepository
    {
        public IQueryable<Product> Products => new List<Product>
        {
            new Product {Name = "Footbal", Price = 25},
            new Product {Name = "Surf board", Price = 179},
            new Product {Name = "Running shoes", Price = 95}

        }.AsQueryable<Product>();

        public void SaveProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public Product DeleteProduct(int productId)
        {
            throw new NotImplementedException();
        }
    }
}
