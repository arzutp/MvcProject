using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAdminService 
    {
        List<Admin> GetList();
        void Add(Admin a);
        Admin GetById(int id);  
        void Delete(Admin a);  
        void Update(Admin a);
        Admin Login(Admin a);
    }
}
