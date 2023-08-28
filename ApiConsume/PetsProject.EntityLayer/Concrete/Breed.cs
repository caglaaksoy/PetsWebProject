using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsProject.EntityLayer.Concrete
{
    public class Breed
    {
        public int BreedID { get; set; }
        public string BreedName { get; set; }
        public List<Pets> Pets { get; set; }
    }
}
