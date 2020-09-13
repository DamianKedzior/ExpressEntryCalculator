using System;
using ExpressEntryCalculator.Core;

namespace ExpressEntryCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            DisplayMessage("Please provide your first name.");
            string firstname = System.Console.ReadLine();
            DisplayMessage("Please provide your last name.");
            string lastname = System.Console.ReadLine();

            DateTime parsedDateOfBirth;
            string dateOfBirth;

            bool isFirstAttempt = true;
            do
            {
                if (!isFirstAttempt)
                {
                    DisplayMessage("Wrong date format. Please try again.", ConsoleColor.Red);
                }
                DisplayMessage("Please provide your date of birth (required format: yyyy-mm-dd).");
                dateOfBirth = System.Console.ReadLine();

                isFirstAttempt = false;
            }
            while (DateTime.TryParse(dateOfBirth, out parsedDateOfBirth) == false);

            int age = AgeHelper.CountAge(parsedDateOfBirth);

            DisplayMessage("Please provide fullname your spouse or common - law partner if exist.");
            string spouseFullname = System.Console.ReadLine();
            bool noSpouse = String.IsNullOrWhiteSpace(spouseFullname);

            int pointForAge;
            if (noSpouse == true)
            {
                pointForAge = AgePointsCalculator.CountPointsForAge(age);
            }
            else
            {
                pointForAge = AgePointsCalculator.CountPointsForAgeWithSpouse(age);
            }
            DisplayMessage("Points for age: " + pointForAge.ToString(), ConsoleColor.Green);

            DisplayMessage("Please select the level of your education (enter the number from 1 to 8).");

            ushort educationLevel = GetEducationalLevel();

            int pointForEducation;

            if (noSpouse == true)
            {
                pointForEducation = EducationPointsCalculator.CountPointsForEducation(educationLevel);
            }
            else
            {
                pointForEducation = EducationPointsCalculator.CountPointsForEducationWithSpouse(educationLevel);
            }
            DisplayMessage("Points for education: " + pointForEducation.ToString(), ConsoleColor.Green);

            LanguagePoints primaryAplicantFirstLangPoints = SetAndCalculateLanguagePoints();

            int pointsForSpeaking;
            int pointsForWriting;
            int pointsForReading;
            int pointsForListening;
            int pointsForLanguage;
            if (noSpouse == true)
            {
                pointsForSpeaking = LanguagePointsCalculator.LanguagePointsCalculatorWithoutSpouse(primaryAplicantFirstLangPoints.CLBSpeakingPoints);
                pointsForWriting = LanguagePointsCalculator.LanguagePointsCalculatorWithoutSpouse(primaryAplicantFirstLangPoints.CLBWritingPoints);
                pointsForReading = LanguagePointsCalculator.LanguagePointsCalculatorWithoutSpouse(primaryAplicantFirstLangPoints.CLBReadingPoints);
                pointsForListening = LanguagePointsCalculator.LanguagePointsCalculatorWithoutSpouse(primaryAplicantFirstLangPoints.CLBListeningPoints);
            }
            else
            {
                pointsForSpeaking = LanguagePointsCalculator.LanguagePointsCalculatorWithSpouse(primaryAplicantFirstLangPoints.CLBSpeakingPoints);
                pointsForWriting = LanguagePointsCalculator.LanguagePointsCalculatorWithSpouse(primaryAplicantFirstLangPoints.CLBWritingPoints);
                pointsForReading = LanguagePointsCalculator.LanguagePointsCalculatorWithSpouse(primaryAplicantFirstLangPoints.CLBReadingPoints);
                pointsForListening = LanguagePointsCalculator.LanguagePointsCalculatorWithSpouse(primaryAplicantFirstLangPoints.CLBListeningPoints);
            }
            pointsForLanguage = pointsForSpeaking + pointsForWriting + pointsForReading + pointsForListening;
            DisplayMessage("Points for 1st language: " + pointsForLanguage.ToString(), ConsoleColor.Green);


            DisplayMessage("Did you pass second language exam? (YES or NO).");
            string secondLanguage = System.Console.ReadLine();
            int pointsForSecondLanguage = 0;
            LanguagePoints primaryAplicantSecondLangPoints = null;

            if (secondLanguage.ToUpper() == "YES")
            {
                primaryAplicantSecondLangPoints = SetAndCalculateLanguagePoints();
              

                int pointsForSecondLangSpeaking;
                int pointsForSecondLangWriting;
                int pointsForSecondLangReading;
                int pointsForSecondLangListening;

                pointsForSecondLangSpeaking = SecondLanguagePointsCalculator.SecondLangPointsCalculator(primaryAplicantSecondLangPoints.CLBSpeakingPoints);
                pointsForSecondLangWriting = SecondLanguagePointsCalculator.SecondLangPointsCalculator(primaryAplicantSecondLangPoints.CLBWritingPoints);
                pointsForSecondLangReading = SecondLanguagePointsCalculator.SecondLangPointsCalculator(primaryAplicantSecondLangPoints.CLBReadingPoints);
                pointsForSecondLangListening = SecondLanguagePointsCalculator.SecondLangPointsCalculator(primaryAplicantSecondLangPoints.CLBListeningPoints);

                pointsForSecondLanguage = pointsForSecondLangSpeaking + pointsForSecondLangWriting + pointsForSecondLangReading + pointsForSecondLangListening;
                DisplayMessage("Point for second language: " + pointsForSecondLanguage.ToString(), ConsoleColor.Green);
            }
            else
            {
                DisplayMessage("No points for the second language.", ConsoleColor.Green);
            }

            isFirstAttempt = true;
            string experienceTime;
            int parsedExperienceTime;
            do
            {
                if (!isFirstAttempt)
                {
                    DisplayMessage("Wrong value. Please try again.", ConsoleColor.Red);
                }
                DisplayMessage("How many years of work experience do you have in the Canadian labour market? (warning!: The year of experience is calculated after having completed the full year worked. If you have worked less than a year, enter 0. There is no rounding up).");
                experienceTime = System.Console.ReadLine();

                isFirstAttempt = false;
            }
            while (Int32.TryParse(experienceTime, out parsedExperienceTime) == false);

            int pointsForExperience;
            if (noSpouse == true)
            {
                pointsForExperience = ExperiencePointsCalculator.CountPointsForExperienceWithoutSpouse(parsedExperienceTime);
            }
            else
            {
                pointsForExperience = ExperiencePointsCalculator.CountPointsForExperienceWithSpouse(parsedExperienceTime);
            }
            DisplayMessage("Points for experience: " + pointsForExperience.ToString(), ConsoleColor.Green);

            int totalPointsForHumanCapitalFactors;
            totalPointsForHumanCapitalFactors = pointForAge + pointForEducation + pointsForLanguage + pointsForSecondLanguage + pointsForExperience;
            DisplayMessage("Points earned by you: " + totalPointsForHumanCapitalFactors.ToString(), ConsoleColor.Cyan);

            int totalPointsForSpouseOrCommonLawPartnerFactors = 0;
            if (noSpouse == true)
            {
                DisplayMessage("No points earned by spouse or common-law partner.", ConsoleColor.Cyan);
            }
            else
            {
                DisplayMessage("Please select the level of education of spouse or common-law partner (enter the number from 1 to 8).");
                ushort spouseEducationLevel = GetEducationalLevel();
                int pointsForSpouseEducation;
                pointsForSpouseEducation = EducationPointsCalculator.CountPointsForSpouseEducation(spouseEducationLevel);
                DisplayMessage("Points for education of spouse or common-law partner: " + pointsForSpouseEducation.ToString(), ConsoleColor.Green);

                LanguagePoints spouseFirstLangPoints = SetAndCalculateLanguagePoints();

                int pointsForSpouseSpeaking;
                int pointsForSpouseWriting;
                int pointsForSpouseReading;
                int pointsForSpouseListening;
                int pointsForSpouseLanguage;

                pointsForSpouseSpeaking = LanguagePointsCalculator.CalculatorOfSpouseLanguagePoints(spouseFirstLangPoints.CLBSpeakingPoints);
                pointsForSpouseWriting = LanguagePointsCalculator.CalculatorOfSpouseLanguagePoints(spouseFirstLangPoints.CLBWritingPoints);
                pointsForSpouseReading = LanguagePointsCalculator.CalculatorOfSpouseLanguagePoints(spouseFirstLangPoints.CLBReadingPoints);
                pointsForSpouseListening = LanguagePointsCalculator.CalculatorOfSpouseLanguagePoints(spouseFirstLangPoints.CLBListeningPoints);

                pointsForSpouseLanguage = pointsForSpouseSpeaking + pointsForSpouseWriting + pointsForSpouseReading + pointsForSpouseListening;
                DisplayMessage("Points for language of spouse or common-law partner: " + pointsForSpouseLanguage.ToString(), ConsoleColor.Green);

                isFirstAttempt = true;
                int parsedSpouseExperienceTime;
                int pointsForSpouseExperience;
                do
                {
                    if (!isFirstAttempt)
                    {
                        DisplayMessage("Wrong value. Please try again.", ConsoleColor.Red);
                    }
                    DisplayMessage("How many years of work experience in the Canadian labour market has your spouse or common-law partner? (warning!: The year of experience is calculated after having completed the full year worked. If your spouse or common-law partner has worked less than a year, enter 0. There is no rounding up).");
                    string spouseExperienceTime = System.Console.ReadLine();

                    isFirstAttempt = false;
                }
                while (Int32.TryParse(experienceTime, out parsedSpouseExperienceTime) == false);
           
                pointsForSpouseExperience = ExperiencePointsCalculator.CountPointsForSpouseExperience(parsedSpouseExperienceTime);

                DisplayMessage("Points for spouse experience: " + pointsForSpouseExperience.ToString(), ConsoleColor.Green);

                totalPointsForSpouseOrCommonLawPartnerFactors = pointsForSpouseEducation + pointsForSpouseLanguage + pointsForSpouseExperience;
                DisplayMessage("Points earned by spouse or common-law partner: " + totalPointsForSpouseOrCommonLawPartnerFactors.ToString(), ConsoleColor.Cyan);
            }

            isFirstAttempt = true;
            string foreignExperienceTime;
            int parsedForeignExperienceTime = 0;
            do
            {
                if (!isFirstAttempt)
                {
                    DisplayMessage("Wrong value. Please try again.", ConsoleColor.Red);
                }
                DisplayMessage("How many years of foreign work experiencein (outside Canada) do you have? (warning!: The year of experience is calculated after having completed the full year worked. If your spouse or common-law partner has worked less than a year, enter 0. There is no rounding up).");
                foreignExperienceTime = System.Console.ReadLine();

                isFirstAttempt = false;
            }
            while (Int32.TryParse(foreignExperienceTime, out parsedForeignExperienceTime) == false);


            int pointsForSkillTransferabilityFactors;
            pointsForSkillTransferabilityFactors = SkillTransferabilityFactorsCalculator.CalculateSkillTransferabilityFactorsPoints(primaryAplicantFirstLangPoints, educationLevel, parsedExperienceTime, parsedForeignExperienceTime);
            DisplayMessage("Points for skill transferability factor: " + pointsForSkillTransferabilityFactors.ToString(), ConsoleColor.Cyan);


            DisplayMessage("Does your brother or sister who is a citizen or permanent resident of Canada live in Canada? (YES or NO).");
            string canadianFamilyMember = System.Console.ReadLine();
            int canadianFamilyMemberPoints = AdditionalPointsCalculator.GiveAdditionalPoints(canadianFamilyMember);

            DisplayMessage("Have you graduated post-secondary education in Canada - credential of one or two years (YES or NO).");
            string canadianEducation = System.Console.ReadLine();
            int canadianEducationPoints = AdditionalPointsCalculator.GiveAdditionalPoints(canadianEducation);

            DisplayMessage("Have you graduated post-secondary education in Canada - credential three years or longer (YES or NO).");
            string canadianLongerEducation = System.Console.ReadLine();
            int canadianLongerEducationPoints = AdditionalPointsCalculator.GiveDoubleAdditionalPoints(canadianLongerEducation);

            DisplayMessage("Do you have arranged employment – any other NOC 0, A or B (YES or NO).");
            string canadianArrangedEmployment = System.Console.ReadLine();
            int canadianArrangedEmploymentPoints = AdditionalPointsCalculator.GiveAdditionalPointsForArrangedEmployment(canadianArrangedEmployment);

            DisplayMessage("Do you have arranged employment – any other NOC 00 (YES or NO).");
            string canadianArrangedEmploymentPlus = System.Console.ReadLine();
            int canadianArrangedEmploymentPlusPoints = AdditionalPointsCalculator.GiveMoreAdditionalPointsForArrangedEmployment(canadianArrangedEmploymentPlus);

            DisplayMessage("Have you got provincial or territorial nomination? (YES or NO).");
            string canadianProvincialOrTerritorialNomination = System.Console.ReadLine();
            int canadianProvincialOrTerritorialNominationPoints = AdditionalPointsCalculator.GiveAdditionalPointsForProvincialOrTerritorialNomination(canadianProvincialOrTerritorialNomination);


            int additionalLanguagePoints = 0;
            if (primaryAplicantFirstLangPoints.LanguageExamType == LanguagePoints.LanguageExamTypes.TEF)
            {
                additionalLanguagePoints = AdditionalPointsCalculator.GiveAdditionalPointsForLanguages(primaryAplicantFirstLangPoints, primaryAplicantSecondLangPoints);
            }

            int additionalPoints;
            additionalPoints = canadianFamilyMemberPoints + canadianEducationPoints + canadianLongerEducationPoints + canadianArrangedEmploymentPoints + canadianArrangedEmploymentPlusPoints + canadianProvincialOrTerritorialNominationPoints + additionalLanguagePoints;
            DisplayMessage("Additional points: " + additionalPoints.ToString(), ConsoleColor.Cyan);

            int totalPointsForExpressEntry;
            totalPointsForExpressEntry = totalPointsForHumanCapitalFactors + totalPointsForSpouseOrCommonLawPartnerFactors + pointsForSkillTransferabilityFactors + additionalPoints;
            DisplayMessage("Total points for Express Entry: " + totalPointsForExpressEntry.ToString(), ConsoleColor.Blue);

            Console.Read();
        }

        private static void DisplayMessage(string message, ConsoleColor color = ConsoleColor.DarkYellow)
        {
            System.Console.ForegroundColor = color;
            System.Console.WriteLine(message);
            System.Console.ResetColor();
        }

        static ushort GetEducationalLevel()
        {
            string levelNumber;
            bool isFirstAttempt = true;
            do
            {
                if (!isFirstAttempt)
                {
                    DisplayMessage("Wrong value. Please try again.", ConsoleColor.Red);
                }
                DisplayMessage("1.Less than secondary school (high school).");
                DisplayMessage("2.Secondary diploma (high school graduation).");
                DisplayMessage("3.One-year degree, diploma or certificate from  a university, college, trade or technical school, or other institute.");
                DisplayMessage("4.Two-year program at a university, college, trade or technical school, or other institute.");
                DisplayMessage("5.Bachelor's degree OR  a three or more year program at a university, college, trade or technical school, or other institute.");
                DisplayMessage("6.Two or more certificates, diplomas, or degrees. One must be for a program of three or more years.");
                DisplayMessage("7.Master's degree, OR professional degree needed to practice in a licensed profession (For “professional degree,” the degree program must have been in: medicine, veterinary medicine, dentistry, optometry, law, chiropractic medicine, or pharmacy.).");
                DisplayMessage("8.Doctoral level university degree (Ph.D.).");
                levelNumber = System.Console.ReadLine();

                isFirstAttempt = false;
            }
            while (levelNumber != "1" && levelNumber != "2" && levelNumber != "3" && levelNumber != "4" && levelNumber != "5" && levelNumber != "6" && levelNumber != "7" && levelNumber != "8");
            return ushort.Parse(levelNumber);
        }

        static LanguagePoints SetAndCalculateLanguagePoints()
        {
            LanguagePoints.LanguageExamTypes languageExamType = GetLanguageExamType();
           
            string speaking;
            double parsedSpeakingPoints;
            bool isFirstAttempt = true;
            do
            {
                if (!isFirstAttempt)
                {
                    DisplayMessage("Wrong value. Please try again.", ConsoleColor.Green);
                }
                DisplayMessage("How many points did you get for speaking?");
                speaking = System.Console.ReadLine();
                isFirstAttempt = false;
            }
            while (Double.TryParse(speaking, out parsedSpeakingPoints) == false);


            string writing;
            double parsedWritingPoints;
            isFirstAttempt = true;
            do
            {
                if (!isFirstAttempt)
                {
                    DisplayMessage("Wrong value. Please try again.", ConsoleColor.Red);
                }
                DisplayMessage("How many points did you get for writing?");
                writing = System.Console.ReadLine();
                isFirstAttempt = false;
            }
            while (Double.TryParse(writing, out parsedWritingPoints) == false);


            string reading;
            double parsedReadingPoints;
            isFirstAttempt = true;
            do
            {
                if (!isFirstAttempt)
                {
                    DisplayMessage("Wrong value. Please try again.", ConsoleColor.Red);
                }
                DisplayMessage("How many points did you get for reading?");
                reading = System.Console.ReadLine();
                isFirstAttempt = false;
            }
            while (Double.TryParse(reading, out parsedReadingPoints) == false);


            string listening;
            double parsedListeningPoints;
            isFirstAttempt = true;
            do
            {
                if (!isFirstAttempt)
                {
                    DisplayMessage("Wrong value. Please try again.", ConsoleColor.Red);
                }
                DisplayMessage("How many points did you get for listening?");
                listening = System.Console.ReadLine();
                isFirstAttempt = false;
            }
            while (Double.TryParse(listening, out parsedListeningPoints) == false);

            return new LanguagePoints(languageExamType, parsedSpeakingPoints, parsedWritingPoints, parsedReadingPoints, parsedListeningPoints);
        }

        static LanguagePoints.LanguageExamTypes GetLanguageExamType()
        {
            string langExamNumber;
            bool isFirstAttempt = true;
            do
            {
                if (!isFirstAttempt)
                {
                    DisplayMessage("Wrong value. Please try again.", ConsoleColor.Red);
                }
                DisplayMessage("What type of exam of your second language did you pass? (enter the number from 1 to 3).");
                DisplayMessage("1.IELTS");
                DisplayMessage("2.CELPIP");
                DisplayMessage("3.TEF");
                langExamNumber = System.Console.ReadLine();

                isFirstAttempt = false;
            }
            while (langExamNumber != "1" && langExamNumber != "2" && langExamNumber != "3");

            return LanguagePoints.IdentifyingTheTypeOfExam(langExamNumber);
        }
        
        
    }
}
