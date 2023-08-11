using PetsProject.EntityLayer.Concrete;
using System.Collections.Generic;

namespace PetsProject.WebUI.Dtos.OwnerDto
{
    public class ResultOwnerDto
    {
        public int OwnerID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<Pets> Petss { get; set; }
    }
}
