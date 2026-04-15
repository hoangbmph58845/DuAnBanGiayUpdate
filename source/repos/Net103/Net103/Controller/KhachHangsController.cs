using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Net103.DataContext;
using Net103.Models;

namespace Net103.Controllers   
{
    public class KhachHangsController : Controller
    {
        private readonly FinalNet103Context _context;
        public KhachHangsController(FinalNet103Context context) => _context = context;

        public async Task<IActionResult> Index()
        {
            var list = await _context.KhachHangs
                .Include(k => k.MaLoaiKhachNavigation)
                .ToListAsync();
            return View(list);
        }

        public IActionResult Create()
        {
            ViewData["MaLoaiKhach"] = new SelectList(_context.LoaiKhachHangs, "MaLoai", "TenLoai"); 
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Ten,SoDienThoai,Email,MaLoaiKhach")] KhachHang khachHang)
        {
            if (string.IsNullOrWhiteSpace(khachHang.MaLoaiKhach)) 
                ModelState.AddModelError("MaLoaiKhach", "Vui lòng chọn Loại khách hàng.");

            if (!ModelState.IsValid)
            {
                ViewData["MaLoaiKhach"] = new SelectList(_context.LoaiKhachHangs, "MaLoai", "TenLoai", khachHang.MaLoaiKhach);
                return View(khachHang);
            }

            _context.Add(khachHang);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var khachHang = await _context.KhachHangs.FindAsync(id);
            if (khachHang == null) return NotFound();

            ViewData["MaLoaiKhach"] = new SelectList(_context.LoaiKhachHangs, "MaLoai", "TenLoai", khachHang.MaLoaiKhach); // ✅
            return View(khachHang);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Ten,SoDienThoai,Email,MaLoaiKhach")] KhachHang khachHang)
        {
            if (id != khachHang.Id) return NotFound();

            if (string.IsNullOrWhiteSpace(khachHang.MaLoaiKhach)) 
                ModelState.AddModelError("MaLoaiKhach", "Vui lòng chọn Loại khách hàng.");

            if (!ModelState.IsValid)
            {
                ViewData["MaLoaiKhach"] = new SelectList(_context.LoaiKhachHangs, "MaLoai", "TenLoai", khachHang.MaLoaiKhach);
                return View(khachHang);
            }

            _context.Update(khachHang);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Home"); 
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var khachHang = await _context.KhachHangs
                .Include(k => k.MaLoaiKhachNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (khachHang == null) return NotFound();
            return View(khachHang);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var khachHang = await _context.KhachHangs.FindAsync(id);
            if (khachHang != null) _context.KhachHangs.Remove(khachHang);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Home"); 
        }

        private bool KhachHangExists(int id) => _context.KhachHangs.Any(e => e.Id == id);
    }
}
