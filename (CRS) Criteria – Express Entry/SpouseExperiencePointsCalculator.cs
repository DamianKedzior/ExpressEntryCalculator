using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _CRS__Criteria___Express_Entry
{
    class SpouseExperiencePointsCalculator
    {
        public static int CountPointsForSpouseExperience(int YearsOfSpouseExperience)
        {
            if (YearsOfSpouseExperience >= 5)
            {
                return 10;
            }
            else if (YearsOfSpouseExperience == 4)
            {
                return 9;
            }
            else if (YearsOfSpouseExperience == 3)
            {
                return 8;
            }
            else if (YearsOfSpouseExperience == 2)
            {
                return 7;
            }
            else if (YearsOfSpouseExperience == 1)
            {
                return 5;
            }
            else
            {
                return 0;
            }
        }
    }
}
