using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain;

namespace DateTimeMergeTests
{  
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void SameDateTimeMustReturnOneRecord()
        {
            DateTime d1 = DateTime.Now;
            DateTime d2 = d1.AddDays(1);

            FdrEvent ev1 = new FdrEvent { Start = d1, Stop = d2 };
            FdrEvent ev2 = new FdrEvent { Start = d1, Stop = d2 };
            List<FdrEvent> rtn = DateTimeMerge.Combind(ev1, ev2);

            Assert.IsTrue(rtn.Count == 1);
        }

        [TestMethod]
        public void BothEnddateNullReturnOneRecordStartWithEarlyEvent()
        {
            FdrEvent ev1 = new FdrEvent { Start = new DateTime(2013, 1, 1), Stop = null };
            FdrEvent ev2 = new FdrEvent { Start = new DateTime(2013, 1, 2), Stop = null };

            List<FdrEvent> rtn = DateTimeMerge.Combind(ev2, ev1);            
            Console.WriteLine(rtn[0]);

            Assert.IsTrue(rtn.Count == 1 && DateTime.Compare(ev1.Start, rtn[0].Start) == 0);
        }

        [TestMethod]
        public void OneNullEnddateWithGapReturnOneRecord()
        {
            FdrEvent ev1 = new FdrEvent { Start = new DateTime(2013, 1, 1), Stop = null };
            FdrEvent ev2 = new FdrEvent { Start = new DateTime(2013, 1, 3), Stop = new DateTime(2013, 1, 5) };

            List<FdrEvent> rtn = DateTimeMerge.Combind(ev1, ev2);            
            Console.WriteLine(rtn[0]);
            
            Assert.IsTrue(rtn.Count == 1);
        }

        [TestMethod]
        public void OneNullEnddateWithNoGapReturnTwoRecord()
        {
            FdrEvent ev1 = new FdrEvent { Start = new DateTime(2013, 1, 6), Stop = null };
            FdrEvent ev2 = new FdrEvent { Start = new DateTime(2013, 1, 3), Stop = new DateTime(2013, 1, 5) };

            List<FdrEvent> rtn = DateTimeMerge.Combind(ev1, ev2);            
            Console.WriteLine(rtn[0]);
            Console.WriteLine(rtn[1]);

            Assert.IsTrue(rtn.Count == 2);
        }
    }
}
