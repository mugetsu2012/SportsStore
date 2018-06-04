using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportsStore.Infrastructure;
using SportsStore.Models;
using SportsStore.Models.ViewModels;

namespace SportsStore.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductsRepository _productsRepository;
        private Cart _cart;

        public CartController(IProductsRepository productsRepository, Cart cart)
        {
            _productsRepository = productsRepository;
            _cart = cart;
        }

        public ViewResult Index(string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = _cart,
                ReturnUrl = returnUrl
            });
        }

        [HttpPost]
        public RedirectToActionResult AddToCart(int productId, string returnUrl)
        {
            Product product = _productsRepository.Products.FirstOrDefault(x => x.ProductId == productId);

            if (product != null)
            {
                _cart.AddItem(product, 1);
            }

            return RedirectToAction("Index", new {returnUrl});
        }

        public RedirectToActionResult RemoveFromCart(int productId, string returnUrl)
        {
            Product product = _productsRepository.Products.FirstOrDefault(x => x.ProductId == productId);
            if (product != null)
            {
                _cart.RemoveLine(product);
            }

            return RedirectToAction("Index", new { returnUrl });
        }
    }
}