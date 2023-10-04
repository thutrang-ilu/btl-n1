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

namespace  BTLN1.Controllers
{
    public class CongNhanController : Controller
    {
        StringProcess strPro = new StringProcess();
        private readonly ApplicationDbContext _context;

        public CongNhanController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(string searchString)
        {
            var CongNhan = from m in _context.CongNhan // lấy toàn bộ liên kết
                select m;

            if (!String.IsNullOrEmpty(searchString)) // kiểm tra chuỗi tìm kiếm có rỗng/null hay không
            {
                CongNhan = CongNhan.Where(s => s.PhongBan.Contains(searchString)); //lọc theo chuỗi tìm kiếm
                }
            return View(await CongNhan.ToListAsync());
        }
        // // GET: CongNhan
        // public async Task<IActionResult> Index()
        // {
        //       return _context.CongNhan != null ? 
        //                   View(await _context.CongNhan.ToListAsync()) :
        //                   Problem("Entity set 'ApplicationDbContext.CongNhan'  is null.");
        // }

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
            var newID = "";
            if (_context.CongNhan.Count() == 0)
            {
                //khoi tao 1 ma moi
                newID = "WORKER001";
            }
            else
            {
                var id = _context.CongNhan.OrderByDescending(m => m.MaCongNhan).First().MaCongNhan;
                newID = strPro.AutoGenerateKey(id);
            }
            ViewBag.MaCongNhan = newID;
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
        //upload
        private ExcelProcess _excelProcess = new ExcelProcess();

        public async Task<IActionResult> Upload()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>Upload(IFormFile file)
        {
            if (file!=null)
            {
                string fileExtension = Path.GetExtension(file.FileName);
                if (fileExtension != ".xls" && fileExtension != ".xlsx")
                {
                    ModelState.AddModelError("", "Please choose excel file to upload!");
                }
                else
                {
                    //rename file when upload to sever
                    var fileName = DateTime.Now.ToShortTimeString() + fileExtension;
                    var filePath = Path.Combine(Directory.GetCurrentDirectory() + "/Uploads/Excels", fileName);
                    var fileLocation = new FileInfo(filePath).ToString();
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        //save file to server
                        await file.CopyToAsync(stream);
                        //read data from file and write to database
                        var dt = _excelProcess.ExcelToDataTable(fileLocation);
                        //dùng vòng lặp for để đọc dữ liệu dạng hd
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            //create a new Student object
                            var hd = new CongNhan();
                            //set values for attribiutes
                            hd.MaCongNhan = dt.Rows[i][0].ToString();
                            hd.PhongBan = dt.Rows[i][1].ToString();
                            hd.ViTri = dt.Rows[i][2].ToString();
                            hd.Luong = dt.Rows[i][3].ToString();
                            hd.TrangThai = dt.Rows[i][4].ToString();
                            //add oject to context
                            _context.CongNhan.Add(hd);
                        }
                        //save to database
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }
                }
            }
            return View();
        }
    }
}
