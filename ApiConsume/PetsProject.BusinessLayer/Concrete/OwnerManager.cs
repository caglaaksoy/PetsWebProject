using PetsProject.BusinessLayer.Abstract;
using PetsProject.DataAccessLayer.Abstract;
using PetsProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsProject.BusinessLayer.Concrete
{
    public class OwnerManager : IOwnerService
    {
        private readonly IOwnerDal _ownerDal;

        public OwnerManager(IOwnerDal ownerDal)
        {
            _ownerDal = ownerDal;
        }

        public void TDelete(Owner t)
        {
            _ownerDal.Delete(t);
        }

        public Owner TGetByID(int id)
        {
           return _ownerDal.GetByID(id);
        }

        public List<Owner> TGetList()
        {
            return _ownerDal.GetList();
        }

        public void TInsert(Owner t)
        {
            _ownerDal.Insert(t);
        }

        public void TUpdate(Owner t)
        {
           _ownerDal.Update(t);
        }
    }
}
