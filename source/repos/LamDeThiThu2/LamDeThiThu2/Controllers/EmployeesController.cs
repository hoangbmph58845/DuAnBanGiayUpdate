using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LamDeThiThu2.Models;
namespace LamDeThiThu2.Controllers
{
        public class EmployeesController : Controller
        {
            private readonly DbContextApp _context;

            public EmployeesController(DbContextApp context)
            {
                _context = context;
            }


        public async Task<IActionResult> Index(string nameEmp, int? id)
        {
            var query = _context.Employees
                                .Include(e => e.Role)
                                .AsQueryable();

            if (!string.IsNullOrEmpty(nameEmp))
            {
                query = query.Where(e => e.NameEmp.Contains(nameEmp));
            }

            if (id.HasValue)
            {
                query = query.Where(e => e.Id == id.Value);
            }

            ViewBag.NameEmp = nameEmp;
            ViewBag.Id = id;

            var result = await query.ToListAsync();
            return View(result);
        }


        // GET: Create
        public IActionResult Create()
            {
               
                ViewBag.RoleId = new SelectList(_context.Roles, "Id", "NameRole");
                return View();
            }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            var errors = ModelState.Values
                                   .SelectMany(v => v.Errors)
                                   .Select(e => e.ErrorMessage)
                                   .ToList();

            ViewBag.RoleId = new SelectList(_context.Roles, "Id", "NameRole", employee.RoleId);
            return View(employee);
        }


        // GET: Edit
        public async Task<IActionResult> Edit(int id)
            {
                var emp = await _context.Employees.FindAsync(id);
                if (emp == null) return NotFound();

                ViewBag.RoleId = new SelectList(_context.Roles, "Id", "NameRole", emp.RoleId);
                return View(emp);
            }

            // POST: Edit
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Edit(int id, Employee employee)
            {
                if (id != employee.Id) return NotFound();

                if (ModelState.IsValid)
                {
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }

                ViewBag.RoleId = new SelectList(_context.Roles, "Id", "NameRole", employee.RoleId);
                return View(employee);
            }

            // GET: Delete
            public async Task<IActionResult> Delete(int id)
            {
                var emp = await _context.Employees
                                        .Include(e => e.Role)
                                        .FirstOrDefaultAsync(e => e.Id == id);
                if (emp == null) return NotFound();
                return View(emp);
            }

            // POST: Delete
            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> DeleteConfirmed(int id)
            {
                var emp = await _context.Employees.FindAsync(id);
                if (emp != null)
                {
                    _context.Employees.Remove(emp);
                    await _context.SaveChangesAsync();
                }
                return RedirectToAction(nameof(Index));
            }

            public async Task<IActionResult> Details(int id)
            {
                var emp = await _context.Employees
                    .Include(e => e.Role)
                    .FirstOrDefaultAsync(e => e.Id == id);
                if (emp == null) return NotFound();
                return View(emp);
            }

        }
    }
