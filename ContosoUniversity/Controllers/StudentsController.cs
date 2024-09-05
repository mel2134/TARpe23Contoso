﻿using ContosoUniversity.Data;
using ContosoUniversity.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ContosoUniversity.Controllers
{
    public class StudentsController : Controller
    {
        private readonly SchoolContext _context;

        public StudentsController(SchoolContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Students.ToListAsync());
        }
        /*
        public async Task<IActionResult> Index(
            string sortOrder,
            string currentFilter, 
            string searchString,
            int? pageNumber
            )
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParam"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateSortParam"] = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewData["currentFilter"] = searchString;

            var students = from student in _context.Students
                           select student;
            if (!String.IsNullOrEmpty(searchString))
            {
                students = students.Where(
                    student => student.LastName.Contains(searchString) || 
                    student.FirstMidName.Contains(searchString)
                    );
            }
            switch (sortOrder)
            {
                case "name_desc":
                    students = students.OrderByDescending(student => student.LastName);
                    break;
                case "firstname_desc":
                    students = students.OrderByDescending(student => student.FirstMidName);
                    break;
                case "Date":
                    students = students.OrderByDescending(student => student.EnrollmentDate);
                    break;
                case "date_desc":
                    students = students.OrderByDescending(student => student.EnrollmentDate);
                    break;
                default:
                    students = students.OrderBy(student => student.LastName);
                    break;
            }
            int pageSize = 3;
            return View(await _context.Students.ToListAsync())
            //return View(await PaginatedList<Student>.CreateAsync(students.AsNoTracking(),pageNumber ?? 1,pageSize));
        }
        */

        //create get, haarab vaatest andmed mida create meetod vajab
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        //Create, sisestab uue õpilase andmebaasi
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,LastName,FirstMidName,EnrollmentDate")] Student student)
        {
           if (ModelState.IsValid)
           {
                _context.Students.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
           }
           return View(student);
        }


        // Delete GET student from the db 
        //[HttpGet]
        public async Task<IActionResult> Delete(int ?ID)
        {
            if (ID == null)
            {
                return NotFound();
            }
            var student = await _context.Students.FirstOrDefaultAsync(m => m.ID == ID);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        //Delete POST student from the db
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int ID)
        {
            var student = await _context.Students.FindAsync(ID);
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int ?ID)
        {
            if (ID == null)
            {
                return NotFound();
            }
            var student = await _context.Students.FirstOrDefaultAsync(m => m.ID == ID);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }



    }
}
