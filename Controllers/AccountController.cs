using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;
using BTLN1.Models;
using BTLN1.Models.Process;
using BTLN1.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BTLN1.Controllers
{
    public class AccountController : Controller
    {
        StringProcess strPro = new StringProcess();
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Account
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Account.Include(s => s.HopDong).Include(s => s.Luong).Include(s => s.AccountViTri);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Account/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Account == null)
            {
                return NotFound();
            }

            var Account = await _context.Account
                .Include(s => s.HopDong)
                .Include(s => s.Luong)
                .Include(s => s.AccountViTri)
                .FirstOrDefaultAsync(m => m.AccountID == id);
            if (Account == null)
            {
                return NotFound();
            }

            return View(Account);
        }

        // GET: Account/Create
        public IActionResult Create()
        {
            ViewData["HopDongID"] = new SelectList(_context.Set<HopDong>(), "HopDongID", "TimeHopDong");
            ViewData["LuongID"] = new SelectList(_context.Set<Luong>(), "LuongID", "SoLuong");
            ViewData["ViTriAccountID"] = new SelectList(_context.Set<AccountViTri>(), "ViTriAccountID", "VitriAccount");
            var newID = "";
            if (_context.Account.Count() == 0)
            {
                //khoi tao 1 ma moi
                newID = "ACCO00001";
            }
            else
            {
                var id = _context.Account.OrderByDescending(m => m.AccountID).First().AccountID;
                newID = strPro.AutoGenerateKey(id);
            }
            ViewBag.AccountID = newID;
            return View();
        }

        // POST: Account/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AccountID,AccountName,AccountPhoneNumber,AccountAddress,AccountBirth,AccountSex,AccountBank,AccountCCCD,ViTriAccountID,LuongID,HopDongID,AccountStart,AccountEnd")] Account Account)
        {
            if (ModelState.IsValid)
            {
                _context.Add(Account);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HopDongID"] = new SelectList(_context.Set<HopDong>(), "HopDongID", "TimeHopDong", Account.HopDongID);
            ViewData["LuongID"] = new SelectList(_context.Set<Luong>(), "LuongID", "SoLuong", Account.LuongID);
            ViewData["ViTriAccountID"] = new SelectList(_context.Set<AccountViTri>(), "ViTriAccountID", "VitriAccount", Account.ViTriAccountID);
            return View(Account);
        }

        // GET: Account/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Account == null)
            {
                return NotFound();
            }

            var Account = await _context.Account.FindAsync(id);
            if (Account == null)
            {
                return NotFound();
            }
            ViewData["HopDongID"] = new SelectList(_context.Set<HopDong>(), "HopDongID", "TimeHopDong", Account.HopDongID);
            ViewData["LuongID"] = new SelectList(_context.Set<Luong>(), "LuongID", "SoLuong", Account.LuongID);
            ViewData["ViTriAccountID"] = new SelectList(_context.Set<AccountViTri>(), "ViTriAccountID", "VitriAccount", Account.ViTriAccountID);
            return View(Account);
        }

        // POST: Account/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("AccountID,AccountName,AccountPhoneNumber,AccountAddress,AccountBirth,AccountSex,AccountBank,AccountCCCD,ViTriAccountID,LuongID,HopDongID,AccountStart,AccountEnd")] Account Account)
        {
            if (id != Account.AccountID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(Account);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccountExists(Account.AccountID))
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
            ViewData["HopDongID"] = new SelectList(_context.Set<HopDong>(), "HopDongID", "TimeHopDong", Account.HopDongID);
            ViewData["LuongID"] = new SelectList(_context.Set<Luong>(), "LuongID", "SoLuong", Account.LuongID);
            ViewData["ViTriAccountID"] = new SelectList(_context.Set<AccountViTri>(), "ViTriAccountID", "VitriAccount", Account.ViTriAccountID);
            return View(Account);
        }

        // GET: Account/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Account == null)
            {
                return NotFound();
            }

            var Account = await _context.Account
                .Include(s => s.HopDong)
                .Include(s => s.Luong)
                .Include(s => s.AccountViTri)
                .FirstOrDefaultAsync(m => m.AccountID == id);
            if (Account == null)
            {
                return NotFound();
            }

            return View(Account);
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
            var Account = await _context.Account.FindAsync(id);
            if (Account != null)
            {
                _context.Account.Remove(Account);
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