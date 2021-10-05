using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class TalentCard
    {
        [Key]
        public int TalentId { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(50)]
        public string UserName { get; set; }
        [StringLength(100)]
        public string TalentAbout { get; set; }

        public ICollection<Skill> Skills { get; set; }

    }
}
