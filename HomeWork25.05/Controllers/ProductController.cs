using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HomeWork25._05.DB.Repositories;
using HomeWork25._05.Models;
using Microsoft.EntityFrameworkCore.Internal;
using HomeWork25._05.DB;

namespace HomeWork25._05.Controllers
{
    public class ProductController : Controller
    {
        ProductRepos products { get; }
        CategiryRepos categories { get; }
        static Customer customer;
        DataContext _context{get;}
        public ProductController(DataContext context)
        {
            products = new ProductRepos(context);
            categories = new CategiryRepos(context);
            _context  = context;
        }
        [HttpGet]
        public IActionResult Index(int Id)
        {
            ViewBag.Products = products.ReadProducts();
            ViewBag.Categories = categories.ReadCategories();
            if(customer == null)
            {
            customer = _context.Customers.Find(Id);
            }
            ViewBag.Customer = customer;
            return View();
        }
        [HttpPost]
        public IActionResult Index(string CategoryId)
        {
            ViewBag.Customer = customer;
            if (CategoryId != "All")
            ViewBag.Products = products.ReadByCategory(int.Parse(CategoryId));
            else
                ViewBag.Products = products.ReadProducts();
            ViewBag.Categories = categories.ReadCategories();
            return View();
        }
        [HttpGet]
        public IActionResult ProductChange()
        {
            ViewBag.Customer = customer;
            ViewBag.Products = products.ReadProducts();
            ViewBag.Categories = categories.ReadCategories();
            return View();
        }
        [HttpPost]
        public IActionResult ProductChange(string Id, string CategoryId,string ProductName,double ProductPrice)
        {
            ViewBag.Customer = customer;
            products.EditProduct(new Product() { CategoryId = int.Parse(CategoryId),ProductName = ProductName,ProductPrice = ProductPrice}, int.Parse(Id));
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult ProductDelete()
        {
            ViewBag.Customer = customer;
            ViewBag.Products = products.ReadProducts();
            ViewBag.Categories = categories.ReadCategories();;
            return View();
        }
        [HttpPost]
        public IActionResult ProductDelete(string Id)
        {
            ViewBag.Customer = customer;
            products.DeleteProduct(int.Parse(Id));
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult AddProduct()
        {
            ViewBag.Customer = customer;
            ViewBag.Categories = categories.ReadCategories();
            return View();
        }
        [HttpPost]
        public IActionResult AddProduct(string ProductName,double ProductPrice,string CategoryId)
        {
            ViewBag.Customer = customer;
            if (ProductPrice < 1)
                return BadRequest();
            if (string.IsNullOrEmpty(ProductName))
                return BadRequest();
            products.AddProduct(new Product() { ProductName = ProductName,ProductPrice = ProductPrice,CategoryId = int.Parse(CategoryId)});
            return RedirectToAction("Index");
        }
    }
}
