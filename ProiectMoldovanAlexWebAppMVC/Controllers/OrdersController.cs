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
    public class OrdersController : Controller
    {
        private readonly ProiectMoldovanAlexWebAppMVCContext _context;

        public OrdersController(ProiectMoldovanAlexWebAppMVCContext context)
        {
            _context = context;
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            var proiectMoldovanAlexWebAppMVCContext = _context.Order.Include(o => o.Car).Include(o => o.Owner).Include(o=>o.OrderStatus);
            return View(await proiectMoldovanAlexWebAppMVCContext.ToListAsync());
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Order
                .Include(o => o.Car)
                .Include(o => o.Owner)
                .Include(o=>o.OrderStatus)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.OrderID == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            ViewData["CarID"] = new SelectList(_context.Car, "ID", "Name");
            ViewData["OwnerID"] = new SelectList(_context.Owner, "OwnerID", "Name");
            ViewData["OrderStatusID"] = new SelectList(_context.OrderStatus, "ID", "Name");
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderID,OwnerID,CarID,OrderDate,OrderStatusID")] Order order)
        {
            if (ModelState.IsValid)
            {
                _context.Add(order);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarID"] = new SelectList(_context.Car, "ID", "Name", order.CarID);
            ViewData["OwnerID"] = new SelectList(_context.Owner, "OwnerID", "Name", order.OwnerID);
            ViewData["OrderStatusID"] = new SelectList(_context.OrderStatus, "ID", "Name", order.OrderStatusID); // adăugat

            return View(order);
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Order.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            ViewData["CarID"] = new SelectList(_context.Car, "ID", "Name", order.CarID);
            ViewData["OwnerID"] = new SelectList(_context.Owner, "OwnerID", "Name", order.OwnerID);
            ViewData["OrderStatusID"] = new SelectList(_context.OrderStatus, "ID", "Name", order.OrderStatusID); // adăugat
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderID,OwnerID,CarID,OrderDate,OrderStatusID")] Order order)
        {
            if (id != order.OrderID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(order);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.OrderID))
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
            ViewData["CarID"] = new SelectList(_context.Car, "ID", "Name", order.CarID);
            ViewData["OwnerID"] = new SelectList(_context.Owner, "OwnerID", "Name", order.OwnerID);
            ViewData["OrderStatusID"] = new SelectList(_context.OrderStatus, "ID", "Name", order.OrderStatusID); // adăugat
            return View(order);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Order
                .Include(o => o.Car)
                .Include(o => o.Owner)
                .Include(o=>o.OrderStatus)
                .FirstOrDefaultAsync(m => m.OrderID == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order = await _context.Order.FindAsync(id);
            if (order != null)
            {
                _context.Order.Remove(order);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(int id)
        {
            return _context.Order.Any(e => e.OrderID == id);
        }
    }
}
