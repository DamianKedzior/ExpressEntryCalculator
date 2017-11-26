using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressEntryCalculator.Core
{
    public static class EducationPointsCalculator
    {
        public static int CountPointsForEducationWithSpouse(ushort eduLevel)
        {
            switch (eduLevel)
            {
                case 1:
                    return 0;
                case 2:
                    return 28;
                case 3:
                    return 84;
                case 4:
                    return 91;
                case 5:
                    return 112;
                case 6:
                    return 119;
                case 7:
                    return 126;
                case 8:
                    return 140;
                default:
                    return 0;
            }
        }


        public static int CountPointsForEducation(ushort eduLevel)
        {
            switch (eduLevel)
            {
                case 1:
                    return 0;
                case 2:
                    return 30;
                case 3:
                    return 90;
                case 4:
                    return 98;
                case 5:
                    return 120;
                case 6:
                    return 128;
                case 7:
                    return 135;
                case 8:
                    return 150;
                default:
                    return 0;
            }

        }


        public static int CountPointsForSpouseEducation(ushort spouseEduLevel)
        {
            switch (spouseEduLevel)
            {
                case 1:
                    return 0;
                case 2:
                    return 2;
                case 3:
                    return 6;
                case 4:
                    return 7;
                case 5:
                    return 8;
                case 6:
                    return 9;
                case 7:
                    return 10;
                case 8:
                    return 10;
                default:
                    return 0;
            }
        }
    }
}
