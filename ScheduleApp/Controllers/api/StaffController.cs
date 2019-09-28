using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ScheduleApp.Data;
using ScheduleApp.Models;

namespace ScheduleApp.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StaffController(ApplicationDbContext context)
        {
            this._context = context;
        }

        // GET: api/Staff
        [HttpGet]
        public IEnumerable<Staff> GetStaff()
        {
            //the include allows information from another table to come through 
             return _context.StaffTbl
                .ToList();
        }

        // GET: api/Staff/5
        [HttpGet("{id}")]
        public IEnumerable<Staff> GetStaff(int id)      
        {
            var staff = from s in _context.StaffTbl
                        .Where(s => s.id == id)
                        .ToList()
                        select s;

            return staff;
        }

        // POST: api/Staff
        [HttpPost]
        public async Task<ActionResult<Staff>> PostStaff
            (Staff staffObject)
        {
            _context.StaffTbl.Add(staffObject);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetStaff),
                new { id = staffObject.id }, staffObject);
        }

        // PUT: api/Staff/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStaff(int id, Staff staffObject)
        {
            if (id != staffObject.id)
            {
                return BadRequest();
            }

            _context.Entry(staffObject).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStaff(int id)
        {
            var staffObject = await _context.StaffTbl.FindAsync(id);

            if (staffObject == null)
            {
                return NotFound();
            }

            _context.StaffTbl.Remove(staffObject);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
