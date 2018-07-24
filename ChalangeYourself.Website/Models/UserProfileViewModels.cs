using ChalangeYourself.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChalangeYourself.Website.Models
{
    public class UserProfileViewModels
    {
        public string Username { get; set; }
        public int Points { get; set; }
        public IEnumerable<Chalange> Chalanges { get; set; }
        public IEnumerable<Interest> Interests { get; set; }
    }
}