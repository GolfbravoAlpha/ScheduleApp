using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using ScheduleApp.Models;


namespace ScheduleApp.Models
{
    public class ScheduleDateAndTime
    {
        public int id { get; set; }
        public DateTime startDateAndTime { get; set; }
        public DateTime endDateAndTime { get; set; }

        public Student student { get; set; }
        public int? studentId { get; set; }
        public Staff staff { get; set; }
        public int? staffId { get; set; }
    }
}
