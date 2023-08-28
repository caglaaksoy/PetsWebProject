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
    public class PetTypeManager : IPetTypeService
    {
        private readonly IPetTypeDal _petTypeDal;

        public PetTypeManager(IPetTypeDal petTypeDal)
        {
            _petTypeDal = petTypeDal;
        }

        public void TDelete(PetType t)
        {
            _petTypeDal.Delete(t);
        }

        public PetType TGetByID(int id)
        {
           return _petTypeDal.GetByID(id);
        }

        public List<PetType> TGetList()
        {
           return _petTypeDal.GetList();
        }

        public void TInsert(PetType t)
        {
            _petTypeDal.Insert(t);
        }

        public void TUpdate(PetType t)
        {
            _petTypeDal.Update(t);
        }
    }
}
