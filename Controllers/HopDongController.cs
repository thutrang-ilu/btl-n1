using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BTLN1.Data;
using BTLN1.Models;

namespace BTLN1.Controllers
{
    public class HopDongController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HopDongController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: HopDong
        public async Task<IActionResult> Index()
        {
              return _context.HopDong != null ? 
                          View(await _context.HopDong.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.HopDong'  is null.");
        }

        // GET: HopDong/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.HopDong == null)
            {
                return NotFound();
            }

            var hopDong = await _context.HopDong
                .FirstOrDefaultAsync(m => m.HopDongID == id);
            if (hopDong == null)
            {
                return NotFound();
            }

            return View(hopDong);
        }

        // GET: HopDong/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HopDong/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HopDongID,TimeHopDong")] HopDong hopDong)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hopDong);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hopDong);
        }

        // GET: HopDong/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.HopDong == null)
            {
                return NotFound();
            }

            var hopDong = await _context.HopDong.FindAsync(id);
            if (hopDong == null)
            {
                return NotFound();
            }
            return View(hopDong);
        }

        // POST: HopDong/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("HopDongID,TimeHopDong")] HopDong hopDong)
        {
            if (id != hopDong.HopDongID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hopDong);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HopDongExists(hopDong.HopDongID))
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
            return View(hopDong);
        }

        // GET: HopDong/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.HopDong == null)
            {
                return NotFound();
            }

            var hopDong = await _context.HopDong
                .FirstOrDefaultAsync(m => m.HopDongID == id);
            if (hopDong == null)
            {
                return NotFound();
            }

            return View(hopDong);
        }

        // POST: HopDong/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.HopDong == null)
            {
                return Problem("Entity set 'ApplicationDbContext.HopDong'  is null.");
            }
            var hopDong = await _context.HopDong.FindAsync(id);
            if (hopDong != null)
            {
                _context.HopDong.Remove(hopDong);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HopDongExists(string id)
        {
          return (_context.HopDong?.Any(e => e.HopDongID == id)).GetValueOrDefault();
        }
    }
}
