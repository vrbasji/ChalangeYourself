using ChalangeYourself.Data.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ChalangeYourself.Website.Models
{
    public class UserProfileViewModels
    {
        [Display(Name = "Přezdívka")]
        public string Username { get; set; }
        [Display(Name = "Počet bodů")]
        public int Points { get; set; }
        public IEnumerable<Chalange> Chalanges { get; set; }
        [Display(Name = "Zájmy")]
        public IEnumerable<Interest> Interests { get; set; }
    }
}