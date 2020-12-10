using Xunit;

namespace AoC2020.Tests.ProvidersTests
{
    using Providers;
    public class Day1Tests
    {
        [Fact]
        public void When_stepA_executed_Returns_988771()
        {
            // Arrange
            var solver = new Day1Solver();

            // Act
            var result = solver.StepA();

            // Assert
            Assert.Equal(988771, result);
        }

        [Fact]
        public void When_stepB_executed_Returns_171933104()
        {
            // Arrange
            var solver = new Day1Solver();

            // Act
            var result = solver.StepB();

            // Assert
            Assert.Equal(171933104, result);
        }
    }
}
