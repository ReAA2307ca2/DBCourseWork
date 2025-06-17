using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DBCourseWork.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string password { get; set; }
        public Role Role { get; set; }

        public override string ToString()
        {
            return $"User: {Name} with role: {Role}";
        }
    }
}
