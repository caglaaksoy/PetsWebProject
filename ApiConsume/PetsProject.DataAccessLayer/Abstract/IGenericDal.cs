using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsProject.DataAccessLayer.Abstract
{
    public interface IGenericDal<T> where T : class
    {
        //CRUD işlemleri tanımlandı parametrelere göre
        void Insert(T t);
        void Delete(T t);
        void Update(T t);
        List<T> GetList();
        T GetByID(int id);
    }
}
