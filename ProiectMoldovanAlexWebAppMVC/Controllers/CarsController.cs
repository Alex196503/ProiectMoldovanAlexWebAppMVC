using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProiectMoldovanAlexWebAppMVC.Data;
using ProiectMoldovanAlexWebAppMVC.Models;

namespace ProiectMoldovanAlexWebAppMVC.Controllers
{
    public class CarsController : Controller
    {
        private readonly ProiectMoldovanAlexWebAppMVCContext _context;

        public CarsController(ProiectMoldovanAlexWebAppMVCContext context)
        {
            _context = context;
        }

        // GET: Cars
        public async Task<IActionResult> Index(string sortOrder, string SearchString)
        {
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["PriceSortParm"] = sortOrder == "Price" ? "price_desc" : "Price";
            ViewData["SeatsParm"] = sortOrder == "Seats" ? "seats_desc" : "Seats";
            ViewData["YearFabricationParm"] = sortOrder == "YearFabrication" ? "year_fabrication" : "YearFabrication";
            ViewData["BrandNameParm"] = String.IsNullOrEmpty(sortOrder) ? "brandname_desc" : "";
            ViewData["EngineTypeParm"] = String.IsNullOrEmpty(sortOrder) ? "engine_type" : "";
            ViewData["ColorParm"] = String.IsNullOrEmpty(sortOrder) ? "color" : "";
            ViewData["CurrentFilter"] = SearchString;
            var cars = from c in _context.Car
                       join b in _context.Brand on c.BrandID equals b.BrandID
                       join e in _context.Engine on c.EngineID equals e.EngineID
                       select new CarViewModel
                       {
                           ID = c.ID,
                           Name = c.Name,
                           Price = c.Price,
                           BrandName = b.Name,
                           EngineType = e.Type,
                           Color = c.Color,
                           Seats = c.Seats,
                           YearFabrication = c.YearFabrication
                       };
            if(!String.IsNullOrEmpty(SearchString))
            {
                cars = cars.Where(s => s.Name.Contains(SearchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    cars = cars.OrderByDescending(c => c.Name);
                    break;
                case "brandname_desc":
                    cars = cars.OrderByDescending(c => c.BrandName);
                    break;
                case "engine_type":
                    cars = cars.OrderByDescending(c => c.EngineType);
                    break;
                case "color":
                    cars = cars.OrderByDescending(c => c.Color);
                    break;
                case "Price":
                    cars = cars.OrderBy(c => c.Price);
                    break;
                case "Seats":
                    cars = cars.OrderBy(c => c.Seats);
                    break;
                case "seats_desc":
                    cars = cars.OrderByDescending(c => c.Seats);
                    break;
                case "YearFabrication":
                    cars = cars.OrderBy(c => c.YearFabrication);
                    break;
                case "year_fabrication":     
                    cars = cars.OrderByDescending(c => c.YearFabrication);
                    break;
                case "price_desc":
                    cars = cars.OrderByDescending(c => c.Price);
                    break;
                default:
                    cars = cars.OrderBy(c => c.Name);
                    break;
            }
            return View(await cars.AsNoTracking().ToListAsync());
        }

        // GET: Cars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Car
                .Include(c => c.Brand)
                .Include(c => c.Engine)
                .Include(c => c.Orders)
                .ThenInclude(o => o.Owner)
                .Include(c=>c.Orders)
                .ThenInclude(o => o.OrderStatus)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        // GET: Cars/Create
        public IActionResult Create()
        {
            ViewData["BrandID"] = new SelectList(_context.Set<Brand>(), "BrandID", "Name");
            ViewData["EngineID"] = new SelectList(_context.Set<Engine>(), "EngineID", "Type");
            return View();
        }

        // POST: Cars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,EngineID,BrandID,Name,Price,YearFabrication,Color,Seats")] Car car)
        {
            if (ModelState.IsValid)
            {
                _context.Add(car);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BrandID"] = new SelectList(_context.Set<Brand>(), "BrandID", "Name", car.BrandID);
            ViewData["EngineID"] = new SelectList(_context.Set<Engine>(), "EngineID", "Type", car.EngineID);
            return View(car);
        }

        // GET: Cars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Car.FindAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            ViewData["BrandID"] = new SelectList(_context.Set<Brand>(), "BrandID", "Name", car.BrandID);
            ViewData["EngineID"] = new SelectList(_context.Set<Engine>(), "EngineID", "Type", car.EngineID);
            return View(car);
        }

        // POST: Cars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,EngineID,BrandID,Name,Price,YearFabrication,Color,Seats")] Car car)
        {
            if (id != car.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(car);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarExists(car.ID))
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
            ViewData["BrandID"] = new SelectList(_context.Set<Brand>(), "BrandID", "Name", car.BrandID);
            ViewData["EngineID"] = new SelectList(_context.Set<Engine>(), "EngineID", "Type", car.EngineID);
            return View(car);
        }

        // GET: Cars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Car
                .Include(c => c.Brand)
                .Include(c => c.Engine)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var car = await _context.Car.FindAsync(id);
            if (car != null)
            {
                _context.Car.Remove(car);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarExists(int id)
        {
            return _context.Car.Any(e => e.ID == id);
        }
    }
}
