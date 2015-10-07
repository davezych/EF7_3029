using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EF7_3029.Data;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;

namespace EF7_3029.Controllers
{
    public class HomeController : Controller
    {
        private readonly MyContext _context;

        public HomeController(MyContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var forums = _context.Forums.Include(f => f.Topics).Select(f => new
            {
                f.Id,
                Count = f.Topics.Count
            }).ToList();

            return View();
        }
    }
}
