using ExpressEntryCalculator.Core;
using Shouldly;
using TestStack.BDDfy;
using Xunit;

namespace ExpressEntryCalculator.AcceptanceTests
{
    public class AgePointsCalculatorTests
    {
        private const string GivenMyAgeIsTemplate = "Given my age is {0}";
        private const string ThenPointsShouldBeEqualToTemplate = "Then points should be equal to {0}";

        public int Age { get; set; }
        public int Points { get; set; }

        [Theory]
        [InlineData(17, 0)]
        [InlineData(18, 99)]
        [InlineData(19, 105)]
        [InlineData(20, 110)]
        [InlineData(29, 110)]
        [InlineData(30, 105)]
        [InlineData(31, 99)]
        [InlineData(32, 94)]
        [InlineData(33, 88)]
        [InlineData(34, 83)]
        [InlineData(35, 77)]
        [InlineData(36, 72)]
        [InlineData(37, 66)]
        [InlineData(38, 61)]
        [InlineData(39, 55)]
        [InlineData(40, 50)]
        [InlineData(41, 39)]
        [InlineData(42, 28)]
        [InlineData(43, 17)]
        [InlineData(44, 6)]
        [InlineData(45, 0)]
        public void HaveCorrectPointsForMyAge(int age, int expectedPoints)
        {
            this.Given(_ => _.GivenMyAgeIs(age), GivenMyAgeIsTemplate)
                .When(_ => _.WhenICalculateMyPointsForAge())
                .Then(_ => _.ThenPointsShouldBeEqualTo(expectedPoints), ThenPointsShouldBeEqualToTemplate)
                .BDDfy();
        }

        public void GivenMyAgeIs(int age)
        {
            Age = age;
        }

        public void WhenICalculateMyPointsForAge()
        {
            Points = AgePointsCalculator.CountPointsForAge(Age);
        }

        public void ThenPointsShouldBeEqualTo(int expectedPoints)
        {
            Points.ShouldBe(expectedPoints);
        }

    }
}
