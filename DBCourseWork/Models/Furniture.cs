using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBCourseWork.Models
{
    public class Furniture
    {
        public int Id { get; set; }
        public Order Order { get; set; }
        public string Address { get; set; }

        public override string ToString()
        {
            return $"Order #{Order.Id} for {Order.Client.Name} at {Address}";
        }
    }
}
