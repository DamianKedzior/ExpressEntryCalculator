using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _CRS__Criteria___Express_Entry
{
    static class ExperiencePointsCalculator
    {
        public static int CountPointsForExperienceWithSpouse(int YearsOfExperience)
        {
            if (YearsOfExperience >= 5)
            {
                return 70;
            }
            else if (YearsOfExperience == 4)
            {
                return 63;
            }
            else if (YearsOfExperience == 3)
            {
                return 56;
            }
            else if (YearsOfExperience == 2)
            {
                return 46;
            }
            else if (YearsOfExperience == 1)
            {
                return 35;
            }
            else
            {
                return 0;
            }
        }

        public static int CountPointsForExperienceWithoutSpouse(int YearsOfExperience)
        {
            if (YearsOfExperience >= 5)
            {
                return 80;
            }
            else if (YearsOfExperience == 4)
            {
                return 72;
            }
            else if (YearsOfExperience == 3)
            {
                return 64;
            }
            else if (YearsOfExperience == 2)
            {
                return 53;
            }
            else if (YearsOfExperience == 1)
            {
                return 40;
            }
            else
            {
                return 0;
            }
        }


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
