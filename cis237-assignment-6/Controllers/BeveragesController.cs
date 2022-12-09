using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using cis237_assignment_6.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace cis237_assignment_6.Controllers
{
    [Authorize]
    public class BeveragesController : Controller
    {
        private readonly BeverageContext _context;

        public BeveragesController(BeverageContext context)
        {
            _context = context;
        }

        public IActionResult Sort(string sortOrder)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.PriceSortParm = sortOrder == "Price" ? "price_desc" : "Price";
            var beverages = from b in _context.Beverages
                           select b;
            switch (sortOrder)
            {
                case "name_desc":
                    beverages = beverages.OrderByDescending(b => b.Name);
                    break;
                case "Price":
                    beverages = beverages.OrderBy(b => b.Price);
                    break;
                case "price_desc":
                    beverages = beverages.OrderByDescending(b => b.Price);
                    break;
                default:
                    beverages = beverages.OrderBy(b => b.Name);
                    break;
            }
            return View(beverages.ToList());
        }

        // GET: Beverages
        public async Task<IActionResult> Index()
        {
            DbSet<Beverage> beveragesToFilter = _context.Beverages;

            string filterName = "";
            string filterPack = "";
            string filterMinPrice = "";
            string filterMaxPrice = "";

            int min = 0;
            int max = 100;

            if (!String.IsNullOrEmpty(
                HttpContext.Session.GetString("session_name")
            ))
            {
                filterName = HttpContext.Session.GetString("session_name");
            }
            if (!String.IsNullOrEmpty(
                HttpContext.Session.GetString("session_pack")
            ))
            {
                filterPack = HttpContext.Session.GetString("session_pack");
            }
            if (!String.IsNullOrEmpty(
                HttpContext.Session.GetString("session_minPrice")
            ))
            {
                filterMinPrice = HttpContext.Session.GetString("session_minPrice");
                min = Int32.Parse(filterMinPrice);
            }
            if (!String.IsNullOrEmpty(
                HttpContext.Session.GetString("session_maxPrice")
            ))
            {
                filterMaxPrice = HttpContext.Session.GetString("session_maxPrice");
                max = Int32.Parse(filterMaxPrice);
            }

            IList<Beverage> finalFiltered = await beveragesToFilter.Where(
                beverage => beverage.Price >= min && 
                beverage.Price <= max &&
                beverage.Name.Contains(filterName)
                ).ToListAsync();

            ViewData["filterName"] = filterName;
            ViewData["filterPack"] = filterPack;
            ViewData["filterMinPrice"] = filterMinPrice;
            ViewData["filterMaxPrice"] = filterMaxPrice;

            return View(finalFiltered);

            // original return
            //return View(await _context.Beverages.ToListAsync());
        }

        // GET: Beverages/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var beverage = await _context.Beverages
                .FirstOrDefaultAsync(m => m.Id == id);
            if (beverage == null)
            {
                return NotFound();
            }

            return View(beverage);
        }

        // GET: Beverages/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Beverages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Pack,Price,Active")] Beverage beverage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(beverage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(beverage);
        }

        // GET: Beverages/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var beverage = await _context.Beverages.FindAsync(id);
            if (beverage == null)
            {
                return NotFound();
            }
            return View(beverage);
        }

        // POST: Beverages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Name,Pack,Price,Active")] Beverage beverage)
        {
            if (id != beverage.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(beverage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BeverageExists(beverage.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(beverage);
        }

        // GET: Beverages/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var beverage = await _context.Beverages
                .FirstOrDefaultAsync(m => m.Id == id);
            if (beverage == null)
            {
                return NotFound();
            }

            return View(beverage);
        }

        // POST: Beverages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Beverages == null)
            {
                return Problem("Entity set 'BeverageContext.Beverages' is null");
            }
            var beverage = await _context.Beverages.FindAsync(id);
            if (beverage != null)
            {
                _context.Beverages.Remove(beverage);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Filter()
        {
            string name = HttpContext.Request.Form["name"];
            string pack = HttpContext.Request.Form["pack"];
            string minPrice = HttpContext.Request.Form["minprice"];
            string maxPrice = HttpContext.Request.Form["maxprice"];

            HttpContext.Session.SetString("session_name", name);
            HttpContext.Session.SetString("session_pack", pack);
            HttpContext.Session.SetString("session_minprice", minPrice);
            HttpContext.Session.SetString("session_maxprice", maxPrice);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult JsonApi()
        {
            return Json(
                _context.Beverages.ToList()
            );
        }

        private bool BeverageExists(string id)
        {
            return _context.Beverages.Any(e => e.Id == id);
        }
    }
}
