using System.Collections.Generic;
using System.Linq;
using HomeWork25._05.DB;
using Microsoft.AspNetCore.Mvc;

namespace HomeWork25._05
{
    public class CustomerController : Controller
    {
        DataContext context {get;}
        static Customer customer;
        public CustomerController(DataContext _context)
        {
            context = _context;
        }
        [HttpGet]
        public IActionResult Index(int Id)
        {
            ViewBag.Categories = context.Categories.ToList();
            ViewBag.Products = context.Products.ToList();
            customer = context.Customers.Find(Id);
            return View();
        }
        [HttpPost]
        public IActionResult Index(string CategoryId)
        {
            ViewBag.Adress = customer.Adress??"Adress not found";
            ViewBag.Categories = context.Categories.ToList();
            if(CategoryId == "All")
                ViewBag.Products = context.Products.ToList();
            else
                ViewBag.Products = context.Products.Where(p=>p.CategoryId == int.Parse(CategoryId)).Select(p=>p).ToList();
            return View();
        }
        [HttpPost]
        public IActionResult ToKorzina(List<int> productes)
        {
            ViewBag.productes = productes;
            return View();
        }
    }
}