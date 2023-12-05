// Controllers/SmartphoneController.cs

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartphoneManagement.Data;
using SmartphoneManagement.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SmartphoneManagement.Controllers
{
    public class SmartphoneController : Controller
    {
        private readonly YourDbContext _context;

        public SmartphoneController(YourDbContext context)
        {
            _context = context;
        }

        // ... Existing actions for CRUD operations ...

        // New method for handling search functionality
        public async Task<IActionResult> Search(DateTime? startDate, string searchString, decimal? minPrice)
        {
            var smartphones = from s in _context.Smartphones
                              select s;

            if (startDate.HasValue)
            {
                smartphones = smartphones.Where(s => s.ReleaseDate >= startDate.Value);
            }

            if (!string.IsNullOrEmpty(searchString))
            {
                smartphones = smartphones.Where(s => s.Name.Contains(searchString) || s.Brand.Contains(searchString));
            }

            if (minPrice.HasValue)
            {
                smartphones = smartphones.Where(s => s.Price >= minPrice.Value);
            }

            return View("Index", await smartphones.ToListAsync());
        }

        // New method for handling toggle functionality
        [HttpPost]
        public async Task<IActionResult> ToggleAvailability(int[] selectedIds)
        {
            if (selectedIds != null && selectedIds.Length > 0)
            {
                var smartphones = await _context.Smartphones.Where(s => selectedIds.Contains(s.Id)).ToListAsync();

                foreach (var smartphone in smartphones)
                {
                    smartphone.IsAvailable = !smartphone.IsAvailable;
                }

                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
