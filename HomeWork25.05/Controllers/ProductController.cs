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
        public ProductController(DataContext context)
        {
            products = new ProductRepos(context);
            categories = new CategiryRepos(context);
        }
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Products = products.ReadProducts();
            ViewBag.Categories = categories.ReadCategories();
            return View();
        }
        [HttpPost]
        public IActionResult Index(string CategoryId)
        {
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
            ViewBag.Products = products.ReadProducts();
            ViewBag.Categories = categories.ReadCategories();
            return View();
        }
        [HttpPost]
        public IActionResult ProductChange(string Id, string CategoryId,string ProductName,double ProductPrice)
        {
            products.EditProduct(new Product() { CategoryId = int.Parse(CategoryId),ProductName = ProductName,ProductPrice = ProductPrice}, int.Parse(Id));
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult ProductDelete()
        {
            ViewBag.Products = products.ReadProducts();
            ViewBag.Categories = categories.ReadCategories();;
            return View();
        }
        [HttpPost]
        public IActionResult ProductDelete(string Id)
        {
            products.DeleteProduct(int.Parse(Id));
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult AddProduct()
        {
            ViewBag.Categories = categories.ReadCategories();
            return View();
        }
        [HttpPost]
        public IActionResult AddProduct(string ProductName,double ProductPrice,string CategoryId)
        {
            if (ProductPrice < 1)
                return BadRequest();
            if (string.IsNullOrEmpty(ProductName))
                return BadRequest();
            products.AddProduct(new Product() { ProductName = ProductName,ProductPrice = ProductPrice,CategoryId = int.Parse(CategoryId)});
            return RedirectToAction("Index");
        }
    }
}
