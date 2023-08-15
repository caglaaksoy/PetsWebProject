using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsProject.EntityLayer.Concrete
{
    public class Feature
    {
        public int FeatureID { get; set; }
        public string Photo { get; set; }
        public string Title { get; set; }
        public string Explanation { get; set; }
    }
}
