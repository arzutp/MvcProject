using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager
    {
        GenericRepository<Category> repository = new GenericRepository<Category>();
        public List<Category> GetAllBl()
        {
            return repository.List();
        }

        public void CategoryAddBl(Category category)
        {
            if(category.CategoryName == "" || category.CategoryName.Length <= 3 || 
                category.CategoryDescriotion == "" || category.CategoryName.Length >= 51)
            {
                //hata mesajı
            }
            else
            {
                repository.Insert(category);
            }
        }
    }
}
