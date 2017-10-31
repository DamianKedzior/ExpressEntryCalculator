using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _CRS__Criteria___Express_Entry
{
    static class AdditionalPointsCalculator
    {
        public static int CalculateAdditionalPoints(LanguagePoints languagePoints, int educationLevel, int yearsOfExperience, int yearsOfForeignExperience)
        {
            int additionalPointsForEduAndLang = EduAndLangPoints(languagePoints, educationLevel);
            int additionalPointsForExpAndEd = ExpAndEduPoints(yearsOfExperience, educationLevel);
            int additionalPointsForLangAndForeighExp = LangAndForeighExpPoints(languagePoints, yearsOfForeignExperience);
            int additionalPointsForExpAndForeignExp = ExpAndForeignExpPoints(yearsOfExperience, yearsOfForeignExperience);
            int additionalPoints;
            additionalPoints = additionalPointsForEduAndLang + additionalPointsForExpAndEd + additionalPointsForLangAndForeighExp + additionalPointsForExpAndForeignExp;

            //// Dlugi IF (ponizej krotki IF)
            //if (additionalPoints > 100)
            //{
            //    return 100;
            //}
            //else
            //{
            //    return additionalPoints;
            //}

            // krotki IF (robi to samo co kod powyzej)
            return additionalPoints > 100 ? 100 : additionalPoints;
        }


        private static int EduAndLangPoints(LanguagePoints languagePoints, int educationLevel)
        {
            if ((
                    languagePoints.CLBSpeakingPoints >= 7
                    && languagePoints.CLBWritingPoints >= 7
                    && languagePoints.CLBReadingPoints >= 7
                    && languagePoints.CLBListeningPoints >= 7)
                && (languagePoints.CLBSpeakingPoints < 9
                    || languagePoints.CLBWritingPoints < 9
                    || languagePoints.CLBReadingPoints < 9
                    || languagePoints.CLBListeningPoints < 9)
                && (educationLevel == 3
                    || educationLevel == 4
                    || educationLevel == 5))
            {
                return 13;
            }
            else if ((
                    languagePoints.CLBSpeakingPoints >= 7
                    && languagePoints.CLBWritingPoints >= 7
                    && languagePoints.CLBReadingPoints >= 7
                    && languagePoints.CLBListeningPoints >= 7)
                && (languagePoints.CLBSpeakingPoints < 9
                    || languagePoints.CLBWritingPoints < 9
                    || languagePoints.CLBReadingPoints < 9
                    || languagePoints.CLBListeningPoints < 9)
                && (educationLevel == 6 || educationLevel == 7 || educationLevel == 8))
            {
                return 25;
            }
            else if ((
                    languagePoints.CLBSpeakingPoints >= 9
                    && languagePoints.CLBWritingPoints >= 9
                    && languagePoints.CLBReadingPoints >= 9
                    && languagePoints.CLBListeningPoints >= 9)
                && (educationLevel == 3 || educationLevel == 4 || educationLevel == 5))
            {
                return 25;
            }
            else if ((
                    languagePoints.CLBSpeakingPoints >= 9
                    && languagePoints.CLBWritingPoints >= 9
                    && languagePoints.CLBReadingPoints >= 9
                    && languagePoints.CLBListeningPoints >= 9)
                && (educationLevel == 6 || educationLevel == 7 || educationLevel == 8))
            {
                return 50;
            }
            else
            {
                return 0;
            }
        }



        private static int ExpAndEduPoints(int yearsOfExperience, int educationLevel)
        {
            if (yearsOfExperience == 1 && (educationLevel == 3 || educationLevel == 4 || educationLevel == 5))
            {
                return 13;
            }
            else if (yearsOfExperience == 1 && (educationLevel == 6 || educationLevel == 7 || educationLevel == 8))
            {
                return 25;
            }
            else if (yearsOfExperience >= 2 && (educationLevel == 3 || educationLevel == 4 || educationLevel == 5))
            {
                return 25;
            }
            else if (yearsOfExperience >= 2 && (educationLevel == 6 || educationLevel == 7 || educationLevel == 8))
            {
                return 50;
            }
            else
            {
                return 0;
            }
        }



        private static int LangAndForeighExpPoints(LanguagePoints languagePoints, int yearsOfForeignExperience)
        {
            if ((
               languagePoints.CLBSpeakingPoints >= 7
               && languagePoints.CLBWritingPoints >= 7
               && languagePoints.CLBReadingPoints >= 7
               && languagePoints.CLBListeningPoints >= 7)
            && (languagePoints.CLBSpeakingPoints < 9
               || languagePoints.CLBWritingPoints < 9
               || languagePoints.CLBReadingPoints < 9
               || languagePoints.CLBListeningPoints < 9)
            && (yearsOfForeignExperience == 1 || yearsOfForeignExperience == 2))
            {
                return 13;
            }
            else if ((
                languagePoints.CLBSpeakingPoints >= 7
                && languagePoints.CLBWritingPoints >= 7
                && languagePoints.CLBReadingPoints >= 7
                && languagePoints.CLBListeningPoints >= 7)
             && (languagePoints.CLBSpeakingPoints < 9
                || languagePoints.CLBWritingPoints < 9
                || languagePoints.CLBReadingPoints < 9
                || languagePoints.CLBListeningPoints < 9)
             && (yearsOfForeignExperience >= 3))
            {
                return 25;
            }
            else if ((
                languagePoints.CLBSpeakingPoints >= 9
                && languagePoints.CLBWritingPoints >= 9
                && languagePoints.CLBReadingPoints >= 9
                && languagePoints.CLBListeningPoints >= 9)
             && (yearsOfForeignExperience == 1 || yearsOfForeignExperience == 2))
            {
                return 25;
            }
            else if ((
                languagePoints.CLBSpeakingPoints >= 9
                && languagePoints.CLBWritingPoints >= 9
                && languagePoints.CLBReadingPoints >= 9
                && languagePoints.CLBListeningPoints >= 9)
              && (yearsOfForeignExperience >= 3))
            {
                return 50;
            }
            else
            {
                return 0;
            }
        }



        private static int ExpAndForeignExpPoints(int yearsOfExperience, int yearsOfForeignExperience)
        {
            if (yearsOfExperience == 1 && (yearsOfForeignExperience == 1 || yearsOfForeignExperience == 2))
            {
                return 13;
            }
            else if (yearsOfExperience == 1 && (yearsOfForeignExperience >= 3))
            {
                return 25;
            }
            else if (yearsOfExperience >= 2 && (yearsOfForeignExperience == 1 || yearsOfForeignExperience == 2))
            {
                return 25;
            }
            else if (yearsOfExperience >= 2 && (yearsOfForeignExperience >= 3))
            {
                return 50;
            }
            else
            {
                return 0;
            }
        }


               
    }
}
