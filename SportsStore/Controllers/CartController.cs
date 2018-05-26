using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SportsStore.Controllers
{
    public class CartController : Controller
    {
        [HttpPost]
        public IActionResult AddToCart()
        {
            return View();
        }
    }
}