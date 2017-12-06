using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ExpressEntryCalculator.Web.Models;
using ExpressEntryCalculator.Core;

namespace ExpressEntryCalculator.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ApplicantDataViewModel model = new ApplicantDataViewModel();
            return View(model);
        }

        public IActionResult Summary(ApplicantDataViewModel model)
        {

            // obliczenie punktow
            int age = AgeHelper.CountAge(model.BirthDate);
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

            var firstExamType = LanguagePoints.IdentifyingTheTypeOfExam(model.TypeOfFirstExam); 
            LanguagePoints primaryAplicantFirstLangPoints = new LanguagePoints(firstExamType, model.SpeakingPoints, model.WritingPoints, model.ReadingPoints, model.ListeningPoints);

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

            PointsSummaryViewModel points = new PointsSummaryViewModel();
            points.PointsForAge = pointForAge;
            points.PointsForEducation = pointForEducation;
            points.PointsForFirstLanguage = pointsForLanguage;
            return View(points);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
