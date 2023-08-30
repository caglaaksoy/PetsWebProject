using System.Collections.Generic;

namespace PetsProject.EntityLayer.Concrete
{
    public class Breed
    {
        public int BreedID { get; set; }
        public string BreedName { get; set; }



        public int PetTypeID { get; set; }
        public PetType PetType { get; set;}


        public List<Pets> Pets { get; set; }
    }
}
