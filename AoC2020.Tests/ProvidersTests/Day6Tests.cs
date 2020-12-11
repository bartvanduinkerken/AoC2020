using Xunit;

namespace AoC2020.Tests.ProvidersTests
{
    using Providers;
    public class Day6Tests
    {
        [Fact]
        public void When_stepA_executed_Returns_6249()
        {
            // Arrange
            var solver = new Day6Solver();

            // Act
            var result = solver.StepA();

            // Assert
            Assert.Equal(6249, result);
        }

        [Fact]
        public void When_stepB_executed_Returns_3103()
        {
            // Arrange
            var solver = new Day6Solver();

            // Act
            var result = solver.StepB();

            // Assert
            Assert.Equal(3103, result);
        }
    }
}
