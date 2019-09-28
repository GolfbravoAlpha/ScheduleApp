using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using ScheduleApp.Models;

namespace ScheduleApp.Models
{
    public class staffHoursWorked
    {
        public int id { get; set; }
        public DateTime startDateAndTime { get; set; }
        public DateTime endDateAndTime { get; set; }
        public Staff staff { get; set; }
        public int? staffId { get; set; }
    }
}
