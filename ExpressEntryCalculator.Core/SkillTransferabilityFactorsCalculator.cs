using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressEntryCalculator.Core
{
    public static class SkillTransferabilityFactorsCalculator
    {
        public static int CalculateSkillTransferabilityFactorsPoints(LanguagePoints languagePoints, ushort educationLevel, int yearsOfExperience, int yearsOfForeignExperience)
        {
            int PointsForEduAndLang = EduAndLangPoints(languagePoints, educationLevel);
            int PointsForExpAndEd = ExpAndEduPoints(yearsOfExperience, educationLevel);
            int PointsForLangAndForeighExp = LangAndForeighExpPoints(languagePoints, yearsOfForeignExperience);
            int PointsForExpAndForeignExp = ExpAndForeignExpPoints(yearsOfExperience, yearsOfForeignExperience);
            int skillTransferabilityFactorsPoints;
            skillTransferabilityFactorsPoints = PointsForEduAndLang + PointsForExpAndEd + PointsForLangAndForeighExp + PointsForExpAndForeignExp;

            return skillTransferabilityFactorsPoints > 100 ? 100 : skillTransferabilityFactorsPoints;
        }


        private static int EduAndLangPoints(LanguagePoints languagePoints, ushort educationLevel)
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



        private static int ExpAndEduPoints(int yearsOfExperience, ushort educationLevel)
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
