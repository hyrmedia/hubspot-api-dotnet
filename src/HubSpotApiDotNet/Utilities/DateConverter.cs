using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HubSpotApiDotNet.Utilities
{
    public class DateConverter
    {
        public static DateTime FromMillisecondEpoch(double milliseconds)
        {
            // timestamp is millisecods past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            dtDateTime = dtDateTime.AddSeconds(Math.Round(milliseconds / 1000)).ToLocalTime();
            return dtDateTime;
        }

        public static double ToMillisecondEpoch(DateTime d)
        {
            DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            TimeSpan ts = d - epoch;
            return ts.TotalMilliseconds;
        }
    }
}
