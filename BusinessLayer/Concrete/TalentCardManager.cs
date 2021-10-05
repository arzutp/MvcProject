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
    public class TalentCardManager : ITalentCardService
    {
        ITalentCardDal _talentCardDal;

        public TalentCardManager(ITalentCardDal talentCardDal)
        {
            _talentCardDal = talentCardDal;
        }

        public void Add(TalentCard t)
        {
            _talentCardDal.Insert(t);
        }

        public void Delete(TalentCard t)
        {
            _talentCardDal.Delete(t);
        }

        public TalentCard GetById(int id)
        {
            return _talentCardDal.Get(x => x.TalentId == id);
        }

        public List<TalentCard> GetList()
        {
            return _talentCardDal.List();
        }

        public void Update(TalentCard t)
        {
            _talentCardDal.Update(t);
        }
    }
}
