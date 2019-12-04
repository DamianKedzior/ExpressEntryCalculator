using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace ExpressEntryCalculator.Api.Models
{
    public class ApplicantDataViewModel
    {
        [Required]
        [DataType(DataType.Date)] // TODO:DK might not be needed
        public DateTime? BirthDate { get; set; }
        public bool SpouseExist { get; set; }

        [Required]
        public ushort EducationLevel { get; set; }

        public int? TypeOfFirstExam { get; set; }

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

        [Required]
        public ushort SpouseEducationLevel { get; set; }

        public int? TypeOfSpouseExam { get; set; }
        public double SpouseSpeakingPoints { get; set; }
        public double SpouseWritingPoints { get; set; }
        public double SpouseReadingPoints { get; set; }
        public double SpouseListeningPoints { get; set; }

        public int SpouseCanadianExperience { get; set; }

        public int ExperienceOutsideCanada { get; set; }

        public bool CanadianFamilyMember { get; set; }
        public int CanadianEducation { get; set; }
        public int CanadianArrangedEmployment { get; set; }
        public bool CanadianProvincialOrTerritorialNomination { get; set; }

        public ApplicantDataViewModel()
        {
            CanadianEducation = -1;
        }
    }
}
