using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PresentationWebApp.Helpers;
using ShoppingCart.Application.Interfaces;
using ShoppingCart.Application.Services;
using ShoppingCart.Application.ViewModels;
using ShoppingCart.Data.Repositories;
using ShoppingCart.Domain.Interfaces;
using ShoppingCart.Domain.Models;
//cart order
//item orderdetail
//https://www.youtube.com/watch?v=C2FX_37XBqM
namespace PresentationWebApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly ILogger<OrderController> _logger;

        public OrderController(ILogger<OrderController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(Guid id)
        {
            try
            {
                string loggedInEmail = User.Identity.Name;
                return View();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return RedirectToAction("Error", "Home");
            }
            
        }
        /*private readonly IProductsService _productsService;
        
        public IActionResult Index()
        {
            var order = SessionHelper.GetObjectFromJson<List<OrderDetails>>(HttpContext.Session, "order");
            ViewBag.order = order;
            ViewBag.total = order.Sum(od => od.Price * od.Quantity);

            return View();
        }

        private int isExist(string id)
        {
            List<OrderDetails> order = SessionHelper.GetObjectFromJson<List<OrderDetails>>(HttpContext.Session, "order");
            for (int i = 0; i < order.Count; i++)
            {
                if (order[i].Product.Id.Equals(id))
                {
                    return i;
                }
            }
            return -1;
        }*/
        
        /*public IActionResult Buy(Guid id)
        {
            //var p = _productsService.GetProduct(id);
            if (SessionHelper.GetObjectFromJson<List<OrderDetails>>(HttpContext.Session, "order") == null)
            {
                List<OrderDetails> order = new List<OrderDetails>();
                order.Add(new OrderDetails { Product = _productsService.GetProduct(id), Quantity = 1 });
                SessionHelper.SetObjectAsJson(HttpContext.Session, "order", order);
            }
            else
            {
                List<OrderDetails> order = SessionHelper.GetObjectFromJson<List<OrderDetails>>(HttpContext.Session, "order");
                int index = isExist(id.ToString());
                if(index != -1)
                {
                    order[index].Quantity++;
                }
                else
                {
                    order.Add(new OrderDetails { Product = _productsService.GetProduct(id), Quantity = 1 });
                }
                SessionHelper.SetObjectAsJson(HttpContext.Session, "order", order);
            }
            return RedirectToAction("Index");
        } */
    }
}
