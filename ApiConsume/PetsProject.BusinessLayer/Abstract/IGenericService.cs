using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsProject.BusinessLayer.Abstract
{
    public interface IGenericService<T> where T : class
    {
        //Managerda çağırırken dataaccessdeki crud işlemleriyle karışmamsın diye T ekledik
        void TInsert(T t);
        void TDelete(T t);
        void TUpdate(T t);
        List<T> TGetList();
        T TGetByID(int id);
    }
}
