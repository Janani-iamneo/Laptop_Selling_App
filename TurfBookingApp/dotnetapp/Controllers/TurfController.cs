// using System;
// using System.Linq;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;
// using dotnetapp.Models;

// namespace dotnetapp.Controllers
// {
//     public class TableController : Controller
//     {
//         private readonly ApplicationDbContext _dbContext;

//         public TableController(ApplicationDbContext dbContext)
//         {
//             _dbContext = dbContext;
//         }

//         public IActionResult Index()
//         {
//             var tables = _dbContext.DiningTables.ToList();
//             return View(tables);
//         }

//         public IActionResult Delete(int tableId)
//         {
//             var table = _dbContext.DiningTables.FirstOrDefault(t => t.DiningTableID == tableId);
//             if (table == null)
//             {
//                 return NotFound();
//             }

//             _dbContext.DiningTables.Remove(table);
//             _dbContext.SaveChanges();

//             return RedirectToAction("Index");
//         }

//     }
// }


using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using dotnetapp.Models;

namespace dotnetapp.Controllers
{
    public class TurfController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public TurfController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var tables = _dbContext.Turfs.ToList();
            return View(tables);
        }

        public IActionResult Delete(int turfId)
        {
            var turf = _dbContext.Turfs.FirstOrDefault(t => t.TurfID == turfId);
            if (turf == null)
            {
                return NotFound();
            }

            _dbContext.Turfs.Remove(turf);
            _dbContext.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}