using System;
using System.Collections.Generic;
using System.Text;

namespace TalendingBarbershop.Services.Utils
{
    static public class UnixTimeStamp
    {
        public static int Now()
        {
            DateTime currentTime = DateTime.Now;
            DateTime zuluTime = currentTime.ToUniversalTime();
            DateTime unixEpoch = new DateTime(1970, 1, 1);
            return (int)(zuluTime.Subtract(unixEpoch)).TotalSeconds;
        }
    }
}
