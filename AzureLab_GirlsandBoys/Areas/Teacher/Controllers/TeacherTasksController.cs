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

namespace AzureLab_GirlsandBoys.Areas.Teacher.Controllers
{
    [Area("Teacher")]
    [Authorize]
    public class TeacherTasksController : Controller
    {
        private readonly AzureLab_GirlsandBoysContext _context;

        public TeacherTasksController(AzureLab_GirlsandBoysContext context)
        {
            _context = context;
        }

        // GET: Teacher/TeacherTasks
        public async Task<IActionResult> Index()
        {
            return View(await _context.TeacherTask.ToListAsync());
        }

        // GET: Teacher/TeacherTasks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacherTask = await _context.TeacherTask
                .FirstOrDefaultAsync(m => m.ID == id);
            if (teacherTask == null)
            {
                return NotFound();
            }

            return View(teacherTask);
        }

        // GET: Teacher/TeacherTasks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Teacher/TeacherTasks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,TaskId,Description,Location")] TeacherTask teacherTask)
        {
            if (ModelState.IsValid)
            {
                _context.Add(teacherTask);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(teacherTask);
        }

        // GET: Teacher/TeacherTasks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacherTask = await _context.TeacherTask.FindAsync(id);
            if (teacherTask == null)
            {
                return NotFound();
            }
            return View(teacherTask);
        }

        // POST: Teacher/TeacherTasks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,TaskId,Description,Location")] TeacherTask teacherTask)
        {
            if (id != teacherTask.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(teacherTask);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeacherTaskExists(teacherTask.ID))
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
            return View(teacherTask);
        }

        // GET: Teacher/TeacherTasks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacherTask = await _context.TeacherTask
                .FirstOrDefaultAsync(m => m.ID == id);
            if (teacherTask == null)
            {
                return NotFound();
            }

            return View(teacherTask);
        }

        // POST: Teacher/TeacherTasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var teacherTask = await _context.TeacherTask.FindAsync(id);
            _context.TeacherTask.Remove(teacherTask);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TeacherTaskExists(int id)
        {
            return _context.TeacherTask.Any(e => e.ID == id);
        }
    }
}
