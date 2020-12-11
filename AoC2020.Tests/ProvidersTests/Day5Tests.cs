using Xunit;

namespace AoC2020.Tests.ProvidersTests
{
    using Providers;
    public class Day5Tests
    {
        [Fact]
        public void When_stepA_executed_Returns_987()
        {
            // Arrange
            var solver = new Day5Solver();

            // Act
            var result = solver.StepA();

            // Assert
            Assert.Equal(987, result);
        }

        [Fact]
        public void When_stepB_executed_Returns_603()
        {
            // Arrange
            var solver = new Day5Solver ();

            // Act
            var result = solver.StepB();

            // Assert
            Assert.Equal(603, result);
        }
    }
}
