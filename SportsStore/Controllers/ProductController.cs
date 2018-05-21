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

        public ViewResult List(string category, int productPage = 1)
        {
            IQueryable<Product> products = _productsRepository.Products
                .Where(x => category == null || x.Category == category).OrderBy(p => p.ProductId)
                .Skip((productPage - 1) * pageSize).Take(pageSize);

            PagingInfo pagingInfo = new PagingInfo()
            {
                CurrentPage = productPage,
                ItemsPerPage = pageSize,
                TotalItems =
                    category == null
                        ? _productsRepository.Products.Count()
                        : _productsRepository.Products.Count(e => e.Category == category)
            };

            ProductsListViewModel model = new ProductsListViewModel()
            {
                Products = products,
                PagingInfo = pagingInfo,
                CurrentCategory = category
            };

            return View(model);
        }
    }
}