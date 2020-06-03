using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeWork25._05.DB;
using HomeWork25._05.DB.Repositories;
using HomeWork25._05.Models;
using Microsoft.AspNetCore.Mvc;

namespace HomeWork25._05.Controllers
{
    public class CategoryController : Controller
    {
        CategiryRepos categories { get; }
        DataContext context {get;}
        public CategoryController(DataContext _context)
        {
            context = _context;
            categories = new CategiryRepos(_context);
        }
        public IActionResult Index()
        {
            ViewBag.Customer = context.Customers.Where(p=>p.RoleId == 1).FirstOrDefault();
            ViewBag.Categories = categories.ReadCategories();
            return View();
        }
        [HttpGet]
        public IActionResult AddCategory()
        {
            ViewBag.Customer = context.Customers.Where(p=>p.RoleId == 1).FirstOrDefault();
            return View();
        }
        [HttpPost]
        public IActionResult AddCategory(string CategoryName)
        {
            ViewBag.Customer = context.Customers.Where(p=>p.RoleId == 1).FirstOrDefault();
            if (string.IsNullOrEmpty(CategoryName))
                return BadRequest();
            categories.AddCategory(new Category() { CategoryName = CategoryName});
            return RedirectToAction("Index");
        }
    }
}
