using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBCourseWork.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Workplace { get; set; }
        public User Worker { get; set; }
        public string Parts { get; set; }
    }
}
