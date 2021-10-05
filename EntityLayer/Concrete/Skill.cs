using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Skill
    {
        [Key]
        public int skillId { get; set; }

        [StringLength(50)]
        public string skillName { get; set; }

        public byte SkillLevel { get; set; }

        public int TalentId { get; set; }
        public virtual TalentCard TalentCard { get; set; }
    }
}
