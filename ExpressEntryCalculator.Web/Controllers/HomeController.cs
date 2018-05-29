using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ExpressEntryCalculator.Web.Models;
using ExpressEntryCalculator.Core;
using Microsoft.Extensions.Options;

namespace ExpressEntryCalculator.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ExpressEntryStats _expressEntryStats;

        public HomeController(IOptions<ExpressEntryStats> expressEntryStatsAccessor)
        {
            _expressEntryStats = expressEntryStatsAccessor.Value;
        }

        public IActionResult Index()
        {
            ApplicantDataViewModel model = new ApplicantDataViewModel();
            return View(model);
        }

        public IActionResult Summary(ApplicantDataViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", model);
            }

            // obliczenie punktow
            int age = AgeHelper.CountAge(model.BirthDate.Value);
            int pointForAge;
            if (model.SpouseExist == false)
            {
                pointForAge = AgePointsCalculator.CountPointsForAge(age);
            }
            else
            {
                pointForAge = AgePointsCalculator.CountPointsForAgeWithSpouse(age);
            }


            int pointForEducation;

            if (model.SpouseExist == false)
            {
                pointForEducation = EducationPointsCalculator.CountPointsForEducation(model.EducationLevel);
            }
            else
            {
                pointForEducation = EducationPointsCalculator.CountPointsForEducationWithSpouse(model.EducationLevel);
            }

            LanguagePoints primaryAplicantFirstLangPoints;

            if (model.TypeOfFirstExam.HasValue)
            {
                var firstExamType = LanguagePoints.IdentifyingTheTypeOfExam(model.TypeOfFirstExam.Value);
                primaryAplicantFirstLangPoints = new LanguagePoints(firstExamType, model.SpeakingPoints, model.WritingPoints, model.ReadingPoints, model.ListeningPoints);
            }
            else
            {
                primaryAplicantFirstLangPoints = new LanguagePoints();
            }

            int pointsForSpeaking;
            int pointsForWriting;
            int pointsForReading;
            int pointsForListening;
            int pointsForLanguage;
            if (model.SpouseExist == false)
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

            var secondExamType = LanguagePoints.IdentifyingTheTypeOfExam(model.TypeOfSecondExam);
            LanguagePoints primaryAplicantSecondLangPoints = new LanguagePoints(secondExamType, model.SpeakingPointsSecondLanguage, model.WritingPointsSecondLanguage, model.ReadingPointsSecondLanguage, model.ListeningPointsSecondLanguage);

            int pointsForSecondLangSpeaking;
            int pointsForSecondLangWriting;;
            int pointsForSecondLangReading;
            int pointsForSecondLangListening;
            int pointsForSecondLanguage;

            pointsForSecondLangSpeaking = SecondLanguagePointsCalculator.SecondLangPointsCalculator(primaryAplicantSecondLangPoints.CLBSpeakingPoints);
            pointsForSecondLangWriting = SecondLanguagePointsCalculator.SecondLangPointsCalculator(primaryAplicantSecondLangPoints.CLBWritingPoints);
            pointsForSecondLangReading = SecondLanguagePointsCalculator.SecondLangPointsCalculator(primaryAplicantSecondLangPoints.CLBReadingPoints);
            pointsForSecondLangListening = SecondLanguagePointsCalculator.SecondLangPointsCalculator(primaryAplicantSecondLangPoints.CLBListeningPoints);

            pointsForSecondLanguage = pointsForSecondLangSpeaking + pointsForSecondLangWriting + pointsForSecondLangReading + pointsForSecondLangListening;

            int pointsForExperience;
            if (model.SpouseExist == false)
            {
                pointsForExperience = ExperiencePointsCalculator.CountPointsForExperienceWithoutSpouse(model.CanadianExperience);
            }
            else
            {
                pointsForExperience = ExperiencePointsCalculator.CountPointsForExperienceWithSpouse(model.CanadianExperience);
            }

            int sectionA = pointForAge + pointForEducation + pointsForLanguage + pointsForSecondLanguage + pointsForExperience;

            int pointsForSpouseEducation;

            pointsForSpouseEducation = EducationPointsCalculator.CountPointsForSpouseEducation(model.SpouseEducationLevel);

            LanguagePoints spouseFirstLangPoints;

            if (model.TypeOfSpouseExam.HasValue)
            {
                var spouseExamType = LanguagePoints.IdentifyingTheTypeOfExam(model.TypeOfSpouseExam.Value);
                spouseFirstLangPoints = new LanguagePoints(spouseExamType, model.SpouseSpeakingPoints, model.SpouseWritingPoints, model.SpouseReadingPoints, model.SpouseListeningPoints);
            }
            else
            {
                spouseFirstLangPoints = new LanguagePoints();
            }
           
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

            int pointsForSpouseExperience;
            pointsForSpouseExperience = ExperiencePointsCalculator.CountPointsForSpouseExperience(model.SpouseCanadianExperience);

            int sectionB = pointsForSpouseEducation + pointsForSpouseLanguage + pointsForSpouseExperience;

            int sectionC;
            sectionC = SkillTransferabilityFactorsCalculator.CalculateSkillTransferabilityFactorsPoints(primaryAplicantFirstLangPoints, model.EducationLevel, model.CanadianExperience, model.ExperienceOutsideCanada);

            int sectionD;

            int canadianFamilyMemberPoints = AdditionalPointsCalculator.GiveAdditionalPoints(model.CanadianFamilyMember);
            int canadianEducationPoints = AdditionalPointsCalculator.CanadianEducationPoints(model.CanadianEducation);
            int canadianArrangedEmploymentPoints = AdditionalPointsCalculator.CalculatePointsForArrangementEmployment(model.CanadianArrangedEmployment);
            int canadianProvincialOrTerritorialNominationPoints = AdditionalPointsCalculator.GiveAdditionalPointsForProvincialOrTerritorialNomination(model.CanadianProvincialOrTerritorialNomination);
            int additionalLanguagePoints=0;
            if (primaryAplicantFirstLangPoints.LanguageExamType == LanguagePoints.LanguageExamTypes.TEF)
            {
                additionalLanguagePoints = AdditionalPointsCalculator.GiveAdditionalPointsForLanguages(primaryAplicantFirstLangPoints, primaryAplicantSecondLangPoints);
            }
            sectionD = canadianFamilyMemberPoints + canadianEducationPoints + canadianArrangedEmploymentPoints + canadianProvincialOrTerritorialNominationPoints + additionalLanguagePoints;


            int totalPointsForExpressEntry;
            totalPointsForExpressEntry = sectionA + sectionB + sectionC + sectionD;


            PointsSummaryViewModel points = new PointsSummaryViewModel();
            points.PointsForAge = pointForAge;
            points.PointsForEducation = pointForEducation;
            points.PointsForFirstLanguage = pointsForLanguage;
            points.PointsForSecondLanguage = pointsForSecondLanguage;
            points.PointsForCanadianExperience = pointsForExperience;
            points.PointsInSectionA = sectionA;

            points.PointsForSpouseEducation = pointsForSpouseEducation;
            points.PointsForSpouseLanguageExam = pointsForSpouseLanguage;
            points.PointsForSpouseCanadianExperience = pointsForSpouseExperience;
            points.PointsInSectionB = sectionB;

            points.PointsInSectionC = sectionC;
            
            points.PointsInSectionD = sectionD;

            points.TotalPointsForExpressEntry = totalPointsForExpressEntry;
            points.LastExpressEntryStats = _expressEntryStats;

            return View(points);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
