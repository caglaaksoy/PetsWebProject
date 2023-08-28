using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsProject.EntityLayer.Concrete
{
    public class PetType
    {
        public int PetTypeID { get; set; }
        public string PetTypeName { get; set; }
        public List<Pets> Pets { get; set; }
    }
}
