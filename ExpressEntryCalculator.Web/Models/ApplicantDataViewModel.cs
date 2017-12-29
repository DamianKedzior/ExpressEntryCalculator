using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExpressEntryCalculator.Web.Models
{
    public class ApplicantDataViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        public bool SpouseExist { get; set; }
        public ushort EducationLevel { get; set; }

        public List<SelectListItem> EducationLevels { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "1", Text = "Less than secondary school." },
            new SelectListItem { Value = "2", Text = "Secondary diploma (high school graduation)."  },
            new SelectListItem { Value = "3", Text = "One-year degree, diploma or certificate from  a university, college, trade or technical school, or other institute." },
            new SelectListItem { Value = "4", Text = "Two-year program at a university, college, trade or technical school, or other institute." },
            new SelectListItem { Value = "5", Text = "Bachelor's degree OR a three or more year program at a university, college, trade or technical school, or other institute."  },
            new SelectListItem { Value = "6", Text = "Two or more certificates, diplomas, or degrees. One must be for a program of three or more years." },
            new SelectListItem { Value = "7", Text = "Master's degree, OR professional degree needed to practice in a licensed profession (For “professional degree,” the degree program must have been in: medicine, veterinary medicine, dentistry, optometry, law, chiropractic medicine, or pharmacy.)." },
            new SelectListItem { Value = "8", Text = "Doctoral level university degree (Ph.D.)."  },
        };
        
        public int TypeOfFirstExam { get; set; }

        public List<SelectListItem> ExamTypes { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "1", Text = "IELTS"},
            new SelectListItem { Value = "2", Text = "CELPIP"},
            new SelectListItem { Value = "3", Text = "TEF"},
        };

        public double SpeakingPoints { get; set; }
        public double WritingPoints { get; set; }
        public double ReadingPoints { get; set; }
        public double ListeningPoints { get; set; }

        public bool SecondLanguage { get; set; }
        public int TypeOfSecondExam { get; set; }
        public double SpeakingPointsSecondLanguage { get; set; }
        public double WritingPointsSecondLanguage { get; set; }
        public double ReadingPointsSecondLanguage { get; set; }
        public double ListeningPointsSecondLanguage { get; set; }

        public int CanadianExperience { get; set; }

        public string SpouseFullname { get; set; }
        public ushort SpouseEducationLevel { get; set; }
        public int TypeOfSpouseExam { get; set; }
        public double SpouseSpeakingPoints{ get; set; }
        public double SpouseWritingPoints{ get; set; }
        public double SpouseReadingPoints { get; set; }
        public double SpouseListeningPoints { get; set; }
        public int SpouseCanadianExperience { get; set; }

        public int ExperienceOutsideCanada { get; set; }

        public bool CanadianFamilyMember { get; set; }
        public bool CanadianEducation { get; set; }
        public bool CanadianLongerEducation { get; set; }
        public bool CanadianArrangedEmployment { get; set; }
        public bool CanadianArrangedEmploymentPlus { get; set; }
        public bool CanadianProvincialOrTerritorialNomination { get; set; }
    }
}
