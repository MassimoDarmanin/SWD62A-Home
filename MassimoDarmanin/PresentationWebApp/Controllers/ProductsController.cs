using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Application.Interfaces;
using ShoppingCart.Application.ViewModels;
using PagedList;
using System.Web.Mvc.Html;

namespace PresentationWebApp.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductsService _productsService;
        private readonly ICategoriesService _categoriesService;
        private IWebHostEnvironment _env;
        public ProductsController(IProductsService productsService, ICategoriesService categoriesService,
             IWebHostEnvironment env )
        {
            _productsService = productsService;
            _categoriesService = categoriesService;
            _env = env;
        }

        public IActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            //var list = _productsService.GetProducts();

            //return View(list);

            ViewBag.CurrentSort = sortOrder;

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name" : "";
            ViewBag.PriceSortParm = sortOrder == "price" ? "category" : "price";
            //ViewBag.CategorySortParm = sortOrder == "category" ? "price" : "category";
            var list = _productsService.GetProducts();

            switch (sortOrder)
            {
                case "name":
                    list = list.OrderByDescending(s => s.Name);
                    break;
                case "price":
                    list = list.OrderBy(s => s.Price);
                    break;
                case "category":
                    list = list.OrderByDescending(s => s.Category);
                    break;
                default:
                    list = list.OrderBy(s => s.Name);
                    break;
            }
            int pageSize = 4;
            int pageNumber = (page ?? 1);
            return View(list.ToPagedList(pageNumber, pageSize));
            //return View(list.ToList());
        }

        //public ActionResult Index(int? i)
        //{
        //    var list = _productsService.GetProducts();
        //    return View(list.ToPagedList(i ?? 1,3));
        //}

        //public async Task<IActionResult> Index(string sortOrder,string currentFilter,
        //    string searchString,int? pageNumber)
        //{
        //    ViewData["CurrentSort"] = sortOrder;
        //    var products = from p in _productsService.GetProducts() select p;
        //    if (searchString != null)
        //    {
        //        pageNumber = 1;
        //    }
        //    else
        //    {
        //        searchString = currentFilter;
        //    }
        //    int pageSize = 3;
        //    return View(await PaginatedList<ProductViewModel>.CreateAsync(products.AsNoTracking(), pageNumber ?? 1, pageSize));
        //}

        [HttpPost]
        public IActionResult Search(string keyword) //using a form, and the select list must have name attribute = category
        {
            var list = _productsService.GetProducts(keyword).ToList();

            return View("Index", list);
        }


        public IActionResult Details(Guid id)
        {
            var p = _productsService.GetProduct(id);
            return View( p);
        }

        //the engine will load a page with empty fields
        [HttpGet]
        [Authorize (Roles ="Admin")] //is going to be accessed only by authenticated users
        public IActionResult Create()
        {
            //fetch a list of categories
            var listOfCategeories = _categoriesService.GetCategories();

            //we pass the categories to the page
            ViewBag.Categories = listOfCategeories;

            return View();
        }

        //here details input by the user will be received
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Create(ProductViewModel data, IFormFile f)
        {
            try
            {
                if(f !=  null)
                {
                    if(f.Length > 0)
                    {
                        //C:\Users\Ryan\source\repos\SWD62BEP\SWD62BEP\Solution3\PresentationWebApp\wwwroot
                        string newFilename = Guid.NewGuid() + System.IO.Path.GetExtension(f.FileName);
                        string newFilenameWithAbsolutePath = _env.WebRootPath +  @"\Images\" + newFilename;
                        
                        using (var stream = System.IO.File.Create(newFilenameWithAbsolutePath))
                        {
                            f.CopyTo(stream);
                        }

                        data.ImageUrl = @"\Images\" + newFilename;
                    }
                }

                _productsService.AddProduct(data);

                TempData["feedback"] = "Product was added successfully";
            }
            catch (Exception ex)
            {
                //log error
                TempData["warning"] = "Product was not added!";
            }

           var listOfCategeories = _categoriesService.GetCategories();
           ViewBag.Categories = listOfCategeories;
            return View(data);
        
        } //fiddler, burp, zap, postman

        [Authorize(Roles = "Admin")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _productsService.DeleteProduct(id);
                TempData["feedback"] = "Product was deleted";
            }
            catch (Exception ex)
            {
                //log your error 

                TempData["warning"] = "Product was not deleted"; //Change from ViewData to TempData
            }

            return RedirectToAction("Index");
        }

        //public PartialViewResult ProductListPartial(int? page, int category)
        //{
        //    var pageNo = page ?? 1;
        //    var pageSize = 10;
        //    if(category != null)
        //    {
        //        var productList = _productsService.GetProducts(category);
        //        return PartialView(productList);
        //    }
        //    else
        //    {
        //        var productList = _productsService.GetProducts();
        //        return PartialView(productList);
        //    }
        //}
    }
}
