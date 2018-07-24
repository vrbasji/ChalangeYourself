using System.ComponentModel.DataAnnotations;

namespace ChalangeYourself.Data.Model
{
    public class Sponsor
    {
        [Key]
        public int SponsorId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Contact { get; set; }
        //TODO: more thinks
    }
}
