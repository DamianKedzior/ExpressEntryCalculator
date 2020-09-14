using System;

namespace ExpressEntryCalculator.Core
{
    public static class AgeHelper
    {
        public static int CountAge(DateTime birthday)
        {
            return CountAge(birthday, DateTime.UtcNow);
        }

        public static int CountAge(DateTime birthday, DateTime currentTime)
        {
            DateTime now = currentTime;
            int age = now.Year - birthday.Year;

            if (now.Month < birthday.Month)
            {
                age = age - 1;
                return age;
            }
            if (now.Month == birthday.Month && now.Day < birthday.Day)
            {
                age = age - 1;
                return age;
            }
            else
            {
                return age;
            }
        }
    }
}
