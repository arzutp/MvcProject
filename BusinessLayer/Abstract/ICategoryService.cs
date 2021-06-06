using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetList();
        void CategoryAdd(Category category);
        Category GetById(int id);  //id ile istenen idnin tüm verilerini bulduk
        void CategoryDelete(Category category);  //tüm verileri bulduktan sonra silme işlemi gerçekleştirdik
        void CategoryUpdate(Category category);
    }
}
