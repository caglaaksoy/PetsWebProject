using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsProject.EntityLayer.Concrete
{
    public class Owner
    {
        public int OwnerID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        // İlişki için hayvanları saklayacak bir koleksiyon 
        public List<Pet> Pets { get; set; } = new List<Pet>();
    }
}
