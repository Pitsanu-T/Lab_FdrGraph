using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FdrView.Models;
using Domain;

namespace FdrView.Models
{
    public class FdrDto
    {
        public string Imei { get; set; }
        public DateTime Start { get; set; }
        public DateTime? Stop { get; set; }
    }

    public static class FdrDtoExtensionMethod
    {
        public static FdrDto ToDto(this FdrEvent item)
        {
            return new FdrDto
            {
                Imei = item.Imei,
                Start = item.Start,
                Stop = item.Stop
            };
        }
    }
}
