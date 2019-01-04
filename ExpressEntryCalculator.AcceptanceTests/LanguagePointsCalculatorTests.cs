using ExpressEntryCalculator.Core;
using Shouldly;
using TestStack.BDDfy;
using Xunit;

namespace ExpressEntryCalculator.AcceptanceTests
{
    public class LanguagePointsCalculatorTestsWithoutSpouse : LanguagePointsCalculatorTests
    {
        [Fact]
        public void HaveCorrectPointsForMyLanguageExam()
        {
            this.Given("Given I took <LanguageExam>")
                    .And("and I scored <SpeakingPoints> for speaking")
                    .And("and I scored <WritingPoints> for writing")
                    .And("and I scored <ReadingPoints> for reading")
                    .And("and I scored <ListeningPoints> for listening")
                .When(_ => _.WhenICalculateMyPointsForLanguageSkills())
                .Then(_ => _.ThenPointsForSpeakingShouldBeEqualTo(), "Then points for speaking should be equal to <ExpectedPointsForSpeaking>")
                    .And(_ => _.AndPointsForWritingShouldBeEqualTo(), "and points for writing should be equal to <ExpectedPointsForWriting>")
                    .And(_ => _.AndPointsForReadingShouldBeEqualTo(), "and points for reading should be equal to <ExpectedPointsForReading>")
                    .And(_ => _.AndPointsForListeningShouldBeEqualTo(), "and points for listening should be equal to <ExpectedPointsForListening>")
                .WithExamples(new ExampleTable("LanguageExam", 
                    "SpeakingPoints",
                    "WritingPoints",
                    "ReadingPoints",
                    "ListeningPoints",
                    "ExpectedPointsForSpeaking",
                    "ExpectedPointsForWriting",
                    "ExpectedPointsForReading",
                    "ExpectedPointsForListening")
                {
                    { LanguagePoints.LanguageExamTypes.IELTS, 1, 1, 1, 1, 0, 0, 0, 0 },
                    { LanguagePoints.LanguageExamTypes.IELTS, 3.5, 3.5, 3, 4, 0, 0, 0, 0 },
                    { LanguagePoints.LanguageExamTypes.IELTS, 4, 4, 3.5, 4.5, 6, 6, 6, 6 },
                    { LanguagePoints.LanguageExamTypes.IELTS, 5, 5, 4.5, 5, 6, 6, 6, 6 },
                    { LanguagePoints.LanguageExamTypes.IELTS, 5.5, 5.5, 5, 5.5, 9, 9, 9, 9 },
                    { LanguagePoints.LanguageExamTypes.IELTS, 5.5, 5.5, 5.5, 5.5, 9, 9, 9, 9 },
                    { LanguagePoints.LanguageExamTypes.IELTS, 6, 6, 6, 6, 17, 17, 17, 17 },
                    { LanguagePoints.LanguageExamTypes.IELTS, 6, 6, 6, 7, 17, 17, 17, 17 },
                    { LanguagePoints.LanguageExamTypes.IELTS, 6.5, 6.5, 6.5, 7.5, 23, 23, 23, 23 },
                    { LanguagePoints.LanguageExamTypes.IELTS, 7, 7, 7, 8, 31, 31, 31, 31 },
                    { LanguagePoints.LanguageExamTypes.IELTS, 7, 7, 7.5, 8, 31, 31, 31, 31 },
                    { LanguagePoints.LanguageExamTypes.IELTS, 7.5, 7.5, 8, 8.5, 34, 34, 34, 34 },
                    { LanguagePoints.LanguageExamTypes.IELTS, 9, 9, 9, 9, 34, 34, 34, 34 },

                })
                .BDDfy();
        }

        private void WhenICalculateMyPointsForLanguageSkills()
        {
            var points = new LanguagePoints(LanguageExam, SpeakingPoints, WritingPoints, ReadingPoints, ListeningPoints);

            PointsForSpeaking = LanguagePointsCalculator.LanguagePointsCalculatorWithoutSpouse(points.CLBSpeakingPoints);
            PointsForWriting = LanguagePointsCalculator.LanguagePointsCalculatorWithoutSpouse(points.CLBWritingPoints);
            PointsForReading = LanguagePointsCalculator.LanguagePointsCalculatorWithoutSpouse(points.CLBReadingPoints);
            PointsForListening = LanguagePointsCalculator.LanguagePointsCalculatorWithoutSpouse(points.CLBListeningPoints);
        }
    }

    public class LanguagePointsCalculatorTestsWithSpouse : LanguagePointsCalculatorTests
    {
        [Fact]
        public void HaveCorrectPointsForMyLanguageExam()
        {
            this.Given("Given I took <LanguageExam>")
                    .And("and I apply with my spouse")
                    .And("and I scored <SpeakingPoints> for speaking")
                    .And("and I scored <WritingPoints> for writing")
                    .And("and I scored <ReadingPoints> for reading")
                    .And("and I scored <ListeningPoints> for listening")
                .When(_ => _.WhenICalculateMyPointsForLanguageSkills())
                .Then(_ => _.ThenPointsForSpeakingShouldBeEqualTo(), "Then points for speaking should be equal to <ExpectedPointsForSpeaking>")
                    .And(_ => _.AndPointsForWritingShouldBeEqualTo(), "and points for writing should be equal to <ExpectedPointsForWriting>")
                    .And(_ => _.AndPointsForReadingShouldBeEqualTo(), "and points for reading should be equal to <ExpectedPointsForReading>")
                    .And(_ => _.AndPointsForListeningShouldBeEqualTo(), "and points for listening should be equal to <ExpectedPointsForListening>")
                .WithExamples(new ExampleTable("LanguageExam",
                    "SpeakingPoints",
                    "WritingPoints",
                    "ReadingPoints",
                    "ListeningPoints",
                    "ExpectedPointsForSpeaking",
                    "ExpectedPointsForWriting",
                    "ExpectedPointsForReading",
                    "ExpectedPointsForListening")
                {
                    { LanguagePoints.LanguageExamTypes.IELTS, 1, 1, 1, 1, 0, 0, 0, 0 },
                    { LanguagePoints.LanguageExamTypes.IELTS, 3.5, 3.5, 3, 4, 0, 0, 0, 0 },
                    { LanguagePoints.LanguageExamTypes.IELTS, 4, 4, 3.5, 4.5, 6, 6, 6, 6 },
                    { LanguagePoints.LanguageExamTypes.IELTS, 5, 5, 4.5, 5, 6, 6, 6, 6 },
                    { LanguagePoints.LanguageExamTypes.IELTS, 5.5, 5.5, 5, 5.5, 8, 8, 8, 8 },
                    { LanguagePoints.LanguageExamTypes.IELTS, 5.5, 5.5, 5.5, 5.5, 8, 8, 8, 8 },
                    { LanguagePoints.LanguageExamTypes.IELTS, 6, 6, 6, 6, 16, 16, 16, 16 },
                    { LanguagePoints.LanguageExamTypes.IELTS, 6, 6, 6, 7, 16, 16, 16, 16 },
                    { LanguagePoints.LanguageExamTypes.IELTS, 6.5, 6.5, 6.5, 7.5, 22, 22, 22, 22 },
                    { LanguagePoints.LanguageExamTypes.IELTS, 7, 7, 7, 8, 29, 29, 29, 29 },
                    { LanguagePoints.LanguageExamTypes.IELTS, 7, 7, 7.5, 8, 29, 29, 29, 29 },
                    { LanguagePoints.LanguageExamTypes.IELTS, 7.5, 7.5, 8, 8.5, 32, 32, 32, 32 },
                    { LanguagePoints.LanguageExamTypes.IELTS, 9, 9, 9, 9, 32, 32, 32, 32 },

                })
                .BDDfy();
        }

        private void WhenICalculateMyPointsForLanguageSkills()
        {
            var points = new LanguagePoints(LanguageExam, SpeakingPoints, WritingPoints, ReadingPoints, ListeningPoints);

            PointsForSpeaking = LanguagePointsCalculator.LanguagePointsCalculatorWithSpouse(points.CLBSpeakingPoints);
            PointsForWriting = LanguagePointsCalculator.LanguagePointsCalculatorWithSpouse(points.CLBWritingPoints);
            PointsForReading = LanguagePointsCalculator.LanguagePointsCalculatorWithSpouse(points.CLBReadingPoints);
            PointsForListening = LanguagePointsCalculator.LanguagePointsCalculatorWithSpouse(points.CLBListeningPoints);
        }
    }

    public abstract class LanguagePointsCalculatorTests
    {
        public LanguagePoints.LanguageExamTypes LanguageExam { get; set; }
        public double SpeakingPoints { get; set; }
        public double WritingPoints { get; set; }
        public double ReadingPoints { get; set; }
        public double ListeningPoints { get; set; }

        public int PointsForSpeaking { get; set; }
        public int PointsForWriting { get; set; }
        public int PointsForReading { get; set; }
        public int PointsForListening { get; set; }

        public int ExpectedPointsForSpeaking { get; set; }
        public int ExpectedPointsForWriting { get; set; }
        public int ExpectedPointsForReading { get; set; }
        public int ExpectedPointsForListening { get; set; }

        protected void ThenPointsForSpeakingShouldBeEqualTo()
        {
            PointsForSpeaking.ShouldBe(ExpectedPointsForSpeaking);
        }

        protected void AndPointsForWritingShouldBeEqualTo()
        {
            PointsForWriting.ShouldBe(ExpectedPointsForWriting);
        }

        protected void AndPointsForReadingShouldBeEqualTo()
        {
            PointsForReading.ShouldBe(ExpectedPointsForReading);
        }

        protected void AndPointsForListeningShouldBeEqualTo()
        {
            PointsForListening.ShouldBe(ExpectedPointsForListening);
        }
    }
}
