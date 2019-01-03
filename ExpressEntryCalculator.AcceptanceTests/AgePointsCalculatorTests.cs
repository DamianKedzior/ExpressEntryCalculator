using ExpressEntryCalculator.Core;
using Shouldly;
using TestStack.BDDfy;
using Xunit;

namespace ExpressEntryCalculator.AcceptanceTests
{
    public class AgePointsCalculatorTestsWithoutSpouse : AgePointsCalculatorTests
    {
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
    }

    public class AgePointsCalculatorTestsWithSpouse : AgePointsCalculatorTests
    {
        [Fact]
        public void HaveCorrectPointsForMyAge()
        {
            this.Given("Given my age is <Age>")
                    .And("and I apply with my spouse")
                .When(_ => _.WhenICalculateMyPointsForAge())
                .Then(_ => _.ThenPointsShouldBeEqualTo(), "Then points should be equal to <ExpectedPoints>")
                .WithExamples(new ExampleTable("Age", "ExpectedPoints")
                {
                        { 17, 0 },
                        { 18, 90 },
                        { 19, 95 },
                        { 20, 100 },
                        { 29, 100 },
                        { 30, 95 },
                        { 31, 90 },
                        { 32, 85 },
                        { 33, 80 },
                        { 34, 75 },
                        { 35, 70 },
                        { 36, 65 },
                        { 37, 60 },
                        { 38, 55 },
                        { 39, 50 },
                        { 40, 45 },
                        { 41, 35 },
                        { 42, 25 },
                        { 43, 15 },
                        { 44, 5 },
                        { 45, 0 }
                })
                .BDDfy();
        }

        private void WhenICalculateMyPointsForAge()
        {
            Points = AgePointsCalculator.CountPointsForAgeWithSpouse(Age);
        }
    }

    public class AgePointsCalculatorTests
    {
        public int Age { get; set; }
        public int Points { get; set; }
        public int ExpectedPoints { get; set; }

        protected void ThenPointsShouldBeEqualTo()
        {
            Points.ShouldBe(ExpectedPoints);
        }
    }
}
