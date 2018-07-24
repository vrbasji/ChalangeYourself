using ChalangeYourself.Data.Model;
using ChalangeYourself.Services;
using ChalangeYourself.Services.Database;
using ChalangeYourself.Services.Repositories;
using ChalangeYourself.Website.Models;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ChalangeYourself.Website.Controllers
{
    public class UserController : Controller
    {
        private UserRepository _userRepository;
        private InterestRepository _interestRepository;
        private ChalangeRepository _chalangeRepository;
        private ImageService _imageService = new ImageService();

        public UserController(UserRepository userRepository, InterestRepository interestRepository, ChalangeRepository chalangeRepository)
        {
            _userRepository = userRepository;
            _interestRepository = interestRepository;
            _chalangeRepository = chalangeRepository;
        }

        public ActionResult UserProfile(string userId)
        {
            var user = _userRepository.GetById(userId);
            if (user == null) return View("Error");
            var userChalange = _chalangeRepository.GetChalangeByUserId(user.Id);
            var userProfile = new UserProfileViewModels()
            {
                Username = user.UserName,
                Points = user.Points,
                Interests = user.Interests
            };
            userProfile.Chalanges = userChalange;
            return View("UserProfile", userProfile);
        }
        // GET: User
        public ActionResult EditProfile(string activeUserId)
        {
            if (User.Identity.IsAuthenticated)
            {
                activeUserId = User.Identity.GetUserId();
            }
            var user = _userRepository.GetById(activeUserId);
            var userModel = new EditProfileViewModels()
            {
                DateOfBirth = user.DateOfBirth,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                UserName = user.UserName
            };
            userModel.AllInterests = GetInterestsAsItems(user);

            if (user.ShipingAddress != null)
            {
                userModel.City = user.ShipingAddress.City;
                userModel.Country = user.ShipingAddress.Country;
                userModel.HouseNumber = user.ShipingAddress.HouseNumber;
                userModel.PostCode = user.ShipingAddress.PostCode;
                userModel.Street = user.ShipingAddress.Street;
            }

            return View("EditProfile", userModel);
        }

        [HttpPost]
        public async Task<ActionResult> EditProfile(EditProfileViewModels editProfile, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                var user = _userRepository.GetByEmail(editProfile.Email);
                user.ImagePath = await _imageService.SaveImage(upload);
                user.DateOfBirth = editProfile.DateOfBirth;
                user.FirstName = editProfile.FirstName;
                user.LastName = editProfile.LastName;
                user.PhoneNumber = editProfile.PhoneNumber;
                if (user.ShipingAddress == null)
                {
                    var shippingAddress = new ShipingAddress();
                    shippingAddress.City = editProfile.City;
                    shippingAddress.Country = editProfile.Country;
                    shippingAddress.HouseNumber = editProfile.HouseNumber;
                    shippingAddress.PostCode = editProfile.PostCode;
                    shippingAddress.Street = editProfile.Street;
                    user.ShipingAddress = shippingAddress;
                }
                else
                {
                    user.ShipingAddress.City = editProfile.City;
                    user.ShipingAddress.Country = editProfile.Country;
                    user.ShipingAddress.HouseNumber = editProfile.HouseNumber;
                    user.ShipingAddress.PostCode = editProfile.PostCode;
                    user.ShipingAddress.Street = editProfile.Street;
                }

                _interestRepository.UpdateUserInterestsByIds(user, editProfile.InterestIds);

                _userRepository.Edit(user);
                ViewBag.Message = "Uživatelská data byla upravena";
            }

            return View("UserProfile");
        }
        private List<SelectListItem> GetInterestsAsItems(ApplicationUser user)
        {
            var pomInterests = new List<SelectListItem>();
            foreach (var item in _interestRepository.GetAll())
            {
                var selectedItem = new SelectListItem() { Text = item.Name, Value = item.InterestId.ToString() };
                if (user.Interests.FirstOrDefault(x => x.InterestId == item.InterestId) != null)
                {
                    selectedItem.Selected = true;
                }
                pomInterests.Add(selectedItem);
            }
            return pomInterests;
        }
    }
}