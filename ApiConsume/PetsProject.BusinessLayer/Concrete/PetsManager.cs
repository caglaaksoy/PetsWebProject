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
    public class PetsManager : IPetsService
    {
       
        private readonly IPetsDal _petsDal;

        public PetsManager(IPetsDal petDal)
        {
            _petsDal = petDal;
        }

        public void TDelete(Pets t)
        {
            _petsDal.Delete(t);
        }

        public Pets TGetByID(int id)
        {
            return _petsDal.GetByID(id);
        }

        public List<Pets> TGetList()
        {
            return _petsDal.GetList();
        }

        public void TInsert(Pets t)
        {
            _petsDal.Insert(t);
        }

        public void TUpdate(Pets t)
        {
            _petsDal.Update(t);
        }
    }
}
