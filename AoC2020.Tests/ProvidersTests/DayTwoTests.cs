using Xunit;

namespace AoC2020.Tests.ProvidersTests
{
    using Providers;
    public class DayTwoTests
    {
        [Fact]
        public void When_stepA_executed_Returns_560()
        {
            // Arrange
            var solver = new DayTwoSolver();

            // Act
            var result = solver.StepA();

            // Assert
            Assert.Equal(560, result);
        }

        [Fact]
        public void When_stepB_executed_Returns_303()
        {
            // Arrange
            var solver = new DayTwoSolver();

            // Act
            var result = solver.StepB();

            // Assert
            Assert.Equal(303, result);
        }
    }
}
