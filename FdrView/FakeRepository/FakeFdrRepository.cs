using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Repository;
using Domain;
namespace FakeRepository
{
    public class FakeFdrRepository:IFdrRepository
    {
        List<FdrEvent> list;

        public FakeFdrRepository()
        {
            list = new List<FdrEvent>();
            list.Add(new FdrEvent { Imei = "111111", Start = new DateTime(2013, 1, 1), Stop = new DateTime(2013, 1, 5) });
            list.Add(new FdrEvent { Imei = "111111", Start = new DateTime(2013, 1, 1), Stop = new DateTime(2013, 1, 5) });
            list.Add(new FdrEvent { Imei = "111112", Start = new DateTime(2013, 1, 1), Stop = new DateTime(2013, 1, 5) });
            list.Add(new FdrEvent { Imei = "111112", Start = new DateTime(2013, 1, 1), Stop = new DateTime(2013, 1, 5) });
        }

        public List<FdrEvent> GetFdrs()
        {       
            return list;
        }

        public List<FdrEvent> GetFdrs(string imei)
        {
            if (string.IsNullOrEmpty(imei)) return list;

            var selectedlist = from l in list
                               where l.Imei.ToUpper().Equals(imei.ToUpper())
                               select l;

            return selectedlist.ToList();
                               
        }
    }
}
