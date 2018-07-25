using ChalangeYourself.Data.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChalangeYourself.Website.Models
{
    public class DetailChalangeViewModel
    {
        public int ChalangeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string ThumbnailUrl { get; set; }
        public Difficulty Difficulty { get; set; }
        public int MinAge { get; set; }
        public int MaxAge { get; set; }

        public IEnumerable<DetailChalangeUserViewModel> RegisteredUsers { get; set; }
        public IEnumerable<string> InterestsTags { get; set; }
        public IEnumerable<string> Prices { get; set; }

    }
    public class DetailChalangeUserViewModel
    {
        public string UserId { get; set; }
        public string Username { get; set; }
        public int Points { get; set; }
    }
}