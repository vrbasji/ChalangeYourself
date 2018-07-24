using System.ComponentModel.DataAnnotations;

namespace ChalangeYourself.Data.Model
{
    public class ShipingAddress
    {
        [Key]
        public int ShipingAddressId { get; set; }
        [Required]
        public string City { get; set; }
        public string Country { get; set; }
        [Required]
        public int PostCode { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
    }
}
