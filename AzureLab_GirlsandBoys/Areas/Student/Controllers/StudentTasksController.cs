using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AzureLab_GirlsandBoys.Data;
using AzureLab_GirlsandBoys.Models;
using Microsoft.AspNetCore.Authorization;

namespace AzureLab_GirlsandBoys.Areas.Student.Controllers
{
    [Area("Student")]
    [Authorize]
    public class StudentTasksController : Controller
    {
        private readonly AzureLab_GirlsandBoysContext _context;

        public StudentTasksController(AzureLab_GirlsandBoysContext context)
        {
            _context = context;
        }

        // GET: Student/StudentTasks
        public async Task<IActionResult> Index()
        {
            return View(await _context.StudentTask.ToListAsync());
        }

        // GET: Student/StudentTasks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentTask = await _context.StudentTask
                .FirstOrDefaultAsync(m => m.ID == id);
            if (studentTask == null)
            {
                return NotFound();
            }

            return View(studentTask);
        }

        // GET: Student/StudentTasks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Student/StudentTasks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,TaskId,Description,Location")] StudentTask studentTask)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studentTask);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(studentTask);
        }

        // GET: Student/StudentTasks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentTask = await _context.StudentTask.FindAsync(id);
            if (studentTask == null)
            {
                return NotFound();
            }
            return View(studentTask);
        }

        // POST: Student/StudentTasks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,TaskId,Description,Location")] StudentTask studentTask)
        {
            if (id != studentTask.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studentTask);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentTaskExists(studentTask.ID))
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
            return View(studentTask);
        }

        // GET: Student/StudentTasks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentTask = await _context.StudentTask
                .FirstOrDefaultAsync(m => m.ID == id);
            if (studentTask == null)
            {
                return NotFound();
            }

            return View(studentTask);
        }

        // POST: Student/StudentTasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var studentTask = await _context.StudentTask.FindAsync(id);
            _context.StudentTask.Remove(studentTask);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentTaskExists(int id)
        {
            return _context.StudentTask.Any(e => e.ID == id);
        }
    }
}
