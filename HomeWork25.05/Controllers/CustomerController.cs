using System;
using System.Collections.Generic;
using System.Linq;
using HomeWork25._05.DB;
using HomeWork25._05.Models;
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
            ViewBag.Customer = customer;
            return View();
        }
        [HttpPost]
        public IActionResult Index(string CategoryId)
        {
            ViewBag.Categories = context.Categories.ToList();
            if(CategoryId == "All")
                ViewBag.Products = context.Products.ToList();
            else
                ViewBag.Products = context.Products.Where(p=>p.CategoryId == int.Parse(CategoryId)).Select(p=>p).ToList();
            return View();
        }
        [HttpGet]
        public IActionResult ToKorzina(int[] productes,int[] productId)
        {
            List<int> producs = new List<int>();
            List<Product> prod = new List<Product>(); 
            for(int i = 0; i < productes.Length;i++)
            {
                if(productes[i] > 0)
                {
                    producs.Add(productes[i]);
                    prod.Add(context.Products.Find(productId[i]));
                }
            }
            ViewBag.productId = prod;
            ViewBag.productes = producs;
            return View();
        }
        [HttpPost]
        public IActionResult ToKorzina(double totalPrice)
        {
            return RedirectToAction("OknoOplati",new { totalPrice = totalPrice});
        }
        [HttpGet]
        public IActionResult OknoOplati(double totalPrice)
        {
            ViewBag.Customer = customer;
            ViewBag.Price = totalPrice;
            return View();
        }
        [HttpPost]
        public IActionResult OknoOplati(string date)
        {
            ViewBag.date = date;
            return View();
        }
    }
}