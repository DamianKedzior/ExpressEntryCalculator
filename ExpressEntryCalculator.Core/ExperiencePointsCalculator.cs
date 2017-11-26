using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressEntryCalculator.Core
{
    public static class ExperiencePointsCalculator
    {
        public static int CountPointsForExperienceWithSpouse(int yearsOfExperience)
        {
            if (yearsOfExperience >= 5)
            {
                return 70;
            }
            else if (yearsOfExperience == 4)
            {
                return 63;
            }
            else if (yearsOfExperience == 3)
            {
                return 56;
            }
            else if (yearsOfExperience == 2)
            {
                return 46;
            }
            else if (yearsOfExperience == 1)
            {
                return 35;
            }
            else
            {
                return 0;
            }
        }

        public static int CountPointsForExperienceWithoutSpouse(int yearsOfExperience)
        {
            if (yearsOfExperience >= 5)
            {
                return 80;
            }
            else if (yearsOfExperience == 4)
            {
                return 72;
            }
            else if (yearsOfExperience == 3)
            {
                return 64;
            }
            else if (yearsOfExperience == 2)
            {
                return 53;
            }
            else if (yearsOfExperience == 1)
            {
                return 40;
            }
            else
            {
                return 0;
            }
        }


        public static int CountPointsForSpouseExperience(int yearsOfSpouseExperience)
        {
            if (yearsOfSpouseExperience >= 5)
            {
                return 10;
            }
            else if (yearsOfSpouseExperience == 4)
            {
                return 9;
            }
            else if (yearsOfSpouseExperience == 3)
            {
                return 8;
            }
            else if (yearsOfSpouseExperience == 2)
            {
                return 7;
            }
            else if (yearsOfSpouseExperience == 1)
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
