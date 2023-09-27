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
    public class AccountViTriController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountViTriController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AccountViTri
        public async Task<IActionResult> Index()
        {
              return _context.AccountViTri != null ? 
                          View(await _context.AccountViTri.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.AccountViTri'  is null.");
        }

        // GET: AccountViTri/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.AccountViTri == null)
            {
                return NotFound();
            }

            var accountViTri = await _context.AccountViTri
                .FirstOrDefaultAsync(m => m.ViTriAccountID == id);
            if (accountViTri == null)
            {
                return NotFound();
            }

            return View(accountViTri);
        }

        // GET: AccountViTri/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AccountViTri/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ViTriAccountID,VitriAccount")] AccountViTri accountViTri)
        {
            if (ModelState.IsValid)
            {
                _context.Add(accountViTri);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(accountViTri);
        }

        // GET: AccountViTri/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.AccountViTri == null)
            {
                return NotFound();
            }

            var accountViTri = await _context.AccountViTri.FindAsync(id);
            if (accountViTri == null)
            {
                return NotFound();
            }
            return View(accountViTri);
        }

        // POST: AccountViTri/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ViTriAccountID,VitriAccount")] AccountViTri accountViTri)
        {
            if (id != accountViTri.ViTriAccountID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(accountViTri);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccountViTriExists(accountViTri.ViTriAccountID))
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
            return View(accountViTri);
        }

        // GET: AccountViTri/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.AccountViTri == null)
            {
                return NotFound();
            }

            var accountViTri = await _context.AccountViTri
                .FirstOrDefaultAsync(m => m.ViTriAccountID == id);
            if (accountViTri == null)
            {
                return NotFound();
            }

            return View(accountViTri);
        }

        // POST: AccountViTri/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.AccountViTri == null)
            {
                return Problem("Entity set 'ApplicationDbContext.AccountViTri'  is null.");
            }
            var accountViTri = await _context.AccountViTri.FindAsync(id);
            if (accountViTri != null)
            {
                _context.AccountViTri.Remove(accountViTri);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AccountViTriExists(string id)
        {
          return (_context.AccountViTri?.Any(e => e.ViTriAccountID == id)).GetValueOrDefault();
        }
    }
}
