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

            System.Console.WriteLine("FullName Spouse or common - law partner if exist");
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
            string sentence = "Points For Age ";
            string fullsentence = sentence + PointForAge.ToString();
            System.Console.WriteLine(fullsentence);


            System.Console.WriteLine("Select the level of education (enter the number from 1 to 8)");
            System.Console.WriteLine("1.Less than secondary school (high school)");
            System.Console.WriteLine("2.Secondary diploma (high school graduation)");
            System.Console.WriteLine("3.One-year degree, diploma or certificate from  a university, college, trade or technical school, or other institute");
            System.Console.WriteLine("4.Two-year program at a university, college, trade or technical school, or other institute");
            System.Console.WriteLine("5.Bachelor's degree OR  a three or more year program at a university, college, trade or technical school, or other institute");
            System.Console.WriteLine("6.Two or more certificates, diplomas, or degrees. One must be for a program of three or more years");
            System.Console.WriteLine("7.Master's degree, OR professional degree needed to practice in a licensed profession (For “professional degree,” the degree program must have been in: medicine, veterinary medicine, dentistry, optometry, law, chiropractic medicine, or pharmacy.)");
            System.Console.WriteLine("8.Doctoral level university degree (Ph.D.)");
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
            string educationSentence = "Points For Education ";
            string fullEducationSentence = educationSentence + PointForEducation.ToString();
            System.Console.WriteLine(fullEducationSentence);

            LanguagePoints.LanguageExamTypes TypeOfExam = GetLanguageExamType();

            LanguagePoints primaryAplicantFirstLangPoints = new LanguagePoints();
            primaryAplicantFirstLangPoints.LanguageExamType = TypeOfExam;

            System.Console.WriteLine("How many points did you get for reading?");
            string ReadingPoints = System.Console.ReadLine();
            primaryAplicantFirstLangPoints.ReadingPoints = double.Parse(ReadingPoints);

            System.Console.WriteLine("How many points did you get for listening?");
            string ListeningPoints = System.Console.ReadLine();
            primaryAplicantFirstLangPoints.ListeningPoints = double.Parse(ListeningPoints);

            System.Console.WriteLine("How many points did you get for speaking?");
            string SpeakingPoints = System.Console.ReadLine();
            primaryAplicantFirstLangPoints.SpeakingPoints = double.Parse(SpeakingPoints);

            System.Console.WriteLine("How many points did you get for writing?");
            string WritingPoints = System.Console.ReadLine();
            primaryAplicantFirstLangPoints.WritingPoints = double.Parse(WritingPoints);

            primaryAplicantFirstLangPoints.CalculateCLBPoints();


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
            string TotalPointsForLanguage = PointsForLanguage.ToString();
            System.Console.WriteLine("Points for 1st language " + TotalPointsForLanguage);


            System.Console.WriteLine("Did you pass second language exam? (YES or NO)");
            string SecondLanguage = System.Console.ReadLine();
            int PointsForSecondLanguage = 0;
            if (SecondLanguage.ToUpper() == "YES")
            {
                LanguagePoints.LanguageExamTypes TypeOfSecondLangExam = GetLanguageExamType();

                LanguagePoints primaryAplicantSecondLangPoints = new LanguagePoints();

                primaryAplicantSecondLangPoints.LanguageExamType = TypeOfSecondLangExam;

                System.Console.WriteLine("How many points did you get for speaking?");
                string SpeakingPointsOfSecondLangExam = System.Console.ReadLine();
                primaryAplicantSecondLangPoints.SpeakingPoints = double.Parse(SpeakingPointsOfSecondLangExam);

                System.Console.WriteLine("How many points did you get for writing?");
                string WritingPointsOfSecondLangExam = System.Console.ReadLine();
                primaryAplicantSecondLangPoints.WritingPoints = double.Parse(WritingPointsOfSecondLangExam);

                System.Console.WriteLine("How many points did you get for reading?");
                string ReadingPointsOfSecondLangExam = System.Console.ReadLine();
                primaryAplicantSecondLangPoints.ReadingPoints = double.Parse(ReadingPointsOfSecondLangExam);

                System.Console.WriteLine("How many points did you get for listening?");
                string ListeningPointsOfSecondLangExam = System.Console.ReadLine();
                primaryAplicantSecondLangPoints.ListeningPoints = double.Parse(ListeningPointsOfSecondLangExam);

                primaryAplicantSecondLangPoints.CalculateCLBPoints();

                int PointsForSecondLangSpeaking;
                int PointsForSecondLangWriting;
                int PointsForSecondLangReading;
                int PointsForSecondLangListening;

                PointsForSecondLangSpeaking = SecondLanguagePointsCalculator.SecondLangPointsCalculator(primaryAplicantSecondLangPoints.CLBSpeakingPoints);
                PointsForSecondLangWriting = SecondLanguagePointsCalculator.SecondLangPointsCalculator(primaryAplicantSecondLangPoints.CLBWritingPoints);
                PointsForSecondLangReading = SecondLanguagePointsCalculator.SecondLangPointsCalculator(primaryAplicantSecondLangPoints.CLBReadingPoints);
                PointsForSecondLangListening = SecondLanguagePointsCalculator.SecondLangPointsCalculator(primaryAplicantSecondLangPoints.CLBListeningPoints);

                PointsForSecondLanguage = PointsForSecondLangSpeaking + PointsForSecondLangWriting + PointsForSecondLangReading + PointsForSecondLangListening;
                string TotalPointsForSecondLanguage = PointsForSecondLanguage.ToString();
                System.Console.WriteLine("Point For Second Language " + TotalPointsForSecondLanguage);
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
            string experienceSentence = "Points For Experience ";
            string fullExperienceSentence = experienceSentence + PointsForExperience.ToString();
            System.Console.WriteLine(fullExperienceSentence);

            int TotalPointsForHumanCapitalFactors;
            TotalPointsForHumanCapitalFactors = PointForAge + PointForEducation + PointsForLanguage + PointsForSecondLanguage + PointsForExperience;
            string totalPointsSentence = "Points earned by you ";
            string fullTotalPointsSentence = totalPointsSentence + TotalPointsForHumanCapitalFactors.ToString();
            System.Console.WriteLine(fullTotalPointsSentence);

            Console.Read();
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
