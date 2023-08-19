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
    public class FooterManager : IFooterService
    {
        private readonly IFooterDal _footerDal;

        public FooterManager(IFooterDal footerDal)
        {
            _footerDal = footerDal;
        }

        public void TDelete(Footer t)
        {
            _footerDal.Delete(t);
        }

        public Footer TGetByID(int id)
        {
           return _footerDal.GetByID(id);
        }

        public List<Footer> TGetList()
        {
           return _footerDal.GetList();
        }

        public void TInsert(Footer t)
        {
            _footerDal.Insert(t);
        }

        public void TUpdate(Footer t)
        {
            _footerDal.Update(t);
        }
    }
}
