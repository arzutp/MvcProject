using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ITalentCardService
    {
        List<TalentCard> GetList();
        void Add(TalentCard t);
        TalentCard GetById(int id);
        void Delete(TalentCard t);
        void Update(TalentCard t);
    }
}
