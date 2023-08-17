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
    public class ShopProcessManager : IShopProcessService
    {
        private readonly IShopProcessDal _shopProcessDal;

        public ShopProcessManager(IShopProcessDal shopProcessDal)
        {
            _shopProcessDal = shopProcessDal;
        }

        public void TDelete(ShopProcess t)
        {
            _shopProcessDal.Delete(t);
        }

        public ShopProcess TGetByID(int id)
        {
            return _shopProcessDal.GetByID(id);
        }

        public List<ShopProcess> TGetList()
        {
            return _shopProcessDal.GetList();
        }

        public void TInsert(ShopProcess t)
        {
            _shopProcessDal.Insert(t);
        }

        public void TUpdate(ShopProcess t)
        {
            _shopProcessDal.Update(t);
        }
    }
}
