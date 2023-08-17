using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsProject.EntityLayer.Concrete
{
    public class Blog
    {
        public int BlogID { get; set; }
        public string BlogTitle { get; set; }
        public string Writer { get; set; }
        public string BlogPhotoUrl { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
    }
}
