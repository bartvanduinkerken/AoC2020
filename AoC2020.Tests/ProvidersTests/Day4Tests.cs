using Xunit;

namespace AoC2020.Tests.ProvidersTests
{
    using Providers;
    public class Day4Tests
    {
        [Fact]
        public void When_stepA_executed_Returns_264()
        {
            // Arrange
            var solver = new Day4Solver();

            // Act
            var result = solver.StepA();

            // Assert
            Assert.Equal(264, result);
        }

        [Fact]
        public void When_stepB_executed_Returns_224()
        {
            // Arrange
            var solver = new Day4Solver ();

            // Act
            var result = solver.StepB();

            // 224
            Assert.Equal(224, result);
        }
    }
}
