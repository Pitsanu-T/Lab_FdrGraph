using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain
{
    public class FdrEvent : ICloneable
    {
        public string Imei { get; set; }
        public DateTime Start { get; set; }
        public DateTime? Stop { get; set; }       

        public bool IsSamePeriod(FdrEvent other)
        {
            if (other == null) return false;
            if (!IsSameStopDate(other)) return false;
            if (!IsSameStartDate(other)) return false;

            return true;
        }

        public bool IsSameStartDate(FdrEvent other)
        {
            return DateTime.Compare(this.Start, other.Start) == 0;
        }

        public bool IsSameStopDate(FdrEvent other)
        {
            if (!this.Stop.HasValue) return false;
            if (!other.Stop.HasValue) return false;

            return DateTime.Compare(this.Stop.Value, other.Stop.Value) == 0;
        }

        public override string ToString()
        {
            return (string.Format("Begin [{0}], End [{1}]", Start, (!Stop.HasValue) ? "NULL" : Stop.Value.ToString()));
        }
               

        public object Clone()
        {
            return new FdrEvent
            {
                Start = this.Start,
                Stop = this.Stop
            };
        } 
    }
}
