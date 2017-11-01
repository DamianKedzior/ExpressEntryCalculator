using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _CRS__Criteria___Express_Entry
{
    static class AdditionalPoints
    {
        public static int GiveAdditionalPoints(string answerToAddQuestion)
        {
            if (answerToAddQuestion.ToUpper() == "YES")
            {
                return 15;
            }
            else
            {
                return 0;
            }

        }

        public static int GiveDoubleAdditionalPoints(string answerToAddQuestion)
        {
            if (answerToAddQuestion.ToUpper() == "YES")
            {
                return 30;
            }
            else
            {
                return 0;
            }
        }

        public static int GiveAdditionalPointsForArrangedEmployment(string answerToAddQuestion)
        {
            if (answerToAddQuestion.ToUpper() == "YES")
            {
                return 50;
            }
            else
            {
                return 0;
            }
        }

        public static int GiveMoreAdditionalPointsForArrangedEmployment(string answerToAddQuestion)
        {
            if (answerToAddQuestion.ToUpper() == "YES")
            {
                return 200;
            }
            else
            {
                return 0;
            }
        }

        public static int GiveAdditionalPointsForProvincialOrTerritorialNomination(string answerToAddQuestion)
        {
            if (answerToAddQuestion.ToUpper() == "YES")
            {
                return 600;
            }
            else
            {
                return 0;
            }
        }


    }
}
