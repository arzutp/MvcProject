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
    public class SkillManager : ISkillService
    {
        ISkillDal _skillDal;

        public SkillManager(ISkillDal skillDal)
        {
            _skillDal = skillDal;
        }

        public void Add(Skill s)
        {
            _skillDal.Insert(s);
        }

        public void Delete(Skill s)
        {
            _skillDal.Delete(s);
        }

        public Skill GetById(int id)
        {
            return _skillDal.Get(x => x.skillId == id);
        }

        public List<Skill> GetList()
        {
            return _skillDal.List();
        }

        public void Update(Skill s)
        {
            _skillDal.Update(s);
        }
    }
}
