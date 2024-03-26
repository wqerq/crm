using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Admin.Data;
using WebApplication3.Admin.Models;

namespace WebApplication3.Admin.Controllers
{
    [Area("Admin")]
    public class LessonsController : Controller
    {
        private readonly WebApplication3Context2 _context;

        public LessonsController(WebApplication3Context2 context)
        {
            _context = context;
        }

        // GET: Lessons
        public async Task<IActionResult> Index()
        {
            var webApplication3Context = _context.Lesson.Include(l => l.Lesson_Group).Include(l => l.Lesson_Professor).Include(l => l.Lesson_Room).Include(l => l.Lesson_Subject);
            return View(await webApplication3Context.ToListAsync());
        }

        // GET: Lessons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lesson = await _context.Lesson
                .Include(l => l.Lesson_Group)
                .Include(l => l.Lesson_Professor)
                .Include(l => l.Lesson_Room)
                .Include(l => l.Lesson_Subject)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (lesson == null)
            {
                return NotFound();
            }

            return View(lesson);
        }

        // GET: Lessons/Create
        public IActionResult Create()
        {
            ViewData["Lesson_GroupId"] = new SelectList(_context.Group, "ID", "Number");
            ViewData["Lesson_ProfessorId"] = new SelectList(_context.Set<Professor>(), "ID", "SurName");
            ViewData["Lesson_RoomId"] = new SelectList(_context.Set<Room>(), "ID", "Number");
            ViewData["Lesson_SubjectId"] = new SelectList(_context.Set<Subject>(), "ID", "Name");
            return View();
        }

        // POST: Lessons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Lesson_GroupId,Lesson_ProfessorId,Lesson_SubjectId,Lesson_RoomId,Day,Time")] Lesson lesson)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lesson);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Lesson_GroupId"] = new SelectList(_context.Group, "ID", "Number", lesson.Lesson_GroupId);
            ViewData["Lesson_ProfessorId"] = new SelectList(_context.Set<Professor>(), "ID", "SurName", lesson.Lesson_ProfessorId);
            ViewData["Lesson_RoomId"] = new SelectList(_context.Set<Room>(), "ID", "Number", lesson.Lesson_RoomId);
            ViewData["Lesson_SubjectId"] = new SelectList(_context.Set<Subject>(), "ID", "Name", lesson.Lesson_SubjectId);
            return View(lesson);
        }

        // GET: Lessons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lesson = await _context.Lesson.FindAsync(id);
            if (lesson == null)
            {
                return NotFound();
            }
            ViewData["Lesson_GroupId"] = new SelectList(_context.Group, "ID", "Number", lesson.Lesson_GroupId);
            ViewData["Lesson_ProfessorId"] = new SelectList(_context.Set<Professor>(), "ID", "SurName", lesson.Lesson_ProfessorId);
            ViewData["Lesson_RoomId"] = new SelectList(_context.Set<Room>(), "ID", "Number", lesson.Lesson_RoomId);
            ViewData["Lesson_SubjectId"] = new SelectList(_context.Set<Subject>(), "ID", "Name", lesson.Lesson_SubjectId);
            return View(lesson);
        }

        // POST: Lessons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Lesson_GroupId,Lesson_ProfessorId,Lesson_SubjectId,Lesson_RoomId,Day,Time")] Lesson lesson)
        {
            if (id != lesson.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lesson);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LessonExists(lesson.ID))
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
            ViewData["Lesson_GroupId"] = new SelectList(_context.Group, "ID", "Number", lesson.Lesson_GroupId);
            ViewData["Lesson_ProfessorId"] = new SelectList(_context.Set<Professor>(), "ID", "SurName", lesson.Lesson_ProfessorId);
            ViewData["Lesson_RoomId"] = new SelectList(_context.Set<Room>(), "ID", "Number", lesson.Lesson_RoomId);
            ViewData["Lesson_SubjectId"] = new SelectList(_context.Set<Subject>(), "ID", "Name", lesson.Lesson_SubjectId);
            return View(lesson);
        }

        // GET: Lessons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lesson = await _context.Lesson
                .Include(l => l.Lesson_Group)
                .Include(l => l.Lesson_Professor)
                .Include(l => l.Lesson_Room)
                .Include(l => l.Lesson_Subject)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (lesson == null)
            {
                return NotFound();
            }

            return View(lesson);
        }

        // POST: Lessons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lesson = await _context.Lesson.FindAsync(id);
            if (lesson != null)
            {
                _context.Lesson.Remove(lesson);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LessonExists(int id)
        {
            return _context.Lesson.Any(e => e.ID == id);
        }
    }
}
