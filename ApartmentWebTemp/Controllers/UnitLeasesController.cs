using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ApartmentWebTemp.Data;
using ApartmentWebTemp.Models;
using Microsoft.AspNetCore.Authorization;

namespace ApartmentWebTemp.Controllers
{
    [Authorize(Roles = IdentityHelper.Landlord)]
    public class UnitLeasesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UnitLeasesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: UnitLeases
        public async Task<IActionResult> Index()
        {
            return View(await _context.UnitLeases.ToListAsync());
        }

        // GET: UnitLeases/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unitLease = await _context.UnitLeases
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (unitLease == null)
            {
                return NotFound();
            }

            return View(unitLease);
        }

        // GET: UnitLeases/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UnitLeases/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UnitNumber,UnitFloor,MonthlyRent,UnitDescription,LeaseStarting,LeaseEnding,UserId,FirstName,LastName,PhoneNumber")] UnitLease unitLease)
        {
            if (ModelState.IsValid)
            {
                _context.Add(unitLease);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(unitLease);
        }

        // GET: UnitLeases/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unitLease = await _context.UnitLeases.FindAsync(id);
            if (unitLease == null)
            {
                return NotFound();
            }
            return View(unitLease);
        }

        // POST: UnitLeases/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UnitNumber,UnitFloor,MonthlyRent,UnitDescription,LeaseStarting,LeaseEnding,UserId,FirstName,LastName,PhoneNumber")] UnitLease unitLease)
        {
            if (id != unitLease.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(unitLease);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UnitLeaseExists(unitLease.UserId))
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
            return View(unitLease);
        }

        // GET: UnitLeases/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unitLease = await _context.UnitLeases
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (unitLease == null)
            {
                return NotFound();
            }

            return View(unitLease);
        }

        // POST: UnitLeases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var unitLease = await _context.UnitLeases.FindAsync(id);
            _context.UnitLeases.Remove(unitLease);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UnitLeaseExists(int id)
        {
            return _context.UnitLeases.Any(e => e.UserId == id);
        }
    }
}
