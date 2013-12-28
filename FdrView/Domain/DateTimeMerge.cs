using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain
{
    public class DateTimeMerge
    {
        public static List<FdrEvent> Combind(FdrEvent ev1, FdrEvent ev2)
        {
            List<FdrEvent> list = new List<FdrEvent>();

            #region If both even have no Stop date then sum them up into one record
            /* If both even have no Stop date then sum them up into one record. */
            if (!ev1.Stop.HasValue && !ev2.Stop.HasValue)
            {
                FdrEvent newitem = new FdrEvent
                {
                    Start = (ev1.Start.CompareTo(ev2.Start) <= 0) ? ev1.Start : ev2.Start,
                    Stop = null
                };
                
                list.Add(newitem);

                return list;
            }
            #endregion

            #region If one of them have no Stop date
            /* If one of them have no Stop date. Check if they overlapped.
               If overlap then sum them up into one record
               If not overlap then return 2 records 
             * */
            if (!ev1.Stop.HasValue || !ev2.Stop.HasValue)
            {
                FdrEvent evWithNullStop = (!ev1.Stop.HasValue) ? ev1 : ev2;
                FdrEvent evWithStop = (ev1.Stop.HasValue) ? ev1 : ev2;

                if (evWithStop.Stop.Value.CompareTo(evWithNullStop.Start) >= 1) // Overlap
                {
                    FdrEvent newitem = new FdrEvent
                    {
                        Start = (evWithNullStop.Start.CompareTo(evWithStop.Start) <= 0) ? evWithNullStop.Start : evWithStop.Start,
                        Stop = null
                    };

                    list.Add(newitem);

                    return list;
                }
                else // Not overlap
                {
                    FdrEvent item1 = evWithNullStop.Clone() as FdrEvent;
                    FdrEvent item2 = evWithStop.Clone() as FdrEvent;

                    list.Add(item1);
                    list.Add(item2);

                    return list;
                }
            }
            #endregion

            #region Both event have same start/stop datetime then sum them up into one record
            /* If both event have same start/stop datetime then sum them up into one record */
            if (ev1.IsSamePeriod(ev2))
            {
                list.Add(ev1.Clone() as FdrEvent);

                return list;
            }
            #endregion

            #region Normal case
            if (ev2.Start.CompareTo( ev1.Stop.Value) > 0)
            {
                // Event 2 come after event 1
                list.Add(ev1.Clone() as FdrEvent);
                list.Add(ev2.Clone() as FdrEvent);
            }
            else if (ev1.Start.CompareTo(ev2.Stop.Value) > 0)
            {
                // Event 1 come after event 2
                list.Add(ev1.Clone() as FdrEvent);
                list.Add(ev2.Clone() as FdrEvent);
            }
            else
            {
                // Overlap, sum them up into one.
                //   Use earlier start, and lastest stop
                FdrEvent newitem = new FdrEvent
                {
                    Start = (ev1.Start.CompareTo(ev2.Start) <= 0) ? ev1.Start : ev2.Start,
                    Stop = (ev1.Stop.Value.CompareTo(ev2.Stop.Value) >= 0) ? ev1.Stop.Value : ev2.Stop.Value
                };

                list.Add(newitem);

            }

            return list;

            #endregion
        }
    }
}
