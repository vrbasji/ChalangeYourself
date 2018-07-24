using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChalangeYourself.Data.Model
{
    public class ProposalChalange
    {
        [Key]
        public int ProposalChalangeId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public virtual ApplicationUser User { get; set; }
        [Required]
        [DefaultValue(0)]
        public int Points { get; set; }

        public virtual ICollection<ApplicationUser> UserVotes { get; set; }
    }
}
