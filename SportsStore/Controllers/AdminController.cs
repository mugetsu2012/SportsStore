using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;

namespace SportsStore.Controllers
{
    [Authorize]
    public class AdminController: Controller
    {
        private readonly IProductsRepository _productsRepository;

        public AdminController(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public ViewResult Index() => View(_productsRepository.Products);

        public ViewResult Create()
        {
            return View("Edit", new Product());
        }
        
        [HttpPost]
        public IActionResult Delete(int productId)
        {
            Product deletedProducto = _productsRepository.DeleteProduct(productId);
            if (deletedProducto != null)
            {
                TempData["message"] = $"{deletedProducto.Name} has been deleted";
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public ViewResult Edit(int productId)
        {
            return View(_productsRepository.Products.FirstOrDefault(x => x.ProductId == productId));
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                _productsRepository.SaveProduct(product);
                TempData["message"] = $"{product.Name} has been added";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(product);
            }
        }
    }
}
