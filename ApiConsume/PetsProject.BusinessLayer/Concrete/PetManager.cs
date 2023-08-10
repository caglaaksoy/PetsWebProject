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
    public class PetManager : IPetService
    {
        private readonly IPetDal _petDal;

        public PetManager(IPetDal petDal)
        {
            _petDal = petDal;
        }

        public void TDelete(Pet t)
        {
           _petDal.Delete(t);
        }

        public Pet TGetByID(int id)
        {
            return _petDal.GetByID(id);
        }

        public List<Pet> TGetList()
        {
           return _petDal.GetList();
        }

        public void TInsert(Pet t)
        {
          _petDal.Insert(t);
        }

        public void TUpdate(Pet t)
        {
            _petDal.Update(t);
        }
    }
}
