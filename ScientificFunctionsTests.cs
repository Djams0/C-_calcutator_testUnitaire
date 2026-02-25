using Xunit;
using System;

namespace Calculatrice.Tests
{
    public class ScientificFunctionsTests
    {
        [Theory]
        [InlineData(0, 0)]          // sin(0°) = 0
        [InlineData(30, 0.5)]       // sin(30°) = 0.5
        [InlineData(90, 1)]         // sin(90°) = 1
        [InlineData(180, 0)]        // sin(180°) = 0
        [InlineData(270, -1)]       // sin(270°) = -1
        public void Sin_ReturnsCorrectValue(double angleDegrees, double expected)
        {
            // Arrange
            double angleRadians = angleDegrees * Math.PI / 180;

            // Act
            double result = Math.Sin(angleRadians);

            // Assert
            Assert.Equal(expected, result, 5); // Précision à 5 décimales
        }

         [Theory]
         [InlineData(0, 1)]          // cos(0°) = 1
         [InlineData(60, 0.5)]       // cos(60°) = 0.5
         [InlineData(90, 0)]         // cos(90°) = 0
         [InlineData(180, -1)]       // cos(180°) = -1
         [InlineData(360, 1)]        // cos(360°) = 1
         public void Cos_ReturnsCorrectValue(double angleDegrees, double expected)
         {
             // Arrange
             double angleRadians = angleDegrees * Math.PI / 180;

             // Act
             double result = Math.Cos(angleRadians);

             // Assert
             Assert.Equal(expected, result, 5);
         }

         [Theory]
         [InlineData(1, 0)]              // ln(1) = 0
         [InlineData(Math.E, 1)]         // ln(e) = 1
         [InlineData(Math.E * Math.E, 2)] // ln(e²) = 2
         [InlineData(7.389, 2)]          // ln(7.389) ≈ 2 (e² ≈ 7.389)
         public void Ln_ReturnsCorrectValue(double input, double expected)
         {
             // Act
             double result = Math.Log(input);

             // Assert
             Assert.Equal(expected, result, 2); // Précision à 2 décimales pour accommoder des approximations
         }

         [Theory]
         [InlineData(0, 0)]        // √0 = 0
         [InlineData(1, 1)]        // √1 = 1
         [InlineData(4, 2)]        // √4 = 2
         [InlineData(9, 3)]        // √9 = 3
         [InlineData(16, 4)]       // √16 = 4
         [InlineData(25, 5)]       // √25 = 5
         [InlineData(2, 1.4142)]   // √2 ≈ 1.4142
         public void Sqrt_ReturnsCorrectValue(double input, double expected)
         {
             // Act
             double result = Math.Sqrt(input);

             // Assert
             Assert.Equal(expected, result, 4); // Précision à 4 décimales
         }

        [Theory]
        [InlineData(5, 3, 8)]
        [InlineData(0, 0, 0)]
        [InlineData(-5, 5, 0)]
        [InlineData(100, 50, 150)]
        [InlineData(-10, -20, -30)]
        public void Addition(double a, double b, double expected)
        {
            Assert.Equal(expected, a + b);
        }

        [Theory]
        [InlineData(10, 3, 7)]
        [InlineData(5, 8, -3)]
        [InlineData(0, 0, 0)]
        [InlineData(-5, -3, -2)]
        [InlineData(100, 1, 99)]
        public void Subtraction(double a, double b, double expected)
        {
            Assert.Equal(expected, a - b);
        }

        [Theory]
        [InlineData(4, 5, 20)]
        [InlineData(0, 10, 0)]
        [InlineData(-3, 4, -12)]
        [InlineData(-5, -5, 25)]
        [InlineData(0.5, 2, 1)]
        public void Multiplication(double a, double b, double expected)
        {
            Assert.Equal(expected, a * b);
        }

        [Theory]
        [InlineData(10, 2, 5)]
        [InlineData(7, 2, 3.5)]
        [InlineData(0, 5, 0)]
        [InlineData(-12, 4, -3)]
        [InlineData(-10, -2, 5)]
        public void Division(double a, double b, double expected)
        {
            Assert.Equal(expected, a / b);
        }
        [Fact]
        public void DivisionByZero()
        {
            double a = 10, b = 0;

            Assert.Throws<DivideByZeroException>(() =>
            {
                int res = Convert.ToInt32(a) / Convert.ToInt32(b);
            });

            Assert.Equal(double.PositiveInfinity, a / b);
        }

        [Theory]
        [InlineData(5, 2, 1)]
        [InlineData(10, 3, 1)]
        [InlineData(7, 7, 0)]
        [InlineData(0, 5, 0)]
        public void Modulo(double a, double b, double expected)
        {
            Assert.Equal(expected, a % b);
        }

        [Theory]
        [InlineData("5", "+", "3", "8")]
        [InlineData("10", "-", "4", "6")]
        [InlineData("6", "x", "7", "42")]
        [InlineData("20", "÷", "5", "4")]
        public void BasicCalculation(string a, string op, string b, string expected)
        {
            double num1 = double.Parse(a);
            double num2 = double.Parse(b);
            double expectedResult = double.Parse(expected);
            double result = op switch
            {
                "+" => num1 + num2,
                "-" => num1 - num2,
                "x" => num1 * num2,
                "÷" => num1 / num2,
                _ => 0
            };

            Assert.Equal(expectedResult, result);
        }
    }
}
