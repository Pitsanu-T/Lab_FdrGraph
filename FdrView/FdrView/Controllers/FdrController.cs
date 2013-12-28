using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain;
using Repository;
using FdrView.Models;
using Service;

namespace FdrView.Controllers
{
    public class FdrController : Controller
    {
        public IFdrRepository FdrRepository { get; set; }

        public FdrController()
        {
            FdrRepository = ServiceProvider.GetFdrRepository();
        }

        // GET: /Fdr/
        public ActionResult Index()
        {
            List<FdrEvent> fdrevents = FdrRepository.GetFdrs();
            List<FdrDto> dtos = new List<FdrDto>();
            foreach (FdrEvent ev in fdrevents) { dtos.Add(ev.ToDto()); }

            return View(dtos);
        }

        // GET: /Fdr/Detail/
        public ActionResult Detail(string imei)
        {
            return View();
        }

    }
}
