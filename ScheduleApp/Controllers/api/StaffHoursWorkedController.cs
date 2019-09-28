using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ScheduleApp.Data;
using ScheduleApp.Models;

namespace ScheduleApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffHoursWorkedController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StaffHoursWorkedController(ApplicationDbContext context)
        {
            this._context = context;
        }
  

        // GET: api/StaffHoursWorked
        [HttpGet]
        public IEnumerable<staffHoursWorked> GetStaffHoursWorked()
        {
            //the include allows information from another table to come through 
            return _context.staffHoursWorkedTbl
                .Include(c => c.staff)
                .ToList();
        }

        //get all staff on for a particular day  
        [HttpGet("{startDateTimeQuery}")]
        public IEnumerable<staffHoursWorked> GetStaffHoursWorked(DateTime startDateTimeQuery)
        {
            DateTime lastDayDateTimeQuery = startDateTimeQuery.AddDays(1);

            var staffHours = from s in _context.staffHoursWorkedTbl
                .Include(c => c.staff)
                .Where(s => s.startDateAndTime >= startDateTimeQuery &&
                s.startDateAndTime <= lastDayDateTimeQuery)
                .ToList()
                select s;

            return staffHours;
        }

        // GET: api/StaffHoursWorked/5
        [HttpGet("{id}/{startDateTimeQuery}")]
        public IEnumerable<staffHoursWorked> GetStaffHoursWorked(int id, DateTime startDateTimeQuery)
        {            
            DateTime lastDayDateTimeQuery = startDateTimeQuery.AddDays(7);

            var staffHours = from s in _context.staffHoursWorkedTbl
                .Include(c => c.staff)                
                .Where(s => s.staffId == id &&
                s.startDateAndTime >= startDateTimeQuery &&
                s.startDateAndTime <= lastDayDateTimeQuery)
                .ToList()
                select s;          
           
            return staffHours;            
        }

        

        // POST: api/StaffHoursWorked
        [HttpPost]        
        public async Task<ActionResult<staffHoursWorked>> PostScheduleDateAndTime
            (staffHoursWorked hoursWorkedObject)
        {
            _context.staffHoursWorkedTbl.Add(hoursWorkedObject);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetStaffHoursWorked),
                new { id = hoursWorkedObject.id }, hoursWorkedObject);
        }

        // PUT: api/StaffHoursWorked/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutScheduleDateAndTime(int id, staffHoursWorked hoursWorkedObject)
        {
            if (id != hoursWorkedObject.id)
            {
                return BadRequest();
            }

            _context.Entry(hoursWorkedObject).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/StaffHoursWorked/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteScheduleDateAndTime(int id)
        {
            var hoursWorkedObject = await _context.staffHoursWorkedTbl.FindAsync(id);

            if (hoursWorkedObject == null)
            {
                return NotFound();
            }

            _context.staffHoursWorkedTbl.Remove(hoursWorkedObject);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
