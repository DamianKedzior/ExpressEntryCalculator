using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressEntryCalculator
{
    static class AdditionalPointsCalculator
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


        public static int GiveAdditionalPointsForLanguages(LanguagePoints frenchLanguagePoints, LanguagePoints englishLanguagePoints)
        {
            if (frenchLanguagePoints.CLBSpeakingPoints >= 7
                 && frenchLanguagePoints.CLBWritingPoints >= 7
                 && frenchLanguagePoints.CLBReadingPoints >= 7
                 && frenchLanguagePoints.CLBListeningPoints >= 7)
            {
                if (englishLanguagePoints == null
                    ||
                 (englishLanguagePoints.CLBSpeakingPoints <= 4
                 && englishLanguagePoints.CLBWritingPoints <= 4
                 && englishLanguagePoints.CLBReadingPoints <= 4
                 && englishLanguagePoints.CLBListeningPoints <= 4))
                {
                    return 15;
                }
                else
                {
                    return 30;
                }
            }
            else
            {
                return 0;
            }
        }
    }
}
