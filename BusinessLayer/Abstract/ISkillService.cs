using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ISkillService
    {
        List<Skill> GetList();
        void Add(Skill s);
        Skill GetById(int id);
        void Delete(Skill s);
        void Update(Skill s);
    }
}
