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
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Account
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Account.Include(a => a.HopDong).Include(a => a.Luong);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Account/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Account == null)
            {
                return NotFound();
            }

            var account = await _context.Account
                .Include(a => a.HopDong)
                .Include(a => a.Luong)
                .FirstOrDefaultAsync(m => m.AccountID == id);
            if (account == null)
            {
                return NotFound();
            }

            return View(account);
        }

        // GET: Account/Create
        public IActionResult Create()
        {
            ViewData["HopDongID"] = new SelectList(_context.Set<HopDong>(), "HopDongID", "HopDongID");
            ViewData["LuongID"] = new SelectList(_context.Set<Luong>(), "LuongID", "LuongID");
            return View();
        }

        // POST: Account/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AccountID,AccountName,AccountPhoneNumber,AccountAddress,AccountBirth,AccountSex,AccountBank,AccountCCCD,ViTriAccountID,LuongID,HopDongID,AccountStart,AccountEnd")] Account account)
        {
            if (ModelState.IsValid)
            {
                _context.Add(account);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HopDongID"] = new SelectList(_context.Set<HopDong>(), "HopDongID", "HopDongID", account.HopDongID);
            ViewData["LuongID"] = new SelectList(_context.Set<Luong>(), "LuongID", "LuongID", account.LuongID);
            return View(account);
        }

        // GET: Account/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Account == null)
            {
                return NotFound();
            }

            var account = await _context.Account.FindAsync(id);
            if (account == null)
            {
                return NotFound();
            }
            ViewData["HopDongID"] = new SelectList(_context.Set<HopDong>(), "HopDongID", "HopDongID", account.HopDongID);
            ViewData["LuongID"] = new SelectList(_context.Set<Luong>(), "LuongID", "LuongID", account.LuongID);
            return View(account);
        }

        // POST: Account/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("AccountID,AccountName,AccountPhoneNumber,AccountAddress,AccountBirth,AccountSex,AccountBank,AccountCCCD,ViTriAccountID,LuongID,HopDongID,AccountStart,AccountEnd")] Account account)
        {
            if (id != account.AccountID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(account);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccountExists(account.AccountID))
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
            ViewData["HopDongID"] = new SelectList(_context.Set<HopDong>(), "HopDongID", "HopDongID", account.HopDongID);
            ViewData["LuongID"] = new SelectList(_context.Set<Luong>(), "LuongID", "LuongID", account.LuongID);
            return View(account);
        }

        // GET: Account/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Account == null)
            {
                return NotFound();
            }

            var account = await _context.Account
                .Include(a => a.HopDong)
                .Include(a => a.Luong)
                .FirstOrDefaultAsync(m => m.AccountID == id);
            if (account == null)
            {
                return NotFound();
            }

            return View(account);
        }

        // POST: Account/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Account == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Account'  is null.");
            }
            var account = await _context.Account.FindAsync(id);
            if (account != null)
            {
                _context.Account.Remove(account);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AccountExists(string id)
        {
          return (_context.Account?.Any(e => e.AccountID == id)).GetValueOrDefault();
        }
    }
}
