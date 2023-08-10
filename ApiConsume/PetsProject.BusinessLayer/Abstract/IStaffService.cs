using PetsProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsProject.BusinessLayer.Abstract
{
    public interface IStaffService:IGenericService<Staff>
    {

        //BURAYA ÖZEL FONKSİYONLARI YAZACAĞIZ VE CONTROLLARDA BU ÖZEL FONKSİYONLARI GETİRMEK İÇİN PRİVATE READONLY YAPIYORUZ.
    }
}
