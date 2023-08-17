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
    public class ClientLogoManager : IClientLogoService
    {
        private readonly IClientLogoDal _clientLogoDal;

        public ClientLogoManager(IClientLogoDal clientLogoDal)
        {
            _clientLogoDal = clientLogoDal;
        }

        public void TDelete(ClientLogo t)
        {
            _clientLogoDal.Delete(t);
        }

        public ClientLogo TGetByID(int id)
        {
            return _clientLogoDal.GetByID(id);
        }

        public List<ClientLogo> TGetList()
        {
           return _clientLogoDal.GetList();
        }

        public void TInsert(ClientLogo t)
        {
            _clientLogoDal.Insert(t);
        }

        public void TUpdate(ClientLogo t)
        {
            _clientLogoDal.Update(t);
        }
    }
}
