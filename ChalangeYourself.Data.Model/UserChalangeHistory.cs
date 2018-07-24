using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChalangeYourself.Data.Model
{
    public class UserChalangeHistory
    {
        [Key, Column(Order = 0)]
        [ForeignKey("User")]
        public string UserId { get; set; }
        [Key, Column(Order = 1)]
        [ForeignKey("Chalange")]
        public int ChalangeId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual Chalange Chalange { get; set; }
        [Required]
        public int PointsGained { get; set; }
    }
}
