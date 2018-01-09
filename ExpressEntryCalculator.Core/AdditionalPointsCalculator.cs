using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressEntryCalculator.Core
{
    public static class AdditionalPointsCalculator
    {
        public static int GiveAdditionalPoints(string answerToAddQuestion)
        {
            if (answerToAddQuestion == "YES")
            {
                return 15;
            }
            else
            {
                return 0;
            }
        }

        public static int GiveAdditionalPoints(bool answerToAddQuestion)
        {
            return GiveAdditionalPoints(MapBoolToStrig(answerToAddQuestion));
        }
        

        public static int CanadianEducationPoints(int years)
        {
            if (years == 1 || years == 2)
            {
                return 15;
            }
            else if (years >= 3)
            {
                return 30;
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

        public static int GiveDoubleAdditionalPoints(bool answerToAddQuestion)
        {
            return GiveDoubleAdditionalPoints(MapBoolToStrig(answerToAddQuestion));
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

        public static int GiveAdditionalPointsForArrangedEmployment(bool answerToAddQuestion)
        {
            return GiveAdditionalPointsForArrangedEmployment(MapBoolToStrig(answerToAddQuestion));
        }


        public static int CalculatePointsForArrangementEmployment(int employmentType)
        {
            if (employmentType == 1)
            {
                return 200;
            }
            else if (employmentType == 2)
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

        public static int GiveMoreAdditionalPointsForArrangedEmployment(bool answerToAddQuestion)
        {
            return GiveMoreAdditionalPointsForArrangedEmployment(MapBoolToStrig(answerToAddQuestion));
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

        public static int GiveAdditionalPointsForProvincialOrTerritorialNomination(bool answerToAddQuestion)
        {
            return GiveAdditionalPointsForProvincialOrTerritorialNomination(MapBoolToStrig(answerToAddQuestion));
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

        static string MapBoolToStrig(bool condition)
        {
            return condition ? "YES" : "NO";
        }
    }
}
