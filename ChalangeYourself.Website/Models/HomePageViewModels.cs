using System;
using System.Collections.Generic;

namespace ChalangeYourself.Website.Models
{
    public class HomePageViewModel
    {
        public List<ChalangeOverViewViewModel> Chalanges { get; set; }
        public List<UserRankViewModel> UserRanks { get; set; }
        public List<ProposalChalangeRankViewModel> ProposalChalangesRanks { get; set; }
    }

    public class ChalangeOverViewViewModel
    {
        public int ChalangeId { get; set; }
        public string ChalangeImageUrl { get; set; }
        public DateTime FinishAt { get; set; }
    }

    public class UserRankViewModel
    {
        public string UserId { get; set; }
        public string Username { get; set; }
        public int Points { get; set; }
    }

    public class ProposalChalangeRankViewModel
    {
        public int ProposalChalangeId { get; set; }
        public string UserId { get; set; }
        public string Username { get; set; }
        public string ChalangeName { get; set; }
        public int Points { get; set; }

        public List<string> UsersVote { get; set; }
    }
}