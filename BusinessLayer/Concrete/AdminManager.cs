using BusinessLayer.Abstract;
using BusinessLayer.Utilities;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AdminManager : IAdminService
    {
        IAdminDal _adminDal;
        public AdminManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }
        public void Add(Admin a)
        {
            _adminDal.Insert(a);
        }

        public void Delete(Admin a)
        {
            _adminDal.Delete(a);
        }

        public Admin GetById(int id)
        {
            return _adminDal.Get(x => x.AdminId == id);
        }

        public List<Admin> GetList()
        {
            return _adminDal.List();
        }

        public Admin Login(Admin a)
        {
            string userN = Hashing.MD5Olustur(a.AdminUserName);
            string sifre = Hashing.MD5Olustur(a.AdminPassword);
            return _adminDal.Get(x => x.AdminUserName == userN && x.AdminPassword == sifre);
        }

        public void Update(Admin a)
        {
            _adminDal.Update(a);
        }
    }
}
