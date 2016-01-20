using System;

namespace SpryCoder.Camever.Helpers
{
    public static class DateHelper
    {
        public static string SinceString(DateTime d)
        {
            TimeSpan s = DateTime.Now.Subtract(d);
            int dayDiff = (int)s.TotalDays;
            int secDiff = (int)s.TotalSeconds;

            //DATE IN FUTURE SO IGNORE
            if (dayDiff < 0)
            {
                return null;
            }

            //LESS THAN ONE DAY
            if (dayDiff == 0)
            {
                if (secDiff < 60)
                {
                    return "just now";
                }
                if (secDiff < 120)
                {
                    return "1 minute ago";
                }
                if (secDiff < 3600)
                {
                    return string.Format("{0} minutes ago", Math.Floor((double)secDiff / 60));
                }
                if (secDiff < 7200)
                {
                    return "1 hour ago";
                }
                if (secDiff < 86400)
                {
                    return string.Format("{0} hours ago", Math.Floor((double)secDiff / 3600));
                }
            }

            //YESTERDAY
            if (dayDiff == 1)
            {
                return "yesterday";
            }

            //LAST MONTH
            if (dayDiff < 31)
            {
                return string.Format("{0} days ago", dayDiff);
            }

            //LAST YEAR
            if (dayDiff < 365)
            {
                return string.Format("{0} weeks ago", Math.Ceiling((double)dayDiff / 7));
            }

            //PREVIOUS YEARS
            return string.Format("{0} years ago", Math.Ceiling((double)dayDiff / 365));
        }
    }
}
