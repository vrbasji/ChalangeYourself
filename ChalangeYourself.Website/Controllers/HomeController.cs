using ChalangeYourself.Data.Model;
using ChalangeYourself.Services.Repositories;
using ChalangeYourself.Website.Mappers;
using ChalangeYourself.Website.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Unity.Interception.Utilities;

namespace ChalangeYourself.Website.Controllers
{
    public class HomeController : Controller
    {
        private UserRepository _userRepository;
        private ChalangeRepository _chalangeRepository;

        public HomeController(UserRepository userRepository, ChalangeRepository chalangeRepository)
        {
            _userRepository = userRepository;
            _chalangeRepository = chalangeRepository;
        }

        public ActionResult Index()
        {
            var user = _userRepository.GetById(User.Identity.GetUserId());
            var rankedUsers = _userRepository.GetRankedUser();
            var chalanges = _chalangeRepository.GetAllOrderedByDay();
            var propousalChalanges = _chalangeRepository.GetPropousalChalanges();
            if (user != null)
            {
                ViewBag.UserImagePath = user.ImagePath;
            }
            var homePageVM = new HomePageViewModel()
            {
                Chalanges = new List<ChalangeOverViewViewModel>(
                    chalanges.Select(
                        x => ChalangeMappers.ChalangeToOverViewMap(x))),
                UserRanks = new List<UserRankViewModel>(
                    rankedUsers.Select(
                        x => UserMappers.UserToUsersRankMap(x))),
                ProposalChalangesRanks = new List<ProposalChalangeRankViewModel>(
                    propousalChalanges.Select(
                        x => ChalangeMappers.ProposalChalangeToProposalRankMap(x)))
            };
            return View(homePageVM);
        }

        public ActionResult AddProposalChalange()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddProposalChalange(ProposalChalangeViewModel model)
        {
            var user = _userRepository.GetById(User.Identity.GetUserId());
            model.User = user;
            var proposalChalange = ChalangeMappers.ProposalChalangeVMToPropChalange(model);
            _chalangeRepository.AddProposalChalange(proposalChalange);
            ViewBag.Message = "Vaš chalange byla odeslána ke schválení";
            return View("Index");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Rank()
        {
            ViewBag.Message = "Your ranks page.";

            return View();
        }
    }
}