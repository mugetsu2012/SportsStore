using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using SportsStore.Models.ViewModels;

namespace SportsStore.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductsRepository _productsRepository;
        public int pageSize = 4;

        public ProductController(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public ViewResult List(int productPage = 1)
        {
            IQueryable<Product> products = _productsRepository.Products.OrderBy(p => p.ProductId)
                .Skip((productPage - 1) * pageSize).Take(pageSize);

            PagingInfo pagingInfo = new PagingInfo()
            {
                CurrentPage = productPage,
                ItemsPerPage = pageSize,
                TotalItems = _productsRepository.Products.Count()
            };

            ProductsListViewModel model = new ProductsListViewModel()
            {
                Products = products,
                PagingInfo = pagingInfo
            };

            return View(model);
        }
    }
}