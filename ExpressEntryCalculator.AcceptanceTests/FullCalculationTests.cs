using ExpressEntryCalculator.Web;
using ExpressEntryCalculator.Web.Controllers;
using ExpressEntryCalculator.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Options;
using Moq;
using Shouldly;
using System;
using TestStack.BDDfy;
using Xunit;

namespace ExpressEntryCalculator.AcceptanceTests
{
    // TODO:DK this class should test new Calculate function in ExpressEntryCalculator.Api
    // TODO:DK we need to mock current date so the test will always work; now when you run them in few months they may fail becuase points for age are different
    public class FullCalculationTests
    {
        public ApplicantDataViewModel ApplicantData { get; set; }
        public PointsSummaryViewModel PointsSummary { get; set; }
        public PointsSummaryViewModel ExpectedPointsSummary { get; set; }

        [Fact]
        public void HaveCorrectPoints()
        {
            this.Given("Given filled calculation form")
                .When(_ => _.WhenICalculateMyPoints())
                .Then(_ => _.ThenPointsShouldBeEqualTo(), "Then points should be equal to <ExpectedPointsSummary>")
                .WithExamples(new ExampleTable("ApplicantData", "ExpectedPointsSummary")
                {
                    {
                        ApplicantData = new ApplicantDataViewModel
                        {
                            BirthDate = new DateTime(1987, 8, 1),
                            SpouseExist = false,
                            EducationLevel = 7, // Master's
                            TypeOfFirstExam = 1, // IELTS
                            SpeakingPoints = 7.0,
                            ListeningPoints = 8.0,
                            ReadingPoints = 7.5,
                            WritingPoints = 6.5,
                            CanadianExperience = 0,
                            ExperienceOutsideCanada = 3
                        },
                        ExpectedPointsSummary = new PointsSummaryViewModel
                        {
                            PointsForAge = 94,
                            PointsForEducation = 135,
                            PointsForFirstLanguage = 116,
                            PointsInSectionA = 345,
                            PointsInSectionB = 0,
                            PointsInSectionC = 50,
                            PointsInSectionD = 0,
                            TotalPointsForExpressEntry = 395
                        }
                    },
                    {
                        ApplicantData = new ApplicantDataViewModel
                        {
                            BirthDate = new DateTime(1992, 8, 1),
                            SpouseExist = true,
                            EducationLevel = 5, // Bachelor's
                            TypeOfFirstExam = 1, // IELTS
                            SpeakingPoints = 6.5,
                            ListeningPoints = 8.0,
                            ReadingPoints = 6.5,
                            WritingPoints = 6.0,
                            CanadianExperience = 1,
                            ExperienceOutsideCanada = 2,
                            TypeOfSpouseExam = 1, // IELTS
                            SpouseSpeakingPoints = 5,
                            SpouseListeningPoints = 5,
                            SpouseReadingPoints = 5,
                            SpouseWritingPoints = 5,
                            SpouseEducationLevel = 2, // High School
                            SpouseCanadianExperience = 0,
                        },
                        ExpectedPointsSummary = new PointsSummaryViewModel
                        {
                            PointsForAge = 100,
                            PointsForEducation = 112,
                            PointsForFirstLanguage = 89,
                            PointsForCanadianExperience = 35,
                            PointsInSectionA = 336,
                            PointsForSpouseEducation = 2,
                            PointsForSpouseLanguageExam = 4,
                            PointsInSectionB = 6,
                            PointsInSectionC = 52,
                            PointsInSectionD = 0,
                            TotalPointsForExpressEntry = 394,
                        }
                    },
                    {
                        // state when spouse doesn't exist but spouse data has been filled
                        // can occur if user checks spouse existance, fill spouse data and then uncheck spouse existance
                        ApplicantData = new ApplicantDataViewModel
                        {
                            BirthDate = new DateTime(1987, 8, 1),
                            SpouseExist = false,
                            EducationLevel = 7, // Master's
                            TypeOfFirstExam = 1, // IELTS
                            SpeakingPoints = 7.0,
                            ListeningPoints = 8.0,
                            ReadingPoints = 7.5,
                            WritingPoints = 6.5,
                            CanadianExperience = 0,
                            ExperienceOutsideCanada = 3,
                            TypeOfSpouseExam = 1, // IELTS
                            SpouseSpeakingPoints = 5,
                            SpouseListeningPoints = 5,
                            SpouseReadingPoints = 5,
                            SpouseWritingPoints = 5,
                            SpouseEducationLevel = 7, // Master's
                            SpouseCanadianExperience = 3,
                        },
                        ExpectedPointsSummary = new PointsSummaryViewModel
                        {
                            PointsForAge = 94,
                            PointsForEducation = 135,
                            PointsForFirstLanguage = 116,
                            PointsInSectionA = 345,
                            PointsInSectionB = 0,
                            PointsInSectionC = 50,
                            PointsInSectionD = 0,
                            TotalPointsForExpressEntry = 395
                        }
                    },
                    {
                        ApplicantData = new ApplicantDataViewModel
                        {
                            BirthDate = new DateTime(1987, 8, 1),
                            SpouseExist = false,
                            EducationLevel = 7, // Master's
                            TypeOfFirstExam = 1, // IELTS
                            SpeakingPoints = 7.0,
                            ListeningPoints = 8.0,
                            ReadingPoints = 7.5,
                            WritingPoints = 6.5,
                            CanadianExperience = 0,
                            ExperienceOutsideCanada = 3,
                            CanadianProvincialOrTerritorialNomination = true,
                            CanadianFamilyMember = true
                        },
                        ExpectedPointsSummary = new PointsSummaryViewModel
                        {
                            PointsForAge = 94,
                            PointsForEducation = 135,
                            PointsForFirstLanguage = 116,
                            PointsInSectionA = 345,
                            PointsInSectionB = 0,
                            PointsInSectionC = 50,
                            PointsInSectionD = 615,
                            TotalPointsForExpressEntry = 1010
                        }
                    },
                    {
                        ApplicantData = new ApplicantDataViewModel
                        {
                            BirthDate = new DateTime(1987, 8, 1),
                            SpouseExist = false,
                            EducationLevel = 7, // Master's
                            TypeOfFirstExam = 1, // IELTS
                            SpeakingPoints = 7.0,
                            ListeningPoints = 8.0,
                            ReadingPoints = 7.5,
                            WritingPoints = 6.5,
                            CanadianExperience = 0,
                            ExperienceOutsideCanada = 3,
                            CanadianProvincialOrTerritorialNomination = true,
                            CanadianFamilyMember = true,
                            CanadianArrangedEmployment = 1
                        },
                        ExpectedPointsSummary = new PointsSummaryViewModel
                        {
                            PointsForAge = 94,
                            PointsForEducation = 135,
                            PointsForFirstLanguage = 116,
                            PointsInSectionA = 345,
                            PointsInSectionB = 0,
                            PointsInSectionC = 50,
                            PointsInSectionD = 815,
                            TotalPointsForExpressEntry = 1210
                        }
                    },
                    {
                        ApplicantData = new ApplicantDataViewModel
                        {
                            BirthDate = new DateTime(1987, 8, 1),
                            SpouseExist = false,
                            EducationLevel = 7, // Master's
                            TypeOfFirstExam = 1, // IELTS
                            SpeakingPoints = 7.0,
                            ListeningPoints = 8.0,
                            ReadingPoints = 7.5,
                            WritingPoints = 6.5,
                            CanadianEducation = 3,
                            CanadianExperience = 0,
                            ExperienceOutsideCanada = 3,
                            CanadianProvincialOrTerritorialNomination = true,
                            CanadianFamilyMember = true,
                            CanadianArrangedEmployment = 1
                        },
                        ExpectedPointsSummary = new PointsSummaryViewModel
                        {
                            PointsForAge = 94,
                            PointsForEducation = 135,
                            PointsForFirstLanguage = 116,
                            PointsInSectionA = 345,
                            PointsInSectionB = 0,
                            PointsInSectionC = 50,
                            PointsInSectionD = 845,
                            TotalPointsForExpressEntry = 1240
                        }
                    }
                })
                .BDDfy();
        }

        private void WhenICalculateMyPoints()
        {
            var controller = new HomeController(Options.Create(new ExpressEntryStats()))
            {
                TempData = new Mock<ITempDataDictionary>().Object
            };

            var response = controller.Summary(ApplicantData) as ViewResult;
            PointsSummary = response.ViewData.Model as PointsSummaryViewModel;
        }

        private void ThenPointsShouldBeEqualTo()
        {
            PointsSummary.PointsForAge.ShouldBe(ExpectedPointsSummary.PointsForAge);
            PointsSummary.PointsForCanadianExperience.ShouldBe(ExpectedPointsSummary.PointsForCanadianExperience);
            PointsSummary.PointsForEducation.ShouldBe(ExpectedPointsSummary.PointsForEducation);
            PointsSummary.PointsForFirstLanguage.ShouldBe(ExpectedPointsSummary.PointsForFirstLanguage);
            PointsSummary.PointsForSecondLanguage.ShouldBe(ExpectedPointsSummary.PointsForSecondLanguage);
            PointsSummary.PointsForSpouseCanadianExperience.ShouldBe(ExpectedPointsSummary.PointsForSpouseCanadianExperience);
            PointsSummary.PointsForSpouseEducation.ShouldBe(ExpectedPointsSummary.PointsForSpouseEducation);
            PointsSummary.PointsForSpouseLanguageExam.ShouldBe(ExpectedPointsSummary.PointsForSpouseLanguageExam);
            PointsSummary.PointsInSectionA.ShouldBe(ExpectedPointsSummary.PointsInSectionA);
            PointsSummary.PointsInSectionB.ShouldBe(ExpectedPointsSummary.PointsInSectionB);
            PointsSummary.PointsInSectionC.ShouldBe(ExpectedPointsSummary.PointsInSectionC);
            PointsSummary.PointsInSectionD.ShouldBe(ExpectedPointsSummary.PointsInSectionD);
            PointsSummary.TotalPointsForExpressEntry.ShouldBe(ExpectedPointsSummary.TotalPointsForExpressEntry);
        }
    }
}
