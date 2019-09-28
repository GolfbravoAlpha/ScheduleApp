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
    public class StudentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StudentController(ApplicationDbContext context)
        {
            this._context = context;
        }
        // GET: api/Student
        [HttpGet]
        public IEnumerable<Student> GetStudent()
        {
            //the include allows information from another table to come through 
            return _context.StudentTbl
               .ToList();
        }

        // GET: api/Student/5
        [HttpGet("{id}")]
        public IEnumerable<Student> GetStudent(int id)
        {
            var student = from s in _context.StudentTbl
                        .Where(s => s.id == id)
                        .ToList()
                        select s;

            return student;
        }

        // POST: api/Student
        [HttpPost]
        public async Task<ActionResult<Student>> PostStudent
            (Student studentObject)
        {
            _context.StudentTbl.Add(studentObject);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetStudent),
                new { id = studentObject.id }, studentObject);
        }

        // PUT: api/Student/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudent(int id, Student studentObject)
        {
            if (id != studentObject.id)
            {
                return BadRequest();
            }

            _context.Entry(studentObject).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var studentObject = await _context.StudentTbl.FindAsync(id);

            if (studentObject == null)
            {
                return NotFound();
            }

            _context.StudentTbl.Remove(studentObject);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
