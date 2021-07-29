using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Clinic.Data;
using Clinic.Helper;
using Clinic.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

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

        public async Task<List<CountryModel>> Api()
        {
            string Baseurl = "https://restcountries.eu/rest/v2/all";

            List<CountryModel> country = new List<CountryModel>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync(Baseurl);

                if (Res.IsSuccessStatusCode)
                {
                    var CountryResponse = Res.Content.ReadAsStringAsync().Result;
                    country = JsonConvert.DeserializeObject<List<CountryModel>>(CountryResponse);


                }

                return country;
            }
        }
    }
}
