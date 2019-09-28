using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScheduleApp.Models
{
    public class Student
    {
        public int id { get; set; }
        public string name { get; set; }
        public byte age { get; set; }
        public string subjectStudying { get; set; }
        public string disability { get; set; }
        public string additionalInformation { get; set; }
    }
}
