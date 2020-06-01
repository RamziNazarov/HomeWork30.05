using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using HomeWork25._05.Models;
using Microsoft.AspNetCore.Mvc;

namespace HomeWork25._05.DB.Repositories
{
    public class ProductRepos
    {
        DataContext context { get; }
        public ProductRepos(DataContext _context)
        {
            context = _context;
        }
        public List<Product> ReadProducts()
        {
            try
            {
                return context.Products.ToList();  
            }
            catch
            {
                return null;
            }
        }
        public void DeleteProduct(int Id)
        {
            Product product = context.Products.Find(Id);
            if (product != null)
            {
                context.Products.Remove(product);
                context.SaveChanges();
            }
        }
        public List<Product> ReadByCategory(int CategoryId)
        {
            try
            {
                return context.Products.Where(p => p.CategoryId == CategoryId).Select(p => p).ToList();
            }
            catch
            {
                return null;
            }
        }
        public void EditProduct(Product product,int Id)
        {
            var pro = context.Products.Find(Id);
            if(pro != null)
            {
                pro.ProductName = string.IsNullOrEmpty(product.ProductName)?pro.ProductName:product.ProductName;
                pro.CategoryId = product.CategoryId;
                pro.ProductPrice = (product.ProductPrice < 1)?pro.ProductPrice:product.ProductPrice;
                context.SaveChanges();
            }
        }
        public void AddProduct(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
        }
    }
}
