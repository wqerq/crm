using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using WebApplication3.Models;
using WebApplication3.Data;

namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
        private readonly WebApplication3Context _context;

        public HomeController(WebApplication3Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var Group = _context.Group.ToList();
            ViewBag.Groups = new SelectList(Group, "ID", "Number");
            var Professor = _context.Professor.ToList();
            ViewBag.Professors= new SelectList(Professor, "ID", "SurName");
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public ActionResult Group_Data(int groupID)
        {
            Dictionary<KeyValuePair<DayOfWeek, TimeSpan>, string> dic = new Dictionary<KeyValuePair<DayOfWeek, TimeSpan>, string>();
            var exercisess = _context.Lesson
            .Where(x => x.Lesson_GroupId == groupID)
            .Include(g => g.Lesson_Group)
            .Include(s => s.Lesson_Subject)
            .Include(c => c.Lesson_Room)
            .Include(t => t.Lesson_Professor).ToList();
            TimeSpan[] alltime = new TimeSpan[] { new TimeSpan(8, 20, 0), new TimeSpan(10, 0, 0), new TimeSpan(12, 5, 0), new TimeSpan(13, 50, 0), new TimeSpan(15, 35, 0) };
            DayOfWeek[] allday = new DayOfWeek[] { DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday, DayOfWeek.Saturday };
            foreach (var day in allday)
            {
                foreach (var time in alltime)
                {
                    Lesson les = exercisess.Find(x => x.Day == day && x.Time == time);
                    if (les != null)
                    {
                        dic.Add(new KeyValuePair<DayOfWeek, TimeSpan>(day, time), les.ToString());
                    }
                    else
                    {
                        dic.Add(new KeyValuePair<DayOfWeek, TimeSpan>(day, time), "Нет занятий");
                    }
                }
            }
            return PartialView("Views/Shared/PartialView.cshtml", dic);
        }

        public ActionResult Professor_Data(int professorID)
        {
            Dictionary<KeyValuePair<DayOfWeek, TimeSpan>, string> dic = new Dictionary<KeyValuePair<DayOfWeek, TimeSpan>, string>();
            var exercisess = _context.Lesson
            .Where(x => x.Lesson_ProfessorId == professorID)
            .Include(g => g.Lesson_Group)
            .Include(s => s.Lesson_Subject)
            .Include(c => c.Lesson_Room)
            .Include(t => t.Lesson_Professor).ToList();
            TimeSpan[] alltime = new TimeSpan[] { new TimeSpan(8, 20, 0), new TimeSpan(10, 0, 0), new TimeSpan(12, 5, 0), new TimeSpan(13, 50, 0), new TimeSpan(15, 35, 0) };
            DayOfWeek[] allday = new DayOfWeek[] { DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday, DayOfWeek.Saturday };
            foreach (var day in allday)
            {
                foreach (var time in alltime)
                {
                    Lesson les = exercisess.Find(x => x.Day == day && x.Time == time);
                    if (les != null)
                    {
                        dic.Add(new KeyValuePair<DayOfWeek, TimeSpan>(day, time), les.ToString());
                    }
                    else
                    {
                        dic.Add(new KeyValuePair<DayOfWeek, TimeSpan>(day, time), "Нет занятий");
                    }
                }
            }
            return PartialView("Views/Shared/PartialView.cshtml", dic);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
