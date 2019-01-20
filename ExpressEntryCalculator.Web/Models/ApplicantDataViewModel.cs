using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ExpressEntryCalculator.Web.Models
{
    public class ApplicantDataViewModel
    {
        [Display(Name = "birth date")]
        [Required]
        [DataType(DataType.Date)]
        public DateTime? BirthDate { get; set; }
        public bool SpouseExist { get; set; }

        [Display(Name = "education level")]
        [Required]
        public ushort EducationLevel { get; set; }

        [JsonIgnore]
        public List<SelectListItem> EducationLevels
        {
            get
            {
                return getEducationLevels(EducationLevel);
            }
        }

        public int? TypeOfFirstExam { get; set; }

        [JsonIgnore]
        public List<SelectListItem> ExamTypes { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "", Text = "none" },
            new SelectListItem { Value = "1", Text = "IELTS - General Training"},
            new SelectListItem { Value = "2", Text = "CELPIP - General test"},
            new SelectListItem { Value = "3", Text = "TEF Canada"},
            new SelectListItem { Value = "4", Text = "TCF Canada"},
        };

        [Display(Name = "speaking points")]
        public double SpeakingPoints { get; set; }
        [Display(Name = "writing points")]
        public double WritingPoints { get; set; }
        [Display(Name = "reading points")]
        public double ReadingPoints { get; set; }
        [Display(Name = "listening points")]
        public double ListeningPoints { get; set; }

        public bool SecondLanguage { get; set; }
        public int TypeOfSecondExam { get; set; }

        [JsonIgnore]
        public List<SelectListItem> SecondExamTypes
        {
            get
            {
                if (!TypeOfFirstExam.HasValue) return new List<SelectListItem>();
                if (TypeOfFirstExam.Value == 1 || TypeOfFirstExam.Value == 2)
                {
                    return new List<SelectListItem>
                    {
                        new SelectListItem { Value = "3", Text = "TEF Canada"},
                        new SelectListItem { Value = "4", Text = "TCF Canada"},
                    };
                }
                else if (TypeOfFirstExam.Value == 3 || TypeOfFirstExam.Value == 4)
                {
                    return new List<SelectListItem>
                    {
                        new SelectListItem { Value = "1", Text = "IELTS - General Training"},
                        new SelectListItem { Value = "2", Text = "CELPIP - General test"},
                    };
                }
                else throw new NotImplementedException();
            }
        }

        [Display(Name = "speaking points")]
        public double SpeakingPointsSecondLanguage { get; set; }
        [Display(Name = "writing points")]
        public double WritingPointsSecondLanguage { get; set; }
        [Display(Name = "reading points")]
        public double ReadingPointsSecondLanguage { get; set; }
        [Display(Name = "listening points")]
        public double ListeningPointsSecondLanguage { get; set; }

        public int CanadianExperience { get; set; }

        [JsonIgnore]
        public List<SelectListItem> YearsOfCanadianExperience { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "0", Text = "none or less than a year" },
            new SelectListItem { Value = "1", Text = "1 year"},
            new SelectListItem { Value = "2", Text = "2 years"},
            new SelectListItem { Value = "3", Text = "3 years"},
            new SelectListItem { Value = "4", Text = "4 years"},
            new SelectListItem { Value = "5", Text = "5 years or more"},
        };

        [Display(Name = "education level")]
        [Required]
        public ushort SpouseEducationLevel { get; set; }

        [JsonIgnore]
        public List<SelectListItem> SpouseEducationLevels
        {
            get
            {
                return getEducationLevels(SpouseEducationLevel);
            }
        }

        public int? TypeOfSpouseExam { get; set; }
        [Display(Name = "speaking points")]
        public double SpouseSpeakingPoints { get; set; }
        [Display(Name = "writing points")]
        public double SpouseWritingPoints { get; set; }
        [Display(Name = "reading points")]
        public double SpouseReadingPoints { get; set; }
        [Display(Name = "listening points")]
        public double SpouseListeningPoints { get; set; }

        public int SpouseCanadianExperience { get; set; }

        public int ExperienceOutsideCanada { get; set; }

        [JsonIgnore]
        public List<SelectListItem> YearsOfExperienceOutsideCanada { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "0", Text = "none or less than a year" },
            new SelectListItem { Value = "1", Text = "1 year"},
            new SelectListItem { Value = "2", Text = "2 years"},
            new SelectListItem { Value = "3", Text = "3 years or more"},
        };

        public bool CanadianFamilyMember { get; set; }
        public int CanadianEducation { get; set; }
        public int CanadianArrangedEmployment { get; set; }
        public bool CanadianProvincialOrTerritorialNomination { get; set; }

        [JsonIgnore]
        public List<SelectListItem> EducationsInCanada { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "-1", Text = "No" },
            new SelectListItem { Value = "0", Text = "Secondary (high school) or less" },
            new SelectListItem { Value = "1", Text = "1- or 2- years diploma or certificate" },
            new SelectListItem { Value = "3", Text = "3- years or longer degree, diploma or certificate"  },
        };

        [JsonIgnore]
        public List<SelectListItem> EmploymentInCanada { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "0", Text = "No" },
            new SelectListItem { Value = "1", Text = "Yes, NOC 00" },
            new SelectListItem { Value = "2", Text = "Yes, any other NOC 0, A or B"  },
        };

        public ApplicantDataViewModel()
        {
            CanadianEducation = -1;
        }

        private List<SelectListItem> getEducationLevels(ushort level)
        {
            return new List<SelectListItem>
            {
                new SelectListItem { Value = "1", Text = "Less than secondary school.", Selected = level.ToString() == "1" },
                new SelectListItem { Value = "2", Text = "Secondary diploma (high school graduation).", Selected = level.ToString() == "2" },
                new SelectListItem { Value = "3", Text = "One-year degree, diploma or certificate from a university, college, trade or technical school, or other institute.", Selected = level.ToString() == "3" },
                new SelectListItem { Value = "4", Text = "Two-year program at a university, college, trade or technical school, or other institute.", Selected = level.ToString() == "4" },
                new SelectListItem { Value = "5", Text = "Bachelor's degree OR a three or more year program at a university, college, trade or technical school, or other institute.", Selected = level.ToString() == "5" },
                new SelectListItem { Value = "6", Text = "Two or more certificates, diplomas, or degrees. One must be for a program of three or more years.", Selected = level.ToString() == "6" },
                new SelectListItem { Value = "7", Text = "Master's degree, OR professional degree needed to practice in a licensed profession (For “professional degree,” the degree program must have been in: medicine, veterinary medicine, dentistry, optometry, law, chiropractic medicine, or pharmacy.).", Selected = level.ToString() == "7" },
                new SelectListItem { Value = "8", Text = "Doctoral level university degree (Ph.D.).", Selected = level.ToString() == "8" },
            };
        }
    }
}
