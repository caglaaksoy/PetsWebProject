using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsProject.EntityLayer.Concrete
{
    public class Service
    {
        public int ServiceID { get; set; }
        public string Name { get; set; }
        public string Explanation { get; set; }
        public string PhotoUrl { get; set; }
    }
}
