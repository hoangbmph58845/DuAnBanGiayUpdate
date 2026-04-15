using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BaiTapLab_2.Models;

namespace BaiTapLab_2.Controllers
{
    public class MonHocsController : Controller
    {
        private readonly DbContextApp _context;

        public MonHocsController(DbContextApp context)
        {
            _context = context;
        }
        private async Task<string> GenerateNewMaMon()
        {
            
            var lastCode = await _context.MonHocs
                .OrderByDescending(m => m.Id)
                .Select(m => m.MaMon)
                .FirstOrDefaultAsync();

            int number = 1;

            if (!string.IsNullOrEmpty(lastCode) && lastCode.Length > 3)
            {
                var numericPart = lastCode.Substring(3); 
                if (int.TryParse(numericPart, out var num))
                {
                    number = num + 1;
                }
            }

            return "MON" + number.ToString("000"); 
        }

        // GET: MonHocs
        public async Task<IActionResult> Index()
        {
            return View(await _context.MonHocs.ToListAsync());
        }

        // GET: MonHocs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var monHoc = await _context.MonHocs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (monHoc == null) return NotFound();

            return View(monHoc);
        }

        // GET: MonHocs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MonHocs/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TenMon,Description")] MonHoc monHoc)
        {
            
            ModelState.Remove("MaMon");

            if (ModelState.IsValid)
            {
               
                monHoc.MaMon = await GenerateNewMaMon();

                _context.Add(monHoc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(monHoc);
        }

        // GET: MonHocs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var monHoc = await _context.MonHocs.FindAsync(id);
            if (monHoc == null) return NotFound();

            return View(monHoc);
        }

        // POST: MonHocs/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MaMon,TenMon,Description")] MonHoc monHoc)
        {
            if (id != monHoc.Id) return NotFound();

           
            ModelState.Remove("MaMon");

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(monHoc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MonHocExists(monHoc.Id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(monHoc);
        }

        // GET: MonHocs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var monHoc = await _context.MonHocs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (monHoc == null) return NotFound();

            return View(monHoc);
        }

        // POST: MonHocs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var monHoc = await _context.MonHocs.FindAsync(id);
            if (monHoc != null)
            {
                _context.MonHocs.Remove(monHoc);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MonHocExists(int id)
        {
            return _context.MonHocs.Any(e => e.Id == id);
        }
    }
}
