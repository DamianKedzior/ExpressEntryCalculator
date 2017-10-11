using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _CRS__Criteria___Express_Entry
{
    static class SecondLanguagePointsCalculator
    {
        public static int SecondLangPointsCalculator(int CLBPoints)
        {
            if (CLBPoints >= 9)
            {
                return 6;
            }
            else if (CLBPoints == 8 || CLBPoints == 7)
            {
                return 3;
            }
            else if (CLBPoints == 6 || CLBPoints == 5)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
