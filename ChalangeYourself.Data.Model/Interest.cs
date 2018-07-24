using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ChalangeYourself.Data.Model
{
    public class Interest
    {
        [Key]
        public int InterestId { get; set; }
        [Required]
        public string Name { get; set; }

        public virtual ICollection<ApplicationUser> Users { get; set; }
        public virtual ICollection<Chalange> Chalanges { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
