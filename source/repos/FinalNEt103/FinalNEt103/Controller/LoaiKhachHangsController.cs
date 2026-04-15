using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FinalNEt103.DataContext;
using FinalNEt103.Models;

namespace FinalNEt103.Controllers
{
    public class LoaiKhachHangsController : Controller
    {
        private readonly FinalNet103Context _context;

        public LoaiKhachHangsController(FinalNet103Context context)
        {
            _context = context;
        }

        // GET: LoaiKhachHangs
        public async Task<IActionResult> Index()
        {
            return View(await _context.LoaiKhachHangs.ToListAsync());
        }

        // GET: LoaiKhachHangs/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loaiKhachHang = await _context.LoaiKhachHangs
                .FirstOrDefaultAsync(m => m.MaLoai == id);
            if (loaiKhachHang == null)
            {
                return NotFound();
            }

            return View(loaiKhachHang);
        }

        // GET: LoaiKhachHangs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LoaiKhachHangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaLoai,TenLoai")] LoaiKhachHang loaiKhachHang)
        {
            if (ModelState.IsValid)
            {
                _context.Add(loaiKhachHang);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(loaiKhachHang);
        }

        // GET: LoaiKhachHangs/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loaiKhachHang = await _context.LoaiKhachHangs.FindAsync(id);
            if (loaiKhachHang == null)
            {
                return NotFound();
            }
            return View(loaiKhachHang);
        }

        // POST: LoaiKhachHangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaLoai,TenLoai")] LoaiKhachHang loaiKhachHang)
        {
            if (id != loaiKhachHang.MaLoai)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(loaiKhachHang);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoaiKhachHangExists(loaiKhachHang.MaLoai))
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
            return View(loaiKhachHang);
        }

        // GET: LoaiKhachHangs/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loaiKhachHang = await _context.LoaiKhachHangs
                .FirstOrDefaultAsync(m => m.MaLoai == id);
            if (loaiKhachHang == null)
            {
                return NotFound();
            }

            return View(loaiKhachHang);
        }

        // POST: LoaiKhachHangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var loaiKhachHang = await _context.LoaiKhachHangs.FindAsync(id);
            if (loaiKhachHang != null)
            {
                _context.LoaiKhachHangs.Remove(loaiKhachHang);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LoaiKhachHangExists(string id)
        {
            return _context.LoaiKhachHangs.Any(e => e.MaLoai == id);
        }
    }
}
