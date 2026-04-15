using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BaiTapLab_2.Models;

namespace BaiTapLab_2.Controllers
{
    public class StudentsController : Controller
    {
        private readonly DbContextApp _context;

        public StudentsController(DbContextApp context)
        {
            _context = context;
        }

       
        public async Task<IActionResult> Index(int? lopId, int? monHocId)
        {
            var query = _context.Students
                .Include(s => s.Lop)
                .Include(s => s.MonHocs)
                .AsQueryable();

            if (lopId.HasValue)
            {
                query = query.Where(s => s.LopId == lopId.Value);
            }

            if (monHocId.HasValue)
            {
                query = query.Where(s => s.MonHocs.Any(m => m.Id == monHocId.Value));
            }

            ViewBag.Lops = new SelectList(_context.Lops.ToList(), "Id", "LopName", lopId);
            ViewBag.MonHocs = new SelectList(_context.MonHocs.ToList(), "Id", "TenMon", monHocId);

            var result = await query.ToListAsync();
            return View(result);
        }

      
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var student = await _context.Students
                .Include(s => s.Lop)
                .Include(s => s.MonHocs)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (student == null) return NotFound();

            return View(student);
        }

      
        public IActionResult Create()
        {
            ViewBag.LopList = new SelectList(_context.Lops.ToList(), "Id", "LopName");
            ViewBag.MonHocList = _context.MonHocs.ToList();
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Student student, int[] selectedMonHocIds)
        {
            if (ModelState.IsValid)
            {
         
                if (selectedMonHocIds != null && selectedMonHocIds.Length > 0)
                {
                    student.MonHocs = _context.MonHocs
                        .Where(m => selectedMonHocIds.Contains(m.Id))
                        .ToList();
                }

                _context.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.LopList = new SelectList(_context.Lops.ToList(), "Id", "LopName", student.LopId);
            ViewBag.MonHocList = _context.MonHocs.ToList();
            return View(student);
        }

        
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var student = await _context.Students
                .Include(s => s.MonHocs)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (student == null) return NotFound();

            ViewBag.LopList = new SelectList(_context.Lops.ToList(), "Id", "LopName", student.LopId);
            ViewBag.MonHocList = _context.MonHocs.ToList();
            ViewBag.SelectedMonHocIds = student.MonHocs.Select(m => m.Id).ToArray();

            return View(student);
        }

     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Student student, int[] selectedMonHocIds)
        {
            if (id != student.Id) return NotFound();

            if (ModelState.IsValid)
            {

                var existingStudent = await _context.Students
                    .Include(s => s.MonHocs)
                    .FirstOrDefaultAsync(s => s.Id == id);

                if (existingStudent == null) return NotFound();


                existingStudent.StudentName = student.StudentName;
                existingStudent.MaSV = student.MaSV;
                existingStudent.DOB = student.DOB;
                existingStudent.LopId = student.LopId;

                existingStudent.MonHocs.Clear();
                if (selectedMonHocIds != null && selectedMonHocIds.Length > 0)
                {
                    var monHocs = await _context.MonHocs
                        .Where(m => selectedMonHocIds.Contains(m.Id))
                        .ToListAsync();

                    foreach (var mh in monHocs)
                    {
                        existingStudent.MonHocs.Add(mh);
                    }
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.LopList = new SelectList(_context.Lops.ToList(), "Id", "LopName", student.LopId);
            ViewBag.MonHocList = _context.MonHocs.ToList();
            ViewBag.SelectedMonHocIds = selectedMonHocIds;
            return View(student);
        }

        // DELETE 
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var student = await _context.Students
                .Include(s => s.Lop)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (student == null) return NotFound();

            return View(student);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await _context.Students
                .Include(s => s.MonHocs)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (student != null)
            {
                student.MonHocs.Clear();
                _context.Students.Remove(student);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
