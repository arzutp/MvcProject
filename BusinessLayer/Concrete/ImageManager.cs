using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ImageManager : IImageService
    {
        IImageFileDal _ımageDal;

        public ImageManager(IImageFileDal ımageFileDal)
        {
            _ımageDal = ımageFileDal;
        }
        public List<ImageFile> GetList()
        {
            return _ımageDal.List();
        }
    }
}
