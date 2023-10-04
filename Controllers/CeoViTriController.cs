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
    public class CeoViTriController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CeoViTriController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CeoViTri
        public async Task<IActionResult> Index()
        {
              return _context.CeoViTri != null ? 
                          View(await _context.CeoViTri.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.CeoViTri'  is null.");
        }

        // GET: CeoViTri/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.CeoViTri == null)
            {
                return NotFound();
            }

            var ceoViTri = await _context.CeoViTri
                .FirstOrDefaultAsync(m => m.ViTriCeoID == id);
            if (ceoViTri == null)
            {
                return NotFound();
            }

            return View(ceoViTri);
        }

        // GET: CeoViTri/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CeoViTri/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ViTriCeoID,VitriCeo")] CeoViTri ceoViTri)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ceoViTri);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ceoViTri);
        }

        // GET: CeoViTri/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.CeoViTri == null)
            {
                return NotFound();
            }

            var ceoViTri = await _context.CeoViTri.FindAsync(id);
            if (ceoViTri == null)
            {
                return NotFound();
            }
            return View(ceoViTri);
        }

        // POST: CeoViTri/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ViTriCeoID,VitriCeo")] CeoViTri ceoViTri)
        {
            if (id != ceoViTri.ViTriCeoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ceoViTri);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CeoViTriExists(ceoViTri.ViTriCeoID))
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
            return View(ceoViTri);
        }

        // GET: CeoViTri/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.CeoViTri == null)
            {
                return NotFound();
            }

            var ceoViTri = await _context.CeoViTri
                .FirstOrDefaultAsync(m => m.ViTriCeoID == id);
            if (ceoViTri == null)
            {
                return NotFound();
            }

            return View(ceoViTri);
        }

        // POST: CeoViTri/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.CeoViTri == null)
            {
                return Problem("Entity set 'ApplicationDbContext.CeoViTri'  is null.");
            }
            var ceoViTri = await _context.CeoViTri.FindAsync(id);
            if (ceoViTri != null)
            {
                _context.CeoViTri.Remove(ceoViTri);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CeoViTriExists(string id)
        {
          return (_context.CeoViTri?.Any(e => e.ViTriCeoID == id)).GetValueOrDefault();
        }
    }
}
