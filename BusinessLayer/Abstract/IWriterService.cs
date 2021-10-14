using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IWriterService
    {
        int GetLogin(string p);
        List<Writer> GetList();
        void Add(Writer writer);
        void Delete(Writer writer);
        void Update(Writer writer);
        Writer GetById(int id);
        Writer Login(Writer writer);
    }
}
