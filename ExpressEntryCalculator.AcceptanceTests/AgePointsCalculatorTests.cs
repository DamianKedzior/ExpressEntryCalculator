using ExpressEntryCalculator.Core;
using Shouldly;
using TestStack.BDDfy;
using Xunit;

namespace ExpressEntryCalculator.AcceptanceTests
{
    public class AgePointsCalculatorTests
    {
        public int Age { get; set; }
        public int Points { get; set; }
        public int ExpectedPoints { get; set; }

        [Fact]
        public void HaveCorrectPointsForMyAge()
        {
            this.Given("Given my age is <Age>")
                .When(_ => _.WhenICalculateMyPointsForAge())
                .Then(_ => _.ThenPointsShouldBeEqualTo(), "Then points should be equal to <ExpectedPoints>")
                .WithExamples(new ExampleTable("Age", "ExpectedPoints")
                {
                    { 17, 0 },
                    { 18, 99 },
                    { 19, 105 },
                    { 20, 110 },
                    { 29, 110 },
                    { 30, 105 },
                    { 31, 99 },
                    { 32, 94 },
                    { 33, 88 },
                    { 34, 83 },
                    { 35, 77 },
                    { 36, 72 },
                    { 37, 66 },
                    { 38, 61 },
                    { 39, 55 },
                    { 40, 50 },
                    { 41, 39 },
                    { 42, 28 },
                    { 43, 17 },
                    { 44, 6 },
                    { 45, 0 }
                })
                .BDDfy();
        }

        private void WhenICalculateMyPointsForAge()
        {
            Points = AgePointsCalculator.CountPointsForAge(Age);
        }

        private void ThenPointsShouldBeEqualTo()
        {
            Points.ShouldBe(ExpectedPoints);
        }
    }
}
