﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsProject.EntityLayer.Concrete
{
    public class Pets
    {
        public int PetsID { get; set; }
        public string Name { get; set; }
        public string PhotoUrl { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime RegisterDate { get; set; }



        public int BreedID { get; set; }
        public Breed Breed { get; set; }



        public int AppUserId { get; set; } 
        public AppUser AppUser { get; set; }
    }
}
