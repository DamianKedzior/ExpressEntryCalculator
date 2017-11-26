using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressEntryCalculator.Core
{
    public static class LanguagePointsCalculator
    {
      
        public static int LanguagePointsCalculatorWithSpouse(int clbPoints)
        {
            if (clbPoints >= 10)
            {
                return 32;
            }
            else if (clbPoints == 9)
            {
                return 29;
            }
            else if (clbPoints == 8)
            {
                return 22;
            }
            else if (clbPoints == 7)
            {
                return 16;
            }
            else if (clbPoints == 6)
            {
                return 8;
            }
            else if (clbPoints == 5 || clbPoints == 4)
            {
                return 6;
            }
            else
            {
                return 0;
            }
        }


        public static int LanguagePointsCalculatorWithoutSpouse(int clbPoints)
        {
            if (clbPoints >= 10)
            {
                return 34;
            }
            else if (clbPoints == 9)
            {
                return 31;
            }
            else if (clbPoints == 8)
            {
                return 23;
            }
            else if (clbPoints == 7)
            {
                return 17;
            }
            else if (clbPoints == 6)
            {
                return 9;
            }
            else if (clbPoints == 5 || clbPoints == 4)
            {
                return 6;
            }
            else
            {
                return 0;
            }
        }


        public static int CalculatorOfSpouseLanguagePoints(int clbSpousePoints)
        {
            if (clbSpousePoints >= 9)
            {
                return 5;
            }
            else if (clbSpousePoints == 8 || clbSpousePoints == 7)
            {
                return 3;
            }
            else if (clbSpousePoints == 6 || clbSpousePoints == 5)
            {
                return 1;
            }
            else if (clbSpousePoints <= 4)
            {
                return 0;
            }
            else
            {
                return 0;
            }
        }
    }
}
