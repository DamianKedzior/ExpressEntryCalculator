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

            System.Console.WriteLine("What type of exam did you pass? (enter the number from 1 to 3)");
            System.Console.WriteLine("1.IELTS");
            System.Console.WriteLine("2.CELPIP");
            System.Console.WriteLine("3.TEF");
            string NumberOfExam = System.Console.ReadLine();
            LanguagePoints.LanguageExamTypes TypeOfExam  = IdentifyingTheTypeOfExam (NumberOfExam);
            
            LanguagePoints primaryAplicantPoints = new LanguagePoints();
            primaryAplicantPoints.LanguageExamType = TypeOfExam;

            Console.Read();
        }

        static LanguagePoints.LanguageExamTypes IdentifyingTheTypeOfExam(string TypeOfExam)
        {
            switch (TypeOfExam)
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
