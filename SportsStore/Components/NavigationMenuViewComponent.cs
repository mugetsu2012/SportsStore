using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;

namespace SportsStore.Components
{
    public class NavigationMenuViewComponent:ViewComponent
    {
        private IProductsRepository _productsRepository;

        public NavigationMenuViewComponent(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public IViewComponentResult Invoke()
        {
            var model = _productsRepository.Products.Select(x => x.Category).Distinct().OrderBy(x => x);
            ViewBag.SelectedCategory = RouteData?.Values["category"];
            return View(model);
        }
    }
}
