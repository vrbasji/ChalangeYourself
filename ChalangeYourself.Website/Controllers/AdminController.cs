using ChalangeYourself.Services;
using ChalangeYourself.Services.Repositories;
using ChalangeYourself.Website.Mappers;
using ChalangeYourself.Website.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChalangeYourself.Website.Controllers
{
    [Authorize(Roles ="admin")]
    public class AdminController : Controller
    {
        private UserRepository _userRepository;
        private ChalangeRepository _chalangeRepository;
        private ProposalChalangeService _proposalChalangeService;
        public AdminController(UserRepository userRepository, ChalangeRepository chalangeRepository)
        {
            _userRepository = userRepository;
            _chalangeRepository = chalangeRepository;
            _proposalChalangeService = new ProposalChalangeService(_chalangeRepository);
        }

        public ActionResult UsersManagement()
        {
            var users = _userRepository.GetAll();
            return View(users);
        }
        public ActionResult ChalangeManagement()
        {
            var chalanges = _chalangeRepository.GetAllOrderedByDay();
            var chalangesVM = new List<DetailChalangeViewModel>();
            foreach (var chalange in chalanges)
            {
                chalangesVM.Add(ChalangeMappers.ChalangeToDetailChalangeVM(chalange));
            }
            return View(chalangesVM);
        }
        public ActionResult ProposalChalangeManagement()
        {
            var proposalChalanges = new List<ProposalChalangeAdminViewModel>();
            foreach (var chalange in _chalangeRepository.GetActivePropousalChalanges())
            {
                proposalChalanges.Add(ChalangeMappers.ProposalChalangeToProposalAdminMap(chalange));
            }

            return View(proposalChalanges);
        }

        public ActionResult ActivateItem(ProposalChalangeAdminViewModel model)
        {
            return View("Edit",model);
        }
        public ActionResult AproveItem(ProposalChalangeAdminViewModel model)
        {
            var result = _proposalChalangeService.AproveProposalChalange(model.ProposalChalangeId);
            if (!result)
            {
                ViewBag.Error = "";//TODO: jestli to jde
            }
            return RedirectToAction("ProposalChalangeManagement");
        }

        [HttpPost]
        public ActionResult Activate(ProposalChalangeAdminViewModel model)
        {
            if (ModelState.IsValid)
            {
                var proposalChalangeId = model.ProposalChalangeId;
                var chalange = ChalangeMappers.ProposalChalangeVMToChalange(model);
                var result = _proposalChalangeService.ActivateProposalChalange(proposalChalangeId, chalange);
                //TODO: řešit něco s výsledkem
            }
            return RedirectToAction("ProposalChalangeManagement");
        }
    }
}