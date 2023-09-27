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
    public class CongNhanController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CongNhanController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CongNhan
        public async Task<IActionResult> Index()
        {
              return _context.CongNhan != null ? 
                          View(await _context.CongNhan.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.CongNhan'  is null.");
        }

        // GET: CongNhan/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.CongNhan == null)
            {
                return NotFound();
            }

            var congNhan = await _context.CongNhan
                .FirstOrDefaultAsync(m => m.MaCongNhan == id);
            if (congNhan == null)
            {
                return NotFound();
            }

            return View(congNhan);
        }

        // GET: CongNhan/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CongNhan/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaCongNhan,PhongBan,ViTri,Luong,TrangThai")] CongNhan congNhan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(congNhan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(congNhan);
        }

        // GET: CongNhan/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.CongNhan == null)
            {
                return NotFound();
            }

            var congNhan = await _context.CongNhan.FindAsync(id);
            if (congNhan == null)
            {
                return NotFound();
            }
            return View(congNhan);
        }

        // POST: CongNhan/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaCongNhan,PhongBan,ViTri,Luong,TrangThai")] CongNhan congNhan)
        {
            if (id != congNhan.MaCongNhan)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(congNhan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CongNhanExists(congNhan.MaCongNhan))
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
            return View(congNhan);
        }

        // GET: CongNhan/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.CongNhan == null)
            {
                return NotFound();
            }

            var congNhan = await _context.CongNhan
                .FirstOrDefaultAsync(m => m.MaCongNhan == id);
            if (congNhan == null)
            {
                return NotFound();
            }

            return View(congNhan);
        }

        // POST: CongNhan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.CongNhan == null)
            {
                return Problem("Entity set 'ApplicationDbContext.CongNhan'  is null.");
            }
            var congNhan = await _context.CongNhan.FindAsync(id);
            if (congNhan != null)
            {
                _context.CongNhan.Remove(congNhan);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CongNhanExists(string id)
        {
          return (_context.CongNhan?.Any(e => e.MaCongNhan == id)).GetValueOrDefault();
        }
    }
}
