using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clinic.Data;
using Clinic.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Controllers
{
    public class TestController : Controller
    {
        private readonly ApplicationDbContext _db;
        public TestController(ApplicationDbContext _context)
        {
            _db = _context;
        }
        public IActionResult Index()
        {
            var specialization = _db.Specializations.ToList();
            return View(specialization);
        }

        public async Task<IActionResult> Detail(long? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            var specialization = await _db.Specializations.FirstOrDefaultAsync(s => s.Id == id);
            if (specialization == null)
            {
                return NotFound();
            }
            return View(specialization);
        }

        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            var specialization = await _db.Specializations.FindAsync(id);

            return View(specialization);
        }
        [HttpPost]
        public IActionResult Save(Specialization specialization)
        {
            _db.Specializations.Update(specialization);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(long id)
        {
            var specialization = _db.Specializations.Find(id);
            if (specialization == null)
            {
                return NotFound();
            }
            _db.Specializations.Remove(specialization);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Specialization specialization)

        {
            _db.Specializations.Add(specialization);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
