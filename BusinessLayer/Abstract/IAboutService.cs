using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAboutService
    {
        List<About> GetList();
        void Add(About about);
        About GetById(int id);  //id ile istenen idnin tüm verilerini bulduk
        void Delete(About about);  //tüm verileri bulduktan sonra silme işlemi gerçekleştirdik
        void Update(About about);
    }
}
