using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IContactService
    {
        void Add(Contact contact);
        void Update(Contact contact);
        void Delete(Contact contact);
        Contact GetById(int id);
        List<Contact> GetList();
    }
}
