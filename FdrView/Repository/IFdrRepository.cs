using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;

namespace Repository
{
    public interface IFdrRepository
    {
        List<FdrEvent> GetFdrs();
        List<FdrEvent> GetFdrs(string imei);
    }
}
