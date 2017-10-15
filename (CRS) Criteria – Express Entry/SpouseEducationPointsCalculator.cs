using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _CRS__Criteria___Express_Entry
{
    class SpouseEducationPointsCalculator
    {
        public static int CountPointsForSpouseEducation(int SpouseEduLevel)
        {
            switch (SpouseEduLevel)
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
