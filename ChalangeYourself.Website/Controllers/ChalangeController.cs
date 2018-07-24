using ChalangeYourself.Services.Repositories;
using ChalangeYourself.Website.Mappers;
using ChalangeYourself.Website.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChalangeYourself.Website.Controllers
{
    public class ChalangeController : Controller
    {
        //TODO: promyslet nějaký penalizace když výzvu nesplní, aby se nepřihlásil ke všem výzvám a pak nic nedělal
        private ChalangeRepository _chalangeRepository;
        private UserRepository _userRepository;
        public ChalangeController(ChalangeRepository chalangeRepository, UserRepository userRepository)
        {
            _chalangeRepository = chalangeRepository;
            _userRepository = userRepository;
        }
        public ActionResult ChalangeDetail(int chalangeId)
        {
            var chalange = _chalangeRepository.GetById(chalangeId);
            var chalangeVM = ChalangeMappers.ChalangeToDetailChalangeVM(chalange);
            return View("ChalangeDetail",chalangeVM);
        }
        public ActionResult Index()
        {
            var chalangesVM = new List<ChalangeOverViewViewModel>();

            foreach (var chalange in _chalangeRepository.GetAllOrderedByDay())
            {
                chalangesVM.Add(ChalangeMappers.ChalangeToOverViewMap(chalange));
            }
            ViewBag.OrderByOptions = GetOrderBySelections();

            return View("Index", chalangesVM);
        }
        //TODO: toto jako post a brát data z modelu
        //Možná to udělat aby to bylo voláno ajaxem a jen zobrazit hlášku že se přidal
        public ActionResult Pripojit(int chalangeId)
        {
            var chalange = _chalangeRepository.GetById(chalangeId);
            var user = _userRepository.GetById(User.Identity.GetUserId());
            var result = _chalangeRepository.AddUserToChalange(chalange, user); //TODO: Pracovat s výsledkem
            return RedirectToAction("Index");
        }
        private IEnumerable<SelectListItem> GetOrderBySelections()
        {
            var items = new List<SelectListItem>()
            {
                new SelectListItem()
                {
                    Text = "Datum ukončení",
                    Value = "1",
                    Selected = true
                },
                new SelectListItem()
                {
                    Text = "Datum začátku",
                    Value = "2"
                },
                new SelectListItem()
                {
                    Text = "Názvu",
                    Value = "3"
                },
                new SelectListItem()
                {
                    Text = "Počtu přihlášených",
                    Value = "4"
                }
            };

            return items;
        }
    }
}