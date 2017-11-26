using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressEntryCalculator.Core
{
    public static class AgePointsCalculator
    {
        public static int CountPointsForAgeWithSpouse(int age)
        {
            if (age <= 17 || age >= 45)
            {
                return 0;
            }
            else if (age == 44)
            {
                return 5;
            }
            else if (age == 43)
            {
                return 15;
            }
            else if (age == 42)
            {
                return 25;
            }
            else if (age == 41)
            {
                return 35;
            }
            else if (age == 40)
            {
                return 45;
            }
            else if (age == 39)
            {
                return 50;
            }
            else if (age == 38)
            {
                return 55;
            }
            else if (age == 37)
            {
                return 60;
            }
            else if (age == 36)
            {
                return 65;
            }
            else if (age == 35)
            {
                return 70;
            }
            else if (age == 34)
            {
                return 75;
            }
            else if (age == 33)
            {
                return 80;
            }
            else if (age == 32)
            {
                return 85;
            }
            else if (age == 18 || age == 31)
            {
                return 90;
            }
            else if (age == 19 || age == 30)
            {
                return 95;
            }
            else
            {
                return 100;
            }
        }
        public static int CountPointsForAge(int age)
        {
            if (age <= 17 || age >= 45)
            {
                return 0;
            }
            else if (age == 44)
            {
                return 6;
            }
            else if (age == 43)
            {
                return 17;
            }
            else if (age == 42)
            {
                return 28;
            }
            else if (age == 41)
            {
                return 39;
            }
            else if (age == 40)
            {
                return 50;
            }
            else if (age == 39)
            {
                return 55;
            }
            else if (age == 38)
            {
                return 61;
            }
            else if (age == 37)
            {
                return 66;
            }
            else if (age == 36)
            {
                return 72;
            }
            else if (age == 35)
            {
                return 77;
            }
            else if (age == 34)
            {
                return 83;
            }
            else if (age == 33)
            {
                return 88;
            }
            else if (age == 32)
            {
                return 94;
            }
            else if (age == 18 || age == 31)
            {
                return 99;
            }
            else if (age == 19 || age == 30)
            {
                return 105;
            }
            else
            {
                return 110;
            }
        }

    }
}
