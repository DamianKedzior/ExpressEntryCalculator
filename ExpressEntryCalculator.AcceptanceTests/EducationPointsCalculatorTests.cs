using ExpressEntryCalculator.Core;
using Shouldly;
using TestStack.BDDfy;
using Xunit;

namespace ExpressEntryCalculator.AcceptanceTests
{
    public class EducationPointsCalculatorTestsWithoutSpouse : EducationPointsCalculatorTests
    {
        [Fact]
        public void HaveCorrectPointsForMyEducation()
        {
            this.Given("Given my education level is <EducationLevel>")
                .When(_ => _.WhenICalculateMyPointsForEducation())
                .Then(_ => _.ThenPointsShouldBeEqualTo(), "Then points should be equal to <ExpectedPoints>")
                .WithExamples(new ExampleTable("EducationLevel", "ExpectedPoints")
                {
                    { EducationLevels.LessThanSecondarySchool, 0 },
                    { EducationLevels.SecondaryDiplomaHighSchoolGraduation, 30 },
                    { EducationLevels.OneYearDegreeFromAUniversity, 90 },
                    { EducationLevels.TwoYearProgramAtAUniversity, 98 },
                    { EducationLevels.BachelorsDegree, 120 },
                    { EducationLevels.TwoOrMoreDiplomasOrDegrees, 128 },
                    { EducationLevels.MastersDegree, 135 },
                    { EducationLevels.DoctoralDegree, 150 },
                })
                .BDDfy();
        }

        private void WhenICalculateMyPointsForEducation()
        {
            Points = EducationPointsCalculator.CountPointsForEducation(EducationLevel);
        }
    }

    public class EducationPointsCalculatorTestsWithSpouse : EducationPointsCalculatorTests
    {
        [Fact]
        public void HaveCorrectPointsForMyEducation()
        {
            this.Given("Given my education level is <EducationLevel>")
                    .And("and I apply with my spouse")
                .When(_ => _.WhenICalculateMyPointsForEducation())
                .Then(_ => _.ThenPointsShouldBeEqualTo(), "Then points should be equal to <ExpectedPoints>")
                .WithExamples(new ExampleTable("EducationLevel", "ExpectedPoints")
                {
                    { EducationLevels.LessThanSecondarySchool, 0 },
                    { EducationLevels.SecondaryDiplomaHighSchoolGraduation, 28 },
                    { EducationLevels.OneYearDegreeFromAUniversity, 84 },
                    { EducationLevels.TwoYearProgramAtAUniversity, 91 },
                    { EducationLevels.BachelorsDegree, 112 },
                    { EducationLevels.TwoOrMoreDiplomasOrDegrees, 119 },
                    { EducationLevels.MastersDegree, 126 },
                    { EducationLevels.DoctoralDegree, 140 },
                })
                .BDDfy();
        }

        private void WhenICalculateMyPointsForEducation()
        {
            Points = EducationPointsCalculator.CountPointsForEducationWithSpouse(EducationLevel);
        }
    }

    public abstract class EducationPointsCalculatorTests
    {
        public ushort EducationLevel { get; set; }
        public int Points { get; set; }
        public int ExpectedPoints { get; set; }

        public enum EducationLevels
        {
            LessThanSecondarySchool = 1,
            SecondaryDiplomaHighSchoolGraduation,
            OneYearDegreeFromAUniversity,
            TwoYearProgramAtAUniversity,
            BachelorsDegree,
            TwoOrMoreDiplomasOrDegrees,
            MastersDegree,
            DoctoralDegree
        }

        protected void ThenPointsShouldBeEqualTo()
        {
            Points.ShouldBe(ExpectedPoints);
        }
    }
}
