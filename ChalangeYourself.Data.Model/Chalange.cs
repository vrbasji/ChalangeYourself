using ChalangeYourself.Data.Model.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ChalangeYourself.Data.Model
{
    public class Chalange
    {
        [Key]
        public int ChalangeId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public DateTime PublishDate { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        [DefaultValue(false)]
        public bool Active { get; set; }
        [Required]
        public string ThumbnailUrl { get; set; }
        [Required]
        public Difficulty Difficulty { get; set; }
        public int MinAge { get; set; }
        public int MaxAge { get; set; }
        [Required]
        public virtual Sponsor SponsorInfo { get; set; }
        public virtual ICollection<Result> Results { get; set; }
        public virtual ICollection<ApplicationUser> Users { get; set; }
        public virtual ICollection<ChalangePrice> Prices { get; set; }
        [Required]
        public virtual ICollection<Interest> Interests { get; set; }
    }
}
