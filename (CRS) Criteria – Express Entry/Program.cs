using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _CRS__Criteria___Express_Entry
{
    class Program
    {
        static void Main(string[] args)
        {
            DisplayMessage("Please provide your first name", ConsoleColor.Yellow);
            string firstname = System.Console.ReadLine();
            DisplayMessage("Please provide your last name", ConsoleColor.Yellow);
            string lastname = System.Console.ReadLine();

            DateTime ParsedDateOfBirth;
            string DateOfBirth;

            bool isFirstAttempt = true;
            do
            {
                if (!isFirstAttempt)
                {
                    DisplayMessage("Wrong date format. Please try again");
                }
                System.Console.WriteLine("Date of birth (format: yyyy-mm-dd)");
                DateOfBirth = System.Console.ReadLine();

                isFirstAttempt = false;
            }
            while (DateTime.TryParse(DateOfBirth, out ParsedDateOfBirth) == false);

            int age = CountAge(ParsedDateOfBirth);
            System.Console.WriteLine("Your age is " + age);

            System.Console.WriteLine("FullName spouse or common - law partner if exist");
            string spouseFullname = System.Console.ReadLine();
            bool NoSpouse = String.IsNullOrWhiteSpace(spouseFullname);

            int PointForAge;
            if (NoSpouse == true)
            {
                PointForAge = AgePointsCalculator.CountPointsForAge(age);
            }
            else
            {
                PointForAge = AgePointsCalculator.CountPointsForAgeWithSpouse(age);
            }
            System.Console.WriteLine("Points for age " + PointForAge.ToString());

            System.Console.WriteLine("Select the level of education (enter the number from 1 to 8)");

            int EducationLevel = GetEducationalLevel();

            int PointForEducation;

            if (NoSpouse == true)
            {
                PointForEducation = EducationPointsCalculator.CountPointsForEducation(EducationLevel);
            }
            else
            {
                PointForEducation = EducationPointsCalculator.CountPointsForEducationWithSpouse(EducationLevel);
            }
            System.Console.WriteLine("Points for education " + PointForEducation.ToString());


            LanguagePoints primaryAplicantFirstLangPoints = new LanguagePoints();

            SetAndCalculateLanguagePoints(primaryAplicantFirstLangPoints);

            int PointsForSpeaking;
            int PointsForWriting;
            int PointsForReading;
            int PointsForListening;
            int PointsForLanguage;
            if (NoSpouse == true)
            {
                PointsForSpeaking = LanguagePointsCalculator.LanguagePointsCalculatorWithoutSpouse(primaryAplicantFirstLangPoints.CLBSpeakingPoints);
                PointsForWriting = LanguagePointsCalculator.LanguagePointsCalculatorWithoutSpouse(primaryAplicantFirstLangPoints.CLBWritingPoints);
                PointsForReading = LanguagePointsCalculator.LanguagePointsCalculatorWithoutSpouse(primaryAplicantFirstLangPoints.CLBReadingPoints);
                PointsForListening = LanguagePointsCalculator.LanguagePointsCalculatorWithoutSpouse(primaryAplicantFirstLangPoints.CLBListeningPoints);
            }
            else
            {
                PointsForSpeaking = LanguagePointsCalculator.LanguagePointsCalculatorWithSpouse(primaryAplicantFirstLangPoints.CLBSpeakingPoints);
                PointsForWriting = LanguagePointsCalculator.LanguagePointsCalculatorWithSpouse(primaryAplicantFirstLangPoints.CLBWritingPoints);
                PointsForReading = LanguagePointsCalculator.LanguagePointsCalculatorWithSpouse(primaryAplicantFirstLangPoints.CLBReadingPoints);
                PointsForListening = LanguagePointsCalculator.LanguagePointsCalculatorWithSpouse(primaryAplicantFirstLangPoints.CLBListeningPoints);
            }
            PointsForLanguage = PointsForSpeaking + PointsForWriting + PointsForReading + PointsForListening;
            System.Console.WriteLine("Points for 1st language " + PointsForLanguage.ToString());


            System.Console.WriteLine("Did you pass second language exam? (YES or NO)");
            string SecondLanguage = System.Console.ReadLine();
            int PointsForSecondLanguage = 0;
            LanguagePoints primaryAplicantSecondLangPoints = null;

            if (SecondLanguage.ToUpper() == "YES")
            {
                primaryAplicantSecondLangPoints = new LanguagePoints();
                SetAndCalculateLanguagePoints(primaryAplicantSecondLangPoints);

                int PointsForSecondLangSpeaking;
                int PointsForSecondLangWriting;
                int PointsForSecondLangReading;
                int PointsForSecondLangListening;

                PointsForSecondLangSpeaking = SecondLanguagePointsCalculator.SecondLangPointsCalculator(primaryAplicantSecondLangPoints.CLBSpeakingPoints);
                PointsForSecondLangWriting = SecondLanguagePointsCalculator.SecondLangPointsCalculator(primaryAplicantSecondLangPoints.CLBWritingPoints);
                PointsForSecondLangReading = SecondLanguagePointsCalculator.SecondLangPointsCalculator(primaryAplicantSecondLangPoints.CLBReadingPoints);
                PointsForSecondLangListening = SecondLanguagePointsCalculator.SecondLangPointsCalculator(primaryAplicantSecondLangPoints.CLBListeningPoints);

                PointsForSecondLanguage = PointsForSecondLangSpeaking + PointsForSecondLangWriting + PointsForSecondLangReading + PointsForSecondLangListening;
                System.Console.WriteLine("Point for second language " + PointsForSecondLanguage.ToString());
            }
            else
            {
                System.Console.WriteLine("No points for the second language ");
            }

            isFirstAttempt = true;
            string ExperienceTime;
            int ParsedExperienceTime;
            do
            {
                if (!isFirstAttempt)
                {
                    DisplayMessage("Wrong value. Please try again.");
                }
                System.Console.WriteLine("How many years of work experience do you have in the Canadian labour market? (warning!: The year of experience is calculated after having completed the full year worked. If you have worked less than a year, enter 0. There is no rounding up)");
                ExperienceTime = System.Console.ReadLine();

                isFirstAttempt = false;
            }
            while (Int32.TryParse(ExperienceTime, out ParsedExperienceTime) == false);

            int PointsForExperience;
            if (NoSpouse == true)
            {
                PointsForExperience = ExperiencePointsCalculator.CountPointsForExperienceWithoutSpouse(ParsedExperienceTime);
            }
            else
            {
                PointsForExperience = ExperiencePointsCalculator.CountPointsForExperienceWithSpouse(ParsedExperienceTime);
            }
            System.Console.WriteLine("Points for experience " + PointsForExperience.ToString());

            int TotalPointsForHumanCapitalFactors;
            TotalPointsForHumanCapitalFactors = PointForAge + PointForEducation + PointsForLanguage + PointsForSecondLanguage + PointsForExperience;
            System.Console.WriteLine("Points earned by you " + TotalPointsForHumanCapitalFactors.ToString());

            int TotalPointsForSpouseOrCommonLawPartnerFactors = 0;
            if (NoSpouse == true)
            {
                System.Console.WriteLine("No points earned by spouse or common-law partner");
            }
            else
            {
                System.Console.WriteLine("Select the level of education of spouse or common-law partner (enter the number from 1 to 8)");
                int SpouseEducationLevel = GetEducationalLevel();
                int PointsForSpouseEducation;
                PointsForSpouseEducation = EducationPointsCalculator.CountPointsForSpouseEducation(SpouseEducationLevel);
                System.Console.WriteLine("Points for education of spouse or common-law partner" + PointsForSpouseEducation.ToString());

                LanguagePoints spouseFirstLangPoints = new LanguagePoints();

                SetAndCalculateLanguagePoints(spouseFirstLangPoints);

                int PointsForSpouseSpeaking;
                int PointsForSpouseWriting;
                int PointsForSpouseReading;
                int PointsForSpouseListening;
                int PointsForSpouseLanguage;

                PointsForSpouseSpeaking = LanguagePointsCalculator.CalculatorOfSpouseLanguagePoints(spouseFirstLangPoints.CLBSpeakingPoints);
                PointsForSpouseWriting = LanguagePointsCalculator.CalculatorOfSpouseLanguagePoints(spouseFirstLangPoints.CLBWritingPoints);
                PointsForSpouseReading = LanguagePointsCalculator.CalculatorOfSpouseLanguagePoints(spouseFirstLangPoints.CLBReadingPoints);
                PointsForSpouseListening = LanguagePointsCalculator.CalculatorOfSpouseLanguagePoints(spouseFirstLangPoints.CLBListeningPoints);

                PointsForSpouseLanguage = PointsForSpouseSpeaking + PointsForSpouseWriting + PointsForSpouseReading + PointsForSpouseListening;
                System.Console.WriteLine("Points for language of spouse or common-law partner " + PointsForSpouseLanguage.ToString());

                isFirstAttempt = true;
                int ParsedSpouseExperienceTime;
                int PointsForSpouseExperience;
                do
                {
                    if (!isFirstAttempt)
                    {
                        DisplayMessage("Wrong value. Please try again.");
                    }
                    System.Console.WriteLine("How many years of work experience in the Canadian labour market has your spouse or common-law partner? (warning!: The year of experience is calculated after having completed the full year worked. If your spouse or common-law partner has worked less than a year, enter 0. There is no rounding up)");
                    string SpouseExperienceTime = System.Console.ReadLine();

                    isFirstAttempt = false;
                }
                while (Int32.TryParse(ExperienceTime, out ParsedSpouseExperienceTime) == false);
           
                PointsForSpouseExperience = ExperiencePointsCalculator.CountPointsForSpouseExperience(ParsedSpouseExperienceTime);

                System.Console.WriteLine("Points for spouse experience " + PointsForSpouseExperience.ToString());

                TotalPointsForSpouseOrCommonLawPartnerFactors = PointsForSpouseEducation + PointsForSpouseLanguage + PointsForSpouseExperience;
                System.Console.WriteLine("Points earned by spouse or common-law partner " + TotalPointsForSpouseOrCommonLawPartnerFactors.ToString());
            }

            isFirstAttempt = true;
            string foreignExperienceTime;
            int ParsedForeignExperienceTime = 0;
            do
            {
                if (!isFirstAttempt)
                {
                    DisplayMessage("Wrong value. Please try again.");
                }
                System.Console.WriteLine("How many years of foreign work experiencein (outside Canada) do you have? (warning!: The year of experience is calculated after having completed the full year worked. If your spouse or common-law partner has worked less than a year, enter 0. There is no rounding up) ");
                foreignExperienceTime = System.Console.ReadLine();

                isFirstAttempt = false;
            }
            while (Int32.TryParse(foreignExperienceTime, out ParsedExperienceTime) == false);


            int PointsForSkillTransferabilityFactors;
            PointsForSkillTransferabilityFactors = SkillTransferabilityFactorsCalculator.CalculateSkillTransferabilityFactorsPoints(primaryAplicantFirstLangPoints, EducationLevel, ParsedExperienceTime, ParsedForeignExperienceTime);
            System.Console.WriteLine("Points for skill transferability factor " + PointsForSkillTransferabilityFactors.ToString());


            System.Console.WriteLine("Does your brother or sister who is a citizen or permanent resident of Canada live in Canada? (YES or NO)");
            string CanadianFamilyMember = System.Console.ReadLine();
            int CanadianFamilyMemberPoints;
            CanadianFamilyMemberPoints = AdditionalPointsCalculator.GiveAdditionalPoints(CanadianFamilyMember);

            System.Console.WriteLine("Have you graduated post-secondary education in Canada - credential of one or two years (YES or NO)");
            string CanadianEducation = System.Console.ReadLine();
            int CanadianEducationPoints;
            CanadianEducationPoints = AdditionalPointsCalculator.GiveAdditionalPoints(CanadianEducation);

            System.Console.WriteLine("Have you graduated post-secondary education in Canada - credential three years or longer (YES or NO)");
            string CanadianLongerEducation = System.Console.ReadLine();
            int CanadianLongerEducationPoints;
            CanadianLongerEducationPoints = AdditionalPointsCalculator.GiveDoubleAdditionalPoints(CanadianLongerEducation);

            System.Console.WriteLine("Arranged employment – any other NOC 0, A or B (YES or NO)");
            string CanadianArrangedEmployment = System.Console.ReadLine();
            int CanadianArrangedEmploymentPoints;
            CanadianArrangedEmploymentPoints = AdditionalPointsCalculator.GiveAdditionalPointsForArrangedEmployment(CanadianArrangedEmployment);

            System.Console.WriteLine("Arranged employment – any other NOC 00 (YES or NO)");
            string CanadianArrangedEmploymentPlus = System.Console.ReadLine();
            int CanadianArrangedEmploymentPlusPoints;
            CanadianArrangedEmploymentPlusPoints = AdditionalPointsCalculator.GiveMoreAdditionalPointsForArrangedEmployment(CanadianArrangedEmploymentPlus);

            System.Console.WriteLine("Have you got provincial or territorial nomination? (YES or NO)");
            string CanadianProvincialOrTerritorialNomination = System.Console.ReadLine();
            int CanadianProvincialOrTerritorialNominationPoints;
            CanadianProvincialOrTerritorialNominationPoints = AdditionalPointsCalculator.GiveAdditionalPointsForProvincialOrTerritorialNomination(CanadianProvincialOrTerritorialNomination);


            int AdditionalLanguagePoints = 0;
            if (primaryAplicantFirstLangPoints.LanguageExamType == LanguagePoints.LanguageExamTypes.TEF)
            {
                AdditionalLanguagePoints = AdditionalPointsCalculator.GiveAdditionalPointsForLanguages(primaryAplicantFirstLangPoints, primaryAplicantSecondLangPoints);
            }

            int additionalPoints;
            additionalPoints = CanadianFamilyMemberPoints + CanadianEducationPoints + CanadianLongerEducationPoints + CanadianArrangedEmploymentPoints + CanadianArrangedEmploymentPlusPoints + CanadianProvincialOrTerritorialNominationPoints + AdditionalLanguagePoints;
            System.Console.WriteLine("Additional points " + additionalPoints.ToString());

            int totalPointsForExpressEntry;
            totalPointsForExpressEntry = TotalPointsForHumanCapitalFactors + TotalPointsForSpouseOrCommonLawPartnerFactors + PointsForSkillTransferabilityFactors + additionalPoints;
            System.Console.WriteLine("Total points for Express Entry " + totalPointsForExpressEntry.ToString());

            Console.Read();
        }

        private static void DisplayMessage(string message, ConsoleColor color = ConsoleColor.Red)
        {
            System.Console.ForegroundColor = color;
            System.Console.WriteLine(message);
            System.Console.ResetColor();
        }

        static int GetEducationalLevel()
        {
            string levelNumber;
            bool isFirstAttempt = true;
            do
            {
                if (!isFirstAttempt)
                {
                    DisplayMessage("Wrong value. Please try again.");
                }
                System.Console.WriteLine("1.Less than secondary school (high school)");
                System.Console.WriteLine("2.Secondary diploma (high school graduation)");
                System.Console.WriteLine("3.One-year degree, diploma or certificate from  a university, college, trade or technical school, or other institute");
                System.Console.WriteLine("4.Two-year program at a university, college, trade or technical school, or other institute");
                System.Console.WriteLine("5.Bachelor's degree OR  a three or more year program at a university, college, trade or technical school, or other institute");
                System.Console.WriteLine("6.Two or more certificates, diplomas, or degrees. One must be for a program of three or more years");
                System.Console.WriteLine("7.Master's degree, OR professional degree needed to practice in a licensed profession (For “professional degree,” the degree program must have been in: medicine, veterinary medicine, dentistry, optometry, law, chiropractic medicine, or pharmacy.)");
                System.Console.WriteLine("8.Doctoral level university degree (Ph.D.)");
                levelNumber = System.Console.ReadLine();

                isFirstAttempt = false;
            }
            while (levelNumber != "1" && levelNumber != "2" && levelNumber != "3" && levelNumber != "4" && levelNumber != "5" && levelNumber != "6" && levelNumber != "7" && levelNumber != "8");
            return Int32.Parse(levelNumber);
        }

        static void SetAndCalculateLanguagePoints(LanguagePoints langPoints)
        {
            langPoints.LanguageExamType = GetLanguageExamType();
           
            string points;
            double parsedPoints;
            bool isFirstAttempt = true;
            do
            {
                if (!isFirstAttempt)
                {
                    DisplayMessage("Wrong value. Please try again.");
                }
                System.Console.WriteLine("How many points did you get for speaking?");
                points = System.Console.ReadLine();
                isFirstAttempt = false;
            }
            while (Double.TryParse(points, out parsedPoints) == false);
            langPoints.SpeakingPoints = parsedPoints;

            isFirstAttempt = true;
            do
            {
                if (!isFirstAttempt)
                {
                    DisplayMessage("Wrong value. Please try again.");
                }
                System.Console.WriteLine("How many points did you get for writing?");
                points = System.Console.ReadLine();
                isFirstAttempt = false;
            }
            while (Double.TryParse(points, out parsedPoints) == false);
            langPoints.WritingPoints = parsedPoints;

            isFirstAttempt = true;
            do
            {
                if (!isFirstAttempt)
                {
                    DisplayMessage("Wrong value. Please try again.");
                }
                System.Console.WriteLine("How many points did you get for reading?");
                points = System.Console.ReadLine();
                isFirstAttempt = false;
            }
            while (Double.TryParse(points, out parsedPoints) == false);
            langPoints.ReadingPoints = parsedPoints;

            isFirstAttempt = true;
            do
            {
                if (!isFirstAttempt)
                {
                    DisplayMessage("Wrong value. Please try again.");
                }
                System.Console.WriteLine("How many points did you get for listening?");
                points = System.Console.ReadLine();
                isFirstAttempt = false;
            }
            while (Double.TryParse(points, out parsedPoints) == false);
            langPoints.ListeningPoints = parsedPoints;

            langPoints.CalculateCLBPoints();
        }

        static LanguagePoints.LanguageExamTypes GetLanguageExamType()
        {
            string langExamNumber;
            bool isFirstAttempt = true;
            do
            {
                if (!isFirstAttempt)
                {
                    DisplayMessage("Wrong value. Please try again.");
                }
                System.Console.WriteLine("What type of exam of your second language did you pass? (enter the number from 1 to 3)");
                System.Console.WriteLine("1.IELTS");
                System.Console.WriteLine("2.CELPIP");
                System.Console.WriteLine("3.TEF");
                langExamNumber = System.Console.ReadLine();

                isFirstAttempt = false;
            }
            while (langExamNumber != "1" && langExamNumber != "2" && langExamNumber != "3");

            return IdentifyingTheTypeOfExam(langExamNumber);
        }
        
        static LanguagePoints.LanguageExamTypes IdentifyingTheTypeOfExam(string Exam)
        {
            switch (Exam)
            {
                case "1":
                    return LanguagePoints.LanguageExamTypes.IELTS;
                case "2":
                    return LanguagePoints.LanguageExamTypes.CELPIP;
                case "3":
                    return LanguagePoints.LanguageExamTypes.TEF;
                default:
                    return LanguagePoints.LanguageExamTypes.IELTS;
            }
        }

        static int CountAge(DateTime birthday)
        {
            DateTime now = DateTime.UtcNow;
            int age = now.Year - birthday.Year;

            if (now.Month < birthday.Month)
            {
                age = age - 1;
                return age;
            }
            if (now.Month == birthday.Month && now.Day < birthday.Day)
            {
                age = age - 1;
                return age;
            }
            else
            {
                return age;
            }
        }
    }
}
