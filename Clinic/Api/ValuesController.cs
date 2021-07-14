using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clinic.Data;
using Clinic.Models;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Clinic.NewFolder
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ValuesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<List<Specialization>> Get()
        {
            return await _context.Specializations.ToListAsync();
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Specialization>> Get(long id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specialization = await _context.Specializations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (specialization == null)
            {
                return NotFound();
            }

            return specialization;
        }

        // POST api/<ValuesController>
        [HttpPost]
        public async void Post([FromBody] Specialization specialization)
        {
            if (ModelState.IsValid)
            {
                _context.Add(specialization);
                await _context.SaveChangesAsync();
            }
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public async void Put(long id, [FromBody] Specialization specialization)
        {
            if (id != specialization.Id)
            {
                NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(specialization);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpecializationExists(specialization.Id))
                    {
                        NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public async void Delete(long id)
        {
            var specialization = await _context.Specializations.FindAsync(id);
            _context.Specializations.Remove(specialization);
            await _context.SaveChangesAsync();
        }

        private bool SpecializationExists(long id)
        {
            return _context.Specializations.Any(e => e.Id == id);
        }
    }
}
