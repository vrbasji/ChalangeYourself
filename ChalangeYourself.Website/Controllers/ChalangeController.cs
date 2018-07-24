using ChalangeYourself.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChalangeYourself.Website.Controllers
{
    public class ChalangeController : Controller
    {
        private ChalangeRepository _chalangeRepository;
        public ChalangeController(ChalangeRepository chalangeRepository)
        {
            _chalangeRepository = chalangeRepository;
        }
        // GET: Chalange
        public ActionResult ChalangeDetail(int chalangeId)
        {
            var chalange = _chalangeRepository.GetById(chalangeId);
            var chalangeVM = Mappers.ChalangeMappers.ChalangeToDetailChalangeVM(chalange);
            return View("ChalangeDetail",chalangeVM);
        }
    }
}