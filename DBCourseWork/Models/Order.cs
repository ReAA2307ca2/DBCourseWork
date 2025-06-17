using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBCourseWork.Models
{
    public class Order
    {
        public int Id { get; set; }
        public Client Client { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            return $"Order #{Id}, Client: {Client.Name}";
        }
    }
}
