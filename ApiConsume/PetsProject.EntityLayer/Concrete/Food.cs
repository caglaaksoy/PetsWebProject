using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsProject.EntityLayer.Concrete
{
    public class Food
    {
        public int FoodID { get; set; }
        public string PhotoUrl { get; set; }
        public string Name { get; set; }
        public string Explanation { get; set; }
        public double Price { get; set; }
    }
}
