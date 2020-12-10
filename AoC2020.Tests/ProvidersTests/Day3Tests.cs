using Xunit;

namespace AoC2020.Tests.ProvidersTests
{
    using Providers;
    public class Day3Tests
    {
        [Fact]
        public void When_stepA_executed_Returns_220()
        {
            // Arrange
            var solver = new Day3Solver();

            // Act
            var result = solver.StepA();

            // Assert
            Assert.Equal(220, result);
        }

        [Fact]
        public void When_stepB_executed_Returns_2138320800()
        {
            // Arrange
            var solver = new Day3Solver();

            // Act
            var result = solver.StepB();

            // Assert
            Assert.Equal(2138320800, result);
        }
    }
}
