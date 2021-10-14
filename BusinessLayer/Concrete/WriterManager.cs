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
    public class WriterManager : IWriterService
    {
        IWriterDal _writerDal;

        public WriterManager(IWriterDal writerDal)
        {
            _writerDal = writerDal;
        }

        public void Add(Writer writer)
        {
            _writerDal.Insert(writer);
        }

        public void Delete(Writer writer)
        {
            _writerDal.Delete(writer);
        }

        public Writer GetById(int id)
        {
            return _writerDal.Get(x => x.WriterId == id);
        }

        public List<Writer> GetList()
        {
            return _writerDal.List();
        }

        public int GetLogin(string p)
        {
            //p = (string)Session["WriterMail"];
            return _writerDal.List(x => x.WriterMail == p).Select(y => y.WriterId).FirstOrDefault();     
        }

        public Writer Login(Writer writer)
        {
            //string userN = Hashing.MD5Olustur(writer.WriterMail);
            //string sifre = Hashing.MD5Olustur(writer.WriterPassword);
            return _writerDal.Get(x => x.WriterMail == writer.WriterMail && x.WriterPassword == writer.WriterPassword);
        }

        public void Update(Writer writer)
        {
            _writerDal.Update(writer);
        }
    }
}
