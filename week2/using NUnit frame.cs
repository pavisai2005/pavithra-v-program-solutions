using NUnit.Framework;
using Moq;

namespace Assignment_05_NUnitMoq
{
    [TestFixture]
    public class TaxCalculatorTests
    {
        [Test]
        public void CalculateTax_ReturnsExpectedTax()
        {
            // Arrange
            var mockService = new Mock<ICalculatorService>();
            mockService.Setup(s => s.Multiply(1000, 10)).Returns(100);

            var calculator = new TaxCalculator(mockService.Object);

            // Act
            var result = calculator.CalculateTax(1000);

            // Assert
            Assert.AreEqual(100, result);
        }
    }
}