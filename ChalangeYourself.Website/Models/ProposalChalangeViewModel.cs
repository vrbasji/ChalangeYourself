using ChalangeYourself.Data.Model;
using ChalangeYourself.Data.Model.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ChalangeYourself.Website.Models
{
    public class ProposalChalangeViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ApplicationUser User { get; set; }
    }

    public class ProposalChalangeAdminViewModel
    {
        public int ProposalChalangeId { get; set; }
        [Required]
        [Display(Name = "Název")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Popis")]
        public string Description { get; set; }
        public string UserId { get; set; }
        [Required]
        [Display(Name = "Počet bodů")]
        public int Points { get; set; }
        public bool Activated { get; set; }

        public IEnumerable<string> UserVoteIds { get; set; }
        [Required]
        [Display(Name = "Začátek")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }
        [Required]
        [Display(Name = "Konec")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }
        [Required]
        public string ThumbnailUrl { get; set; }
        [Required]
        [Display(Name = "Obtížnost")]
        public Difficulty Difficulty { get; set; }
        [Required]
        [Display(Name = "Minimální doporučený věk")]
        public int MinAge { get; set; }
        [Required]
        [Display(Name = "Maximální doporučený věk")]
        public int MaxAge { get; set; }
        public IEnumerable<Interest> Interests { get; set; }
    }
}