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
    public class SmartphonesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SmartphonesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Smartphones
        public async Task<IActionResult> Index()
        {
            return View(await _context.Smartphones.ToListAsync());
        }
        //show smartphones_news_homepage
        public IActionResult Smartphones()
        {
            return View();
        }
        // GET: Smartphones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var smartphone = await _context.Smartphones
                .FirstOrDefaultAsync(m => m.Id == id);
            if (smartphone == null)
            {
                return NotFound();
            }

            return View(smartphone);
        }

        // GET: Smartphones/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Smartphones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Manufacturer,Price,Released,isAvailable,OperatingSystemId")] Smartphone smartphone)
        {
            if (ModelState.IsValid)
            {
                _context.Add(smartphone);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(smartphone);
        }

        // GET: Smartphones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var smartphone = await _context.Smartphones.FindAsync(id);
            if (smartphone == null)
            {
                return NotFound();
            }
            return View(smartphone);
        }

        // POST: Smartphones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Manufacturer,Price,Released,isAvailable,OperatingSystemId")] Smartphone smartphone)
        {
            if (id != smartphone.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(smartphone);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SmartphoneExists(smartphone.Id))
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
            return View(smartphone);
        }

        // GET: Smartphones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var smartphone = await _context.Smartphones
                .FirstOrDefaultAsync(m => m.Id == id);
            if (smartphone == null)
            {
                return NotFound();
            }

            return View(smartphone);
        }

        // POST: Smartphones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var smartphone = await _context.Smartphones.FindAsync(id);
            _context.Smartphones.Remove(smartphone);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SmartphoneExists(int id)
        {
            return _context.Smartphones.Any(e => e.Id == id);
        }
    }
}
