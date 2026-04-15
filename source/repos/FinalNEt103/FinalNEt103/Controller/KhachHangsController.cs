using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FinalNEt103.DataContext;
using FinalNEt103.Models;

namespace FinalNEt103.Controllers
{
    public class KhachHangsController : Controller
    {
        private readonly FinalNet103Context _context;
        public KhachHangsController(FinalNet103Context context) => _context = context;

        // GET: KhachHangs
        public async Task<IActionResult> Index()
        {
            var data = await _context.KhachHangs
                .Include(k => k.MaLoaiKhachNavigation)
                .ToListAsync();
            return View(data);
        }

        // GET: KhachHangs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var kh = await _context.KhachHangs
                .Include(k => k.MaLoaiKhachNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kh == null) return NotFound();

            return View(kh);
        }

        // GET: KhachHangs/Create
        public IActionResult Create()
        {
            ViewData["MaLoaiKhach"] =
                new SelectList(_context.LoaiKhachHangs, "MaLoai", "TenLoai");
            return View();
        }

        // POST: KhachHangs/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Ten,SoDienThoai,Email,MaLoaiKhach")] KhachHang kh)
        {
            if (string.IsNullOrWhiteSpace(kh.MaLoaiKhach))
                ModelState.AddModelError("MaLoaiKhach", "Vui lòng chọn Loại khách hàng.");

            if (!ModelState.IsValid)
            {
                ViewData["MaLoaiKhach"] =
                    new SelectList(_context.LoaiKhachHangs, "MaLoai", "TenLoai", kh.MaLoaiKhach);
                return View(kh);
            }

            _context.Add(kh);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }

        // GET: KhachHangs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var khachHang = await _context.KhachHangs.FindAsync(id);
            if (khachHang == null) return NotFound();

            ViewData["MaLoaiKhach"] =
                new SelectList(_context.LoaiKhachHangs, "MaLoai", "TenLoai", khachHang.MaLoaiKhach);
            return View(khachHang);
        }

        // POST: KhachHangs/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Ten,SoDienThoai,Email,MaLoaiKhach")] KhachHang kh)
        {
            if (id != kh.Id) return NotFound();

            if (string.IsNullOrWhiteSpace(kh.MaLoaiKhach))
                ModelState.AddModelError("MaLoaiKhach", "Vui lòng chọn Loại khách hàng.");

            if (!ModelState.IsValid)
            {
                ViewData["MaLoaiKhach"] =
                    new SelectList(_context.LoaiKhachHangs, "MaLoai", "TenLoai", kh.MaLoaiKhach);
                return View(kh);
            }

            try
            {
                _context.Update(kh);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KhachHangExists(kh.Id)) return NotFound();
                throw;
            }

            return RedirectToAction("Index", "Home");
        }

        // GET: KhachHangs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var kh = await _context.KhachHangs
                .Include(k => k.MaLoaiKhachNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kh == null) return NotFound();

            return View(kh);
        }

        // POST: KhachHangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kh = await _context.KhachHangs.FindAsync(id);
            if (kh != null) _context.KhachHangs.Remove(kh);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }

        private bool KhachHangExists(int id) =>
            _context.KhachHangs.Any(e => e.Id == id);
    }
}
