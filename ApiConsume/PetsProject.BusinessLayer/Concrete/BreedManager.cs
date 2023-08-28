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
    public class BreedManager : IBreedService
    {
        private readonly IBreedDal _breedDal;

        public BreedManager(IBreedDal breedDal)
        {
            _breedDal = breedDal;
        }

        public void TDelete(Breed t)
        {
            _breedDal.Delete(t);
        }

        public Breed TGetByID(int id)
        {
            return _breedDal.GetByID(id);
        }

        public List<Breed> TGetList()
        {
           return _breedDal.GetList();
        }

        public void TInsert(Breed t)
        {
            _breedDal.Insert(t);
        }

        public void TUpdate(Breed t)
        {
            _breedDal.Update(t);
        }
    }
}
