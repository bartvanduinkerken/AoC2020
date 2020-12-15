using Xunit;

namespace AoC2020.Tests.ProvidersTests
{
    using Providers;
    public class Day8Tests
    {
        [Fact]
        public void When_stepA_executed_Returns_1749()
        {
            // Arrange
            var solver = new Day8Solver();

            // Act
            var result = solver.StepA();

            // Assert
            Assert.Equal(1749, result);
        }

        [Fact]
        public void When_stepB_executed_Returns_515()
        {
            // Arrange
            var solver = new Day8Solver();

            // Act
            var result = solver.StepB();

            // Assert
            Assert.Equal(515, result);
        }
    }
}
