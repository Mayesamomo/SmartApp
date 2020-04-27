using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SmartApp.Data;
using SmartApp.Models;

namespace SmartApp.Controllers
{
    public class OpSystemsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OpSystemsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: OpSystems
        public async Task<IActionResult> Index()
        {
            return View(await _context.OpSystems.ToListAsync());
        }
        //operating system history
        public IActionResult OS_System()
        {
            return View();
        }
        // GET: OpSystems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var opSystem = await _context.OpSystems
                .FirstOrDefaultAsync(m => m.Id == id);
            if (opSystem == null)
            {
                return NotFound();
            }

            return View(opSystem);
        }

        // GET: OpSystems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OpSystems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,OsType")] OpSystem opSystem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(opSystem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(opSystem);
        }

        // GET: OpSystems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var opSystem = await _context.OpSystems.FindAsync(id);
            if (opSystem == null)
            {
                return NotFound();
            }
            return View(opSystem);
        }

        // POST: OpSystems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,OsType")] OpSystem opSystem)
        {
            if (id != opSystem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(opSystem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OpSystemExists(opSystem.Id))
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
            return View(opSystem);
        }

        // GET: OpSystems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var opSystem = await _context.OpSystems
                .FirstOrDefaultAsync(m => m.Id == id);
            if (opSystem == null)
            {
                return NotFound();
            }

            return View(opSystem);
        }

        // POST: OpSystems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var opSystem = await _context.OpSystems.FindAsync(id);
            _context.OpSystems.Remove(opSystem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OpSystemExists(int id)
        {
            return _context.OpSystems.Any(e => e.Id == id);
        }
    }
}
