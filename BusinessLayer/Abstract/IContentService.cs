using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IContentService
    {
        List<Content> GetList();
        List<Content> GetListByHeadingId(int id); //Parametre ile listeleme
        void Add(Content content);
        void Delete(Content content);
        Content GetById(int id);
        void Update(Content content);

    }
}
