using HomeWork25._05.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeWork25._05.DB.Repositories
{
    public class CategiryRepos
    {
        DataContext _context { get; }
        public CategiryRepos(DataContext context)
        {
            _context = context;
        }
        public void AddCategory(Category category)
        { 
            _context.Categories.Add(category);
            _context.SaveChanges();
        }
        public List<Category> ReadCategories()
        {
            try
            {

            return _context.Categories.ToList();
            }
            catch
            {
                return null;
            }
        }
        public void DeleteCategory(int Id)
        {
            var cat = _context.Categories.Find(Id);
            _context.Categories.Remove(cat);
            _context.SaveChanges();
        }
    }
}
