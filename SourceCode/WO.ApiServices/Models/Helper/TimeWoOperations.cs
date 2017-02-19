using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WO.ApiServices.Models.Helper
{
    public class TimeWoOperations
    {
        public static int FromTimeWoToSeconds(TimeWO timeWO)
        {
            return (timeWO.Hours * 3600) + (timeWO.Minutes * 60) + timeWO.Seconds;
        }

        public static TimeWO FromSecondsToTimeWo(int? seconds)
        {
            var timeWo = new TimeWO();
            if (seconds.HasValue)
            {
                timeWo.Hours = seconds.Value / 3600;
                timeWo.Minutes = (seconds.Value % 3600) / 60;
                timeWo.Seconds = seconds.Value % 3600 % 60;
            }

            return timeWo;
        }
    }
}