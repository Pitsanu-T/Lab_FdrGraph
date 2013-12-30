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
            //List<FdrEvent> fdrevents = FdrRepository.GetFdrs();
            //List<FdrDto> dtos = new List<FdrDto>();
            //foreach (FdrEvent ev in fdrevents) { dtos.Add(ev.ToDto()); }

            // Create Fdr Aggregate view from model            
            List<FdrItemView> list = new List<FdrItemView>();
            list.Add(FdrItemView.GenerateSample("11111111111111111"));
            list.Add(FdrItemView.GenerateSample("11111111111111112"));

            ViewBag.Data = list;
            return View("IndexUsingAngular");
            //return View(dtos);
        }

        // GET: /Fdr/Detail/
        public ActionResult Detail(string imei)
        {
            return View();
        }

        /*
        private List<FdrView.Models.FdrItemView> GetSample()
        {
            List<FdrItemView> list = new List<FdrItemView>();
            list.Add(new FdrItemView
            {
                Imei = "11111111111111111",
                IsHaveOpenFdr = "NO",
                LastOpenDateString = DateTime.Now.ToString(),
                LastCloseDateString = DateTime.Now.AddHours(10.0).ToString()
            });

            list.Add(new FdrItemView
            {
                Imei = "22222222222222222",
                IsHaveOpenFdr = "NO",
                LastOpenDateString = DateTime.Now.ToString(),
                LastCloseDateString = DateTime.Now.AddHours(10.0).ToString()
            });

            return list;
        }
        */

    }
}
