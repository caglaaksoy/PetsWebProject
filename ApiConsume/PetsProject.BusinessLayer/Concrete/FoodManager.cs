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
    public class FoodManager : IFoodService
    {
        private readonly IFoodDal _foodDal;

        public FoodManager(IFoodDal foodDal)
        {
            _foodDal = foodDal;
        }

        public void TDelete(Food t)
        {
            _foodDal.Delete(t);
        }

        public Food TGetByID(int id)
        {
            return _foodDal.GetByID(id);
        }

        public List<Food> TGetList()
        {
           return _foodDal.GetList();
        }

        public void TInsert(Food t)
        {
            _foodDal.Insert(t);
        }

        public void TUpdate(Food t)
        {
            _foodDal.Update(t);
        }
    }
}
