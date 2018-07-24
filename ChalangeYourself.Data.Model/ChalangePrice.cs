using System.ComponentModel.DataAnnotations;

namespace ChalangeYourself.Data.Model
{
    public class ChalangePrice
    {
        [Key]
        public int ChalangePriceId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public virtual Sponsor SponsorInfo { get; set; }
    }
}
