using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBCourseWork.Models
{
    public class Team
    {
        public int Id { get; set; }

        public override string ToString()
        {
            return Id.ToString();
        }
    }
}
