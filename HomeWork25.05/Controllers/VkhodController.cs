using System.Linq;
using HomeWork25._05.Controllers;
using HomeWork25._05.DB;
using Microsoft.AspNetCore.Mvc;

namespace HomeWork25._05
{
    public class VkhodController : Controller
    {
        DataContext context {get;}
        public VkhodController(DataContext _context)
        {
            context = _context;
        } 
        [HttpGet]
        public IActionResult Vkhod()
        {
            ViewBag.Roles = context.Roles.ToList();
            return View();
        }
        public IActionResult Vkhod(string Role, string Login, string Password)
        {
            if(string.IsNullOrEmpty(Login) && string.IsNullOrEmpty(Password))
                return BadRequest(ModelState);
            var cust = context.Customers.Where(p=> p.RoleId == int.Parse(Role) && p.Login == Login && p.Password == Password).Select(p=>p).FirstOrDefault();
            if(cust != null && Role == "1")
                return RedirectToAction("Index","Product",new {Id = cust.Id});
            if(cust != null && Role == "2")
                return RedirectToAction($"Index","Customer",new {Id = cust.Id});
            return BadRequest();
        }
    }
}