using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsProject.EntityLayer.Concrete
{
    public class Pet
    {
        public int PetID { get; set; }
        public string Name { get; set; }
        public string PhotoUrl { get; set; }
        public int Age { get; set; }        
        public string Gender { get; set; }        
        public string Type { get; set; }        
        public DateTime BirthDate { get; set; }
        public DateTime RegisterDate { get; set; }

        // Sahibin kimliğine referans veren alan
        public int OwnerID { get; set; }
        public Owner Owner { get; set; } // Sahip sınıfına referans

       // public string OwnerName { get { return Owner.Name + " " + Owner.Surname; } } // Sahibin adını soyadıyla birleştirme
    }
}

