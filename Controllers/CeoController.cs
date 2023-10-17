using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BTLN1.Models;
using BTLN1.Models.Process;
using BTLN1.Data;

namespace BTLN1.Controllers
{
    public class CeoController : Controller
    {
        StringProcess strPro = new StringProcess();
        private readonly ApplicationDbContext _context;

        public CeoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Ceo
        public async Task<IActionResult> Index(string searchString)
        {
            var Ceo = from m in _context.Ceo.Include(s => s.HopDong).Include(s => s.Luong).Include(s => s.CeoViTri)// lấy toàn bộ liên kết
                select m;

            if (!String.IsNullOrEmpty(searchString)) // kiểm tra chuỗi tìm kiếm có rỗng/null hay không
            {
                Ceo = Ceo.Where(s => s.CeoName.Contains(searchString)); //lọc theo chuỗi tìm kiếm
                }
            return View(await Ceo.ToListAsync());
        }

        // GET: Ceo/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Ceo == null)
            {
                return NotFound();
            }

            var Ceo = await _context.Ceo
                .Include(s => s.HopDong)
                .Include(s => s.Luong)
                .Include(s => s.CeoViTri)
                .FirstOrDefaultAsync(m => m.CeoID == id);
            if (Ceo == null)
            {
                return NotFound();
            }

            return View(Ceo);
        }

        // GET: Ceo/Create
        public IActionResult Create()
        {
            ViewData["HopDongID"] = new SelectList(_context.Set<HopDong>(), "HopDongID", "TimeHopDong");
            ViewData["LuongID"] = new SelectList(_context.Set<Luong>(), "LuongID", "SoLuong");
            ViewData["ViTriCeoID"] = new SelectList(_context.Set<CeoViTri>(), "ViTriCeoID", "VitriCeo");
            var newID = "";
            if (_context.Ceo.Count() == 0)
            {
                //khoi tao 1 ma moi
                newID = "CEO000001";
            }
            else
            {
                var id = _context.Ceo.OrderByDescending(m => m.CeoID).First().CeoID;
                newID = strPro.AutoGenerateKey(id);
            }
            ViewBag.CeoID = newID;
            return View();
        }

        // POST: Ceo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CeoID,CeoName,CeoPhoneNumber,CeoAddress,CeoBirth,CeoSex,CeoBank,CeoCCCD,ViTriCeoID,LuongID,HopDongID,CeoStart,CeoEnd")] Ceo Ceo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(Ceo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HopDongID"] = new SelectList(_context.Set<HopDong>(), "HopDongID", "TimeHopDong", Ceo.HopDongID);
            ViewData["LuongID"] = new SelectList(_context.Set<Luong>(), "LuongID", "SoLuong", Ceo.LuongID);
            ViewData["ViTriCeoID"] = new SelectList(_context.Set<CeoViTri>(), "ViTriCeoID", "VitriCeo", Ceo.ViTriCeoID);
            return View(Ceo);
        }

        // GET: Ceo/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Ceo == null)
            {
                return NotFound();
            }

            var Ceo = await _context.Ceo.FindAsync(id);
            if (Ceo == null)
            {
                return NotFound();
            }
            ViewData["HopDongID"] = new SelectList(_context.Set<HopDong>(), "HopDongID", "TimeHopDong", Ceo.HopDongID);
            ViewData["LuongID"] = new SelectList(_context.Set<Luong>(), "LuongID", "SoLuong", Ceo.LuongID);
            ViewData["ViTriCeoID"] = new SelectList(_context.Set<CeoViTri>(), "ViTriCeoID", "VitriCeo", Ceo.ViTriCeoID);
            return View(Ceo);
        }

        // POST: Ceo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("CeoID,CeoName,CeoPhoneNumber,CeoAddress,CeoBirth,CeoSex,CeoBank,CeoCCCD,ViTriCeoID,LuongID,HopDongID,CeoStart,CeoEnd")] Ceo Ceo)
        {
            if (id != Ceo.CeoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(Ceo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CeoExists(Ceo.CeoID))
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
            ViewData["HopDongID"] = new SelectList(_context.Set<HopDong>(), "HopDongID", "TimeHopDong", Ceo.HopDongID);
            ViewData["LuongID"] = new SelectList(_context.Set<Luong>(), "LuongID", "SoLuong", Ceo.LuongID);
            ViewData["ViTriCeoID"] = new SelectList(_context.Set<CeoViTri>(), "ViTriCeoID", "VitriCeo", Ceo.ViTriCeoID);
            return View(Ceo);
        }

        // GET: Ceo/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Ceo == null)
            {
                return NotFound();
            }

            var Ceo = await _context.Ceo
                .Include(s => s.HopDong)
                .Include(s => s.Luong)
                .Include(s => s.CeoViTri)
                .FirstOrDefaultAsync(m => m.CeoID == id);
            if (Ceo == null)
            {
                return NotFound();
            }

            return View(Ceo);
        }

        // POST: Ceo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Ceo == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Ceo'  is null.");
            }
            var Ceo = await _context.Ceo.FindAsync(id);
            if (Ceo != null)
            {
                _context.Ceo.Remove(Ceo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CeoExists(string id)
        {
          return (_context.Ceo?.Any(e => e.CeoID == id)).GetValueOrDefault();
        }
    }
}