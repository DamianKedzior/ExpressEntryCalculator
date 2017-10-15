using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _CRS__Criteria___Express_Entry
{
    class SpouseLanguagePointsCalculator
    {
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
