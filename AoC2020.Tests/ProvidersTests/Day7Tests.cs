using Xunit;

namespace AoC2020.Tests.ProvidersTests
{
    using Providers;
    public class Day7Tests
    {
        [Fact]
        public void When_stepA_executed_Returns_126()
        {
            // Arrange
            var solver = new Day7Solver();

            // Act
            var result = solver.StepA();

            // Assert
            Assert.Equal(126, result);
        }

        [Fact]
        public void When_stepB_executed_Returns_220149()
        {
            // Arrange
            var solver = new Day7Solver();

            // Act
            var result = solver.StepB();

            // Assert
            Assert.Equal(220149, result);
        }
    }
}
