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
    public class SaleController : Controller
    {
        StringProcess strPro = new StringProcess();
        private readonly ApplicationDbContext _context;

        public SaleController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Sale
        public async Task<IActionResult> Index(string searchString)
        {
            var Sale = from m in _context.Sale.Include(s => s.HopDong).Include(s => s.Luong).Include(s => s.SaleViTri)// lấy toàn bộ liên kết
                select m;

            if (!String.IsNullOrEmpty(searchString)) // kiểm tra chuỗi tìm kiếm có rỗng/null hay không
            {
                Sale = Sale.Where(s => s.SaleName.Contains(searchString)); //lọc theo chuỗi tìm kiếm
                }
            return View(await Sale.ToListAsync());
        }
        // public async Task<IActionResult> Index()
        // {
        //     var applicationDbContext = _context.Sale.Include(s => s.HopDong).Include(s => s.Luong).Include(s => s.SaleViTri);
        //     return View(await applicationDbContext.ToListAsync());
        // }

        // GET: Sale/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Sale == null)
            {
                return NotFound();
            }

            var Sale = await _context.Sale
                .Include(s => s.HopDong)
                .Include(s => s.Luong)
                .Include(s => s.SaleViTri)
                .FirstOrDefaultAsync(m => m.SaleID == id);
            if (Sale == null)
            {
                return NotFound();
            }

            return View(Sale);
        }

        // GET: Sale/Create
        public IActionResult Create()
        {
            ViewData["HopDongID"] = new SelectList(_context.Set<HopDong>(), "HopDongID", "TimeHopDong");
            ViewData["LuongID"] = new SelectList(_context.Set<Luong>(), "LuongID", "SoLuong");
            ViewData["ViTriSaleID"] = new SelectList(_context.Set<SaleViTri>(), "ViTriSaleID", "VitriSale");
            var newID = "";
            if (_context.Sale.Count() == 0)
            {
                //khoi tao 1 ma moi
                newID = "SALE01";
            }
            else
            {
                var id = _context.Sale.OrderByDescending(m => m.SaleID).First().SaleID;
                newID = strPro.AutoGenerateKey(id);
            }
            ViewBag.SaleID = newID;
            return View();
        }

        // POST: Sale/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SaleID,SaleName,SalePhoneNumber,SaleAddress,SaleBirth,SaleSex,SaleBank,SaleCCCD,ViTriSaleID,LuongID,HopDongID,SaleStart,SaleEnd")] Sale Sale)
        {
            if (ModelState.IsValid)
            {
                _context.Add(Sale);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HopDongID"] = new SelectList(_context.Set<HopDong>(), "HopDongID", "TimeHopDong", Sale.HopDongID);
            ViewData["LuongID"] = new SelectList(_context.Set<Luong>(), "LuongID", "SoLuong", Sale.LuongID);
            ViewData["ViTriSaleID"] = new SelectList(_context.Set<SaleViTri>(), "ViTriSaleID", "VitriSale", Sale.ViTriSaleID);
            return View(Sale);
        }

        // GET: Sale/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Sale == null)
            {
                return NotFound();
            }

            var Sale = await _context.Sale.FindAsync(id);
            if (Sale == null)
            {
                return NotFound();
            }
            ViewData["HopDongID"] = new SelectList(_context.Set<HopDong>(), "HopDongID", "TimeHopDong", Sale.HopDongID);
            ViewData["LuongID"] = new SelectList(_context.Set<Luong>(), "LuongID", "SoLuong", Sale.LuongID);
            ViewData["ViTriSaleID"] = new SelectList(_context.Set<SaleViTri>(), "ViTriSaleID", "VitriSale", Sale.ViTriSaleID);
            return View(Sale);
        }

        // POST: Sale/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("SaleID,SaleName,SalePhoneNumber,SaleAddress,SaleBirth,SaleSex,SaleBank,SaleCCCD,ViTriSaleID,LuongID,HopDongID,SaleStart,SaleEnd")] Sale Sale)
        {
            if (id != Sale.SaleID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(Sale);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SaleExists(Sale.SaleID))
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
            ViewData["HopDongID"] = new SelectList(_context.Set<HopDong>(), "HopDongID", "TimeHopDong", Sale.HopDongID);
            ViewData["LuongID"] = new SelectList(_context.Set<Luong>(), "LuongID", "SoLuong", Sale.LuongID);
            ViewData["ViTriSaleID"] = new SelectList(_context.Set<SaleViTri>(), "ViTriSaleID", "VitriSale", Sale.ViTriSaleID);
            return View(Sale);
        }

        // GET: Sale/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Sale == null)
            {
                return NotFound();
            }

            var Sale = await _context.Sale
                .Include(s => s.HopDong)
                .Include(s => s.Luong)
                .Include(s => s.SaleViTri)
                .FirstOrDefaultAsync(m => m.SaleID == id);
            if (Sale == null)
            {
                return NotFound();
            }

            return View(Sale);
        }

        // POST: Sale/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Sale == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Sale'  is null.");
            }
            var Sale = await _context.Sale.FindAsync(id);
            if (Sale != null)
            {
                _context.Sale.Remove(Sale);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SaleExists(string id)
        {
          return (_context.Sale?.Any(e => e.SaleID == id)).GetValueOrDefault();
        }
    }
}