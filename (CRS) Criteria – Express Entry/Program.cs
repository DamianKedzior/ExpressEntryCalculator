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
            System.Console.WriteLine("Imię");
            string firstname = System.Console.ReadLine();
            System.Console.WriteLine("Nazwisko");
            string lastname = System.Console.ReadLine();
            System.Console.WriteLine("Date of birth (format: yyyy-mm-dd)");
            string DateOfBirth = System.Console.ReadLine();
            DateTime ParsedDateOfBirth = DateTime.Parse(DateOfBirth);
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

            GetEducationalLevel();
            string NumberOfLevel = System.Console.ReadLine();
            int EduLevel = Int32.Parse(NumberOfLevel);

            int PointForEducation;
            if (NoSpouse == true)
            {
                PointForEducation = EducationPointsCalculator.CountPointsForEducation(EduLevel);
            }
            else
            {
                PointForEducation = EducationPointsCalculator.CountPointsForEducationWithSpouse(EduLevel);
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
            if (SecondLanguage.ToUpper() == "YES")
            {
                LanguagePoints primaryAplicantSecondLangPoints = new LanguagePoints();

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
                System.Console.WriteLine("No points for the second language");
            }

            System.Console.WriteLine("How many years of work experience do you have in the Canadian labour market? (warning!: The year of experience is calculated after having completed the full year worked. If you have worked less than a year, enter 0. There is no rounding up)");
            string ExperienceTime = System.Console.ReadLine();
            int ParsedExperienceTime = Int32.Parse(ExperienceTime);

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

            if (NoSpouse == true)
            {
                System.Console.WriteLine("No points earned by spouse or common-law partner");
            }
            else
            {
                GetEducationalLevel();
                string NumberOfSpouseLevel = System.Console.ReadLine();
                int SpouseEduLevel = Int32.Parse(NumberOfLevel);
                int PointsForSpouseEducation;
                PointsForSpouseEducation = SpouseEducationPointsCalculator.CountPointsForSpouseEducation(SpouseEduLevel);
                System.Console.WriteLine("Points for education of spouse or common-law partner" + PointsForSpouseEducation.ToString());

                LanguagePoints spouseFirstLangPoints = new LanguagePoints();

                SetAndCalculateLanguagePoints(spouseFirstLangPoints);

                int PointsForSpouseSpeaking;
                int PointsForSpouseWriting;
                int PointsForSpouseReading;
                int PointsForSpouseListening;
                int PointsForSpouseLanguage;

                PointsForSpouseSpeaking = SpouseLanguagePointsCalculator.CalculatorOfSpouseLanguagePoints(spouseFirstLangPoints.CLBSpeakingPoints);
                PointsForSpouseWriting = SpouseLanguagePointsCalculator.CalculatorOfSpouseLanguagePoints(spouseFirstLangPoints.CLBWritingPoints);
                PointsForSpouseReading = SpouseLanguagePointsCalculator.CalculatorOfSpouseLanguagePoints(spouseFirstLangPoints.CLBReadingPoints);
                PointsForSpouseListening = SpouseLanguagePointsCalculator.CalculatorOfSpouseLanguagePoints(spouseFirstLangPoints.CLBListeningPoints);

                PointsForSpouseLanguage = PointsForSpouseSpeaking + PointsForSpouseWriting + PointsForSpouseReading + PointsForSpouseListening;
                System.Console.WriteLine("Points for language of spouse or common-law partner " + PointsForSpouseLanguage.ToString());

                System.Console.WriteLine("How many years of work experience in the Canadian labour market has your spouse or common-law partner? (warning!: The year of experience is calculated after having completed the full year worked. If your spouse or common-law partner has worked less than a year, enter 0. There is no rounding up)");
                string SpouseExperienceTime = System.Console.ReadLine();
                int ParsedSpouseExperienceTime = Int32.Parse(ExperienceTime);
                int PointsForSpouseExperience;
                PointsForSpouseExperience = SpouseExperiencePointsCalculator.CountPointsForSpouseExperience(ParsedSpouseExperienceTime);

                System.Console.WriteLine("Points for spouse experience " + PointsForSpouseExperience.ToString());

                int TotalPointsForSpouseOrCommonLawPartnerFactors;
                TotalPointsForSpouseOrCommonLawPartnerFactors = PointsForSpouseEducation + PointsForSpouseLanguage + PointsForSpouseExperience;
                System.Console.WriteLine("Points earned by spouse or common-law partner " + TotalPointsForSpouseOrCommonLawPartnerFactors.ToString());
            }

            Console.Read();
        }

        static void GetEducationalLevel()
        {
            System.Console.WriteLine("Select the spouse’s or common-law partner’s level of education(enter the number from 1 to 8)");
            System.Console.WriteLine("1.Less than secondary school (high school)");
            System.Console.WriteLine("2.Secondary diploma (high school graduation)");
            System.Console.WriteLine("3.One-year degree, diploma or certificate from  a university, college, trade or technical school, or other institute");
            System.Console.WriteLine("4.Two-year program at a university, college, trade or technical school, or other institute");
            System.Console.WriteLine("5.Bachelor's degree OR  a three or more year program at a university, college, trade or technical school, or other institute");
            System.Console.WriteLine("6.Two or more certificates, diplomas, or degrees. One must be for a program of three or more years");
            System.Console.WriteLine("7.Master's degree, OR professional degree needed to practice in a licensed profession (For “professional degree,” the degree program must have been in: medicine, veterinary medicine, dentistry, optometry, law, chiropractic medicine, or pharmacy.)");
            System.Console.WriteLine("8.Doctoral level university degree (Ph.D.)");
        }

        static void SetAndCalculateLanguagePoints(LanguagePoints langPoints)
        {
            langPoints.LanguageExamType = GetLanguageExamType();

            System.Console.WriteLine("How many points did you get for speaking?");
            string SpeakingPointsOfLangExam = System.Console.ReadLine();
            langPoints.SpeakingPoints = double.Parse(SpeakingPointsOfLangExam);

            System.Console.WriteLine("How many points did you get for writing?");
            string WritingPointsOfLangExam = System.Console.ReadLine();
            langPoints.WritingPoints = double.Parse(WritingPointsOfLangExam);

            System.Console.WriteLine("How many points did you get for reading?");
            string ReadingPointsOfLangExam = System.Console.ReadLine();
            langPoints.ReadingPoints = double.Parse(ReadingPointsOfLangExam);

            System.Console.WriteLine("How many points did you get for listening?");
            string ListeningPointsOfLangExam = System.Console.ReadLine();
            langPoints.ListeningPoints = double.Parse(ListeningPointsOfLangExam);

            langPoints.CalculateCLBPoints();

        }

        static LanguagePoints.LanguageExamTypes GetLanguageExamType()
        {
            System.Console.WriteLine("What type of exam of your second language did you pass? (enter the number from 1 to 3)");
            System.Console.WriteLine("1.IELTS");
            System.Console.WriteLine("2.CELPIP");
            System.Console.WriteLine("3.TEF");

            string langExamNumber = System.Console.ReadLine();
            LanguagePoints.LanguageExamTypes langExamType = IdentifyingTheTypeOfExam(langExamNumber);

            return langExamType;
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
