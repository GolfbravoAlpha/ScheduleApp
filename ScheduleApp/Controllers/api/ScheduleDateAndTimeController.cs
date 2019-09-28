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
    public class ScheduleDateAndTimeController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ScheduleDateAndTimeController(ApplicationDbContext context)
        {
            this._context = context;
        }

        // GET: api/ScheduleDateAndTime
        [HttpGet]
        public IEnumerable<ScheduleDateAndTime> GetScheduleDateAndTime()
        {
            //the include allows information from another table to come through 
            return _context.ScheduleDateAndTimeTbl
                .Include(c => c.student)
                .Include(c => c.staff)
                .ToList();
        }   

        //POST: api/ScheduleDateAndTime
        [HttpPost]
        public async Task<ActionResult<ScheduleDateAndTime>> PostScheduleDateAndTime
            (ScheduleDateAndTime scheduleObject)
        {
            _context.ScheduleDateAndTimeTbl.Add(scheduleObject);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetScheduleDateAndTime),
                new { id = scheduleObject.id }, scheduleObject);            
        }

        // PUT: api/ScheduleDateAndTime/5
        [HttpPut("{id}")]    
        public async Task<IActionResult> PutScheduleDateAndTime(int id, ScheduleDateAndTime scheduleObject)
        {
            if (id != scheduleObject.id)
            {
                return BadRequest();
            }

            _context.Entry(scheduleObject).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/ScheduleDateAndTime/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteScheduleDateAndTime(int id)
        {
            var scheduleObject = await _context.ScheduleDateAndTimeTbl.FindAsync(id);

            if (scheduleObject == null)
            {
                return NotFound();
            }

            _context.ScheduleDateAndTimeTbl.Remove(scheduleObject);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
