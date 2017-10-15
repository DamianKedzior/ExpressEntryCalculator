using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _CRS__Criteria___Express_Entry
{
    static class LanguagePointsCalculator
    {
      
        public static int LanguagePointsCalculatorWithSpouse(int CLBPoints)
        {
            if (CLBPoints >= 10)
            {
                return 32;
            }
            else if (CLBPoints == 9)
            {
                return 29;
            }
            else if (CLBPoints == 8)
            {
                return 22;
            }
            else if (CLBPoints == 7)
            {
                return 16;
            }
            else if (CLBPoints == 6)
            {
                return 8;
            }
            else if (CLBPoints == 5 || CLBPoints == 4)
            {
                return 6;
            }
            else
            {
                return 0;
            }
        }


        public static int LanguagePointsCalculatorWithoutSpouse(int CLBPoints)
        {
            if (CLBPoints >= 10)
            {
                return 34;
            }
            else if (CLBPoints == 9)
            {
                return 31;
            }
            else if (CLBPoints == 8)
            {
                return 23;
            }
            else if (CLBPoints == 7)
            {
                return 17;
            }
            else if (CLBPoints == 6)
            {
                return 9;
            }
            else if (CLBPoints == 5 || CLBPoints == 4)
            {
                return 6;
            }
            else
            {
                return 0;
            }
        }


        public static int CalculatorOfSpouseLanguagePoints(int CLBSpousePoints)
        {
            if (CLBSpousePoints >= 9)
            {
                return 5;
            }
            else if (CLBSpousePoints == 8 || CLBSpousePoints == 7)
            {
                return 3;
            }
            else if (CLBSpousePoints == 6 || CLBSpousePoints == 5)
            {
                return 1;
            }
            else if (CLBSpousePoints <= 4)
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
