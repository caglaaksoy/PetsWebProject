using PetsProject.DataAccessLayer.Abstract;
using PetsProject.DataAccessLayer.Concrete;
using PetsProject.DataAccessLayer.Repositories;
using PetsProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsProject.DataAccessLayer.EntityFramework
{
    public class EfFooterDal : GenericRepository<Footer>, IFooterDal
    {
        public EfFooterDal(Context context) : base(context)
        {

        }
    }
}
