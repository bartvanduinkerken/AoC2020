using Xunit;

namespace AoC2020.Tests.ProvidersTests
{
    using Providers;
    public class Day9Tests
    {
        [Fact]
        public void When_stepA_executed_Returns_18272118()
        {
            // Arrange
            var solver = new Day9Solver();

            // Act
            var result = solver.StepA();

            // Assert
            Assert.Equal(18272118, result);
        }

        [Fact]
        public void When_stepB_executed_Returns_2186361()
        {
            // Arrange
            var solver = new Day9Solver();

            // Act
            var result = solver.StepB();

            // Assert
            Assert.Equal(2186361, result);
        }
    }
}
