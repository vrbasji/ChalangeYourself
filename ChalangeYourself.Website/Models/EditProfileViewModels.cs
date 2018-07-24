using ChalangeYourself.Data.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChalangeYourself.Website.Models
{
    public class EditProfileViewModels
    {
        [Display(Name = "Jméno")]
        public string FirstName { get; set; }
        [Display(Name = "Příjmení")]
        public string LastName { get; set; }
        [Display(Name = "Datum narození")]
        public DateTime? DateOfBirth { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Telefoní číslo")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Uživatelské jméno")]
        public string UserName { get; set; }
        [Display(Name = "Město")]
        public string City { get; set; }
        [Display(Name = "Země")]
        public string Country { get; set; }
        [Display(Name = "Směrovací číslo")]
        public int PostCode { get; set; }
        [Display(Name = "Ulice")]
        public string Street { get; set; }
        [Display(Name = "Číslo domu")]
        public string HouseNumber { get; set; }
        [Display(Name = "Vaše zájmy")]
        public List<SelectListItem> AllInterests { get; set; }
        public int[] InterestIds { get; set; }
    }
}