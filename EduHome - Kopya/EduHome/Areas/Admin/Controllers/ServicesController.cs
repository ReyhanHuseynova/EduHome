using EduHome.DAL;
using EduHome.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ServicesController : Controller
    {
        private readonly AppDbContext _db;
        public ServicesController(AppDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index()
        {
            List<Service> services = await _db.Services.Where(x => x.IsDeactive == false).OrderByDescending(x=>x.Id).ToListAsync();
            return View(services);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(Service service)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
            
                bool isExist = await _db.Services.AnyAsync(x=>x.Name==service.Name);
            if(isExist)
            {
                ModelState.AddModelError("Name", "This service is already exist");
                return View();

            }
           await _db.Services.AddAsync(service);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");


        }
        public async Task<IActionResult> Detail(int? id)
        {
            if(id== null)
            {
                return NotFound();
            }
            Service service = await _db.Services.Where(x=>x.IsDeactive==false).SingleOrDefaultAsync(x=>x.Id==id);
            if (service == null)
            {
                return BadRequest();
            }
            return View(service);
        }
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Service dbService = await _db.Services.SingleOrDefaultAsync(x => x.Id == id);
            if (dbService == null)
            {
                return BadRequest();
            }
            return View(dbService);
        }
        [HttpPost]
        public async Task<IActionResult> Update(int? id,Service service)
        {
            if (id == null)
            {
                return NotFound();
            }
            Service dbService = await _db.Services.SingleOrDefaultAsync(x => x.Id == id);
            if (dbService == null)
            {
                return BadRequest();
            }
            bool isExist = await _db.Services.AnyAsync(x => x.Name == service.Name&& x.Id!=id);
            if (isExist)
            {
                ModelState.AddModelError("Name", "This service is already exist");
                return View();

            }
            dbService.Name = service.Name;
            dbService.Description = service.Description;
            await _db.SaveChangesAsync();

            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Service dbService = await _db.Services.SingleOrDefaultAsync(x => x.Id == id);
            if (dbService == null)
            {
                return BadRequest();
            }
            dbService.IsDeactive = true;
            await _db.SaveChangesAsync();   
            return  RedirectToAction("Index");   
        }

    }
}
