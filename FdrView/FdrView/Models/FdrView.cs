using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FdrView.Models;
using Domain;

namespace FdrView.Models
{    
    public class FdrItemView
    {
        public static FdrItemView GenerateSample(string testImei)
        {
            return new FdrItemView
            {
                Imei = testImei,
                NumberOfFdrs = "50",
                LastKnowDurationHours = "500.0",
                LastOpenDateString = DateTime.Now.ToString(),
                LastCloseDateString = DateTime.Now.AddHours(10.0).ToString(),
                IsHaveOpenFdr = "NO",
                NumberOfEvents = "1000"
            };
        }

        public string Imei { get; set; }
        public string NumberOfFdrs { get; set; }
        public string LastKnowDurationHours { get; set; }
        public string LastOpenDateString { get; set; }
        public string LastCloseDateString { get; set; }
        public string IsHaveOpenFdr { get; set; }
        public string NumberOfEvents { get; set; }
        //public List<FdrAggregateView> FdrList { get; set; }
    }

    /*
    public class FdrAggregateView
    {
        public string Imei { get; set; }
        public string ID { get; set; }
        public string StartDateString { get; set; }
        public string StopDateString { get; set; }
        public string DurationInHours { get; set; }
        public string IsOpen { get; set; }
        //public List<FdrEventView> FdrEventList { get; set; }
    }*/

    /*
    public class FdrEventView
    {
        public string Imei { get; set; }
        public string ID { get; set; }
        public string StartDateString { get; set; }
        public string StopDateString { get; set; }
        public string DurationInHours { get; set; }
    }
    */
    /*
    public static class FdrDtoExtensionMethod
    {
        public static FdrAggregateView ToDto(this FdrEvent item)
        {
            return new FdrAggregateDto
            {
                Imei = item.Imei,
                Start = item.Start,
                Stop = item.Stop
            };
        }
    }
     * */
}
