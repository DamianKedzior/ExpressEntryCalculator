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
                PointForAge = CountPointsForAge(age);
            }
            else
            {
                PointForAge = CountPointsForAgeWithSpouse(age);
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
                PointForEducation = CountPointsForEducation(EduLevel);
            }
            else
            {
                PointForEducation = CountPointsForEducationWithSpouse(EduLevel);
            }
            string educationSentence = "Points For Education ";
            string fullEducationSentence = educationSentence + PointForEducation.ToString();
            System.Console.WriteLine(fullEducationSentence);


            Console.Read();
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


        static int CountPointsForAgeWithSpouse(int age)
        {
            if (age <= 17 || age >= 45)
            {
                return 0;
            }
            else if (age == 44)
            {
                return 5;
            }
            else if (age == 43)
            {
                return 15;
            }
            else if (age == 42)
            {
                return 25;
            }
            else if (age == 41)
            {
                return 35;
            }
            else if (age == 40)
            {
                return 45;
            }
            else if (age == 39)
            {
                return 50;
            }
            else if (age == 38)
            {
                return 55;
            }
            else if (age == 37)
            {
                return 60;
            }
            else if (age == 36)
            {
                return 65;
            }
            else if (age == 35)
            {
                return 70;
            }
            else if (age == 34)
            {
                return 75;
            }
            else if (age == 33)
            {
                return 80;
            }
            else if (age == 32)
            {
                return 85;
            }
            else if (age == 18 || age == 31)
            {
                return 90;
            }
            else if (age == 19 || age == 30)
            {
                return 95;
            }
            else
            {
                return 100;
            }
        }
        static int CountPointsForAge(int age)
        {
            if (age <= 17 || age >= 45)
            {
                return 0;
            }
            else if (age == 44)
            {
                return 6;
            }
            else if (age == 43)
            {
                return 17;
            }
            else if (age == 42)
            {
                return 28;
            }
            else if (age == 41)
            {
                return 39;
            }
            else if (age == 40)
            {
                return 50;
            }
            else if (age == 39)
            {
                return 55;
            }
            else if (age == 38)
            {
                return 61;
            }
            else if (age == 37)
            {
                return 66;
            }
            else if (age == 36)
            {
                return 72;
            }
            else if (age == 35)
            {
                return 77;
            }
            else if (age == 34)
            {
                return 83;
            }
            else if (age == 33)
            {
                return 88;
            }
            else if (age == 32)
            {
                return 94;
            }
            else if (age == 18 || age == 31)
            {
                return 99;
            }
            else if (age == 19 || age == 30)
            {
                return 105;
            }
            else
            {
                return 110;
            }
        }


        static int CountPointsForEducationWithSpouse(int EduLevel)
        {
            switch (EduLevel)
            {
                case 1:
                    return 0;
                case 2:
                    return 28;
                case 3:
                    return 84;
                case 4:
                    return 91;
                case 5:
                    return 112;
                case 6:
                    return 119;
                case 7:
                    return 126;
                case 8:
                    return 140;
                default:
                    return 0;
            }
        }

        static int CountPointsForEducation(int EduLevel)
        {
            switch (EduLevel)
            {
                case 1:
                    return 0;
                case 2:
                    return 30;
                case 3:
                    return 90;
                case 4:
                    return 98;
                case 5:
                    return 120;
                case 6:
                    return 128;
                case 7:
                    return 135;
                case 8:
                    return 150;
                default:
                    return 0;
            }

        }

    }
}
