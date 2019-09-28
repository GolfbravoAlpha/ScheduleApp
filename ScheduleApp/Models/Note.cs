using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScheduleApp.Models
{
    public class Note
    {
        public int id { get; set; }
        public DateTime dateOfNote { get; set; }
        public string mainBodyOfNote { get; set; }
    }
}
