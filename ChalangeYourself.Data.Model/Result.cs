using System.ComponentModel.DataAnnotations;

namespace ChalangeYourself.Data.Model
{
    public class Result
    {
        [Key]
        public int ResultId { get; set; }
        [Required]
        public int Place { get; set; }
        [Required]
        public int Point { get; set; }
        public string Comment { get; set; }
        [Required]
        public virtual ApplicationUser User { get; set; }
        [Required]
        public string ResultLink { get; set; }
        public virtual ChalangePrice Price { get; set; }
    }
}
