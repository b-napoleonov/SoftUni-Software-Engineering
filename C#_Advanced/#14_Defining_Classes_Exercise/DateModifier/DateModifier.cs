using System;

namespace DateModifier
{
    public class DateModifier
    {
        public static double GetDifference(DateTime first, DateTime second)
        {
            int compare = first.CompareTo(second);

            if (compare == -1)
            {
                return (second - first).TotalDays;
            }
            if (compare == 1)
            {
                return (first - second).TotalDays;
            }

            return 0;
        }
    }
}
