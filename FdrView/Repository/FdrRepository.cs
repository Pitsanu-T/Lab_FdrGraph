using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;

namespace Repository
{
    public class FdrRepository : IFdrRepository
    {

        public List<FdrEvent> GetFdrs()
        {
            return new List<FdrEvent>();
        }

        public List<FdrEvent> GetFdrs(string imei)
        {
            return new List<FdrEvent>();
        }
    }
}
