using ContosoUniversity.Data;
using ContosoUniversity.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ContosoUniversity.Controllers
{
    public class DepartmentsController : Controller
    {
        private readonly SchoolContext _context;
        public DepartmentsController(SchoolContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var schoolContext = _context.Departments.Include(department => department.Administrator);
            return View(await schoolContext.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            string query = "SELECT * FROM Departments WHERE DepartmentID = {0}";
            var department = await _context.Departments.FromSqlRaw(query, id).Include(d => d.Administrator).AsNoTracking().FirstOrDefaultAsync();
            if (department == null)
            {
                return NotFound();
            }
            return View(department);
        }


        [HttpGet]
        public IActionResult Create()
        {
            ViewData["InstructorID"] = new SelectList(_context.Instructors, "ID", "FullName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Budget,StartDate,RowVersion,InstructorID,SuperImportantString")] Department department)
        {
            if (ModelState.IsValid)
            {
                _context.Add(department);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["InstructorID"] = new SelectList(_context.Instructors, "ID", "FullName",department.InstructorID);
            return View(department);
        }

        [HttpGet]
        public async Task<IActionResult> BaseOn(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            string query = "SELECT * FROM Departments WHERE DepartmentID = {0}";
            var department = await _context.Departments.FromSqlRaw(query, id).Include(d => d.Administrator).AsNoTracking().FirstOrDefaultAsync();
            if (department == null)
            {
                return NotFound();
            }
            ViewData["InstructorID"] = new SelectList(_context.Instructors, "ID", "FullName");
            return View(department);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Make([Bind("Name,Budget,StartDate,RowVersion,InstructorID,SuperImportantString")] Department department)
        {
            if (ModelState.IsValid)
            {
                var departmentClone = new Department
                {
                    Name = department.Name,
                    Budget = department.Budget,
                    StartDate = department.StartDate,
                    SuperImportantString = department.SuperImportantString,
                    InstructorID = department.InstructorID,
                };
                _context.Add(departmentClone);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(department);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MakeAndDeleteOld([Bind("Name,Budget,StartDate,RowVersion,InstructorID,SuperImportantString")] Department department)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            return View(department);
        }
    }
}
