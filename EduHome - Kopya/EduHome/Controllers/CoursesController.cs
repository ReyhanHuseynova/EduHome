using EduHome.DAL;
using EduHome.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace EduHome.Controllers
{
    public class CoursesController : Controller
    {
        private readonly AppDbContext _db;
        public CoursesController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
          List<Course>courses=_db.Courses.OrderByDescending(x=>x.Id).Take(3).ToList();
            ViewBag.CourseCount = _db.Courses.Count();   
            return View(courses);
        }
        public IActionResult LoadMore(int skip)
        {
            if (_db.Courses.Count() <= skip)
            {
                return Content("...");
            }
            List<Course> courses = _db.Courses.OrderByDescending(x => x.Id).Skip(skip).Take(3).ToList();
            return PartialView("_LoadMoreCoursesPartial", courses);
        }
    }
}
