using System;
using System.Collections.Generic;
using Xunit;
using QuadEquations;

namespace QuadEquations.Tests
{
    public class QuadEquationsTests
    {

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(double.NaN, 0, 0)]
        public void Coefficient_at_first_term_of_equatios_is_zero_or_nan_exception(double a, double b, double c)
        {

            // Arrange + Assert
            Assert.Throws<CoefficientAtFirstTermOfEquatiosIsZeroOrNaN>( () => new QuadEquations(a, b, c));

        }

        [Fact]
        public void Checking_solution()
        {
            // Arrange
            var QE = new QuadEquations(2, -3, -2);

            // Act + Assert
            Assert.Equal(2, QE.X1);
            Assert.Equal(-0.5, QE.X2);
        }

        [Theory]
        [InlineData(2, -3, -2, 2)]
        [InlineData(1, 4, 4, 1)]
        [InlineData(1, 6, 45, 0)]
        public void Checking_number_of_roots(double a, double b, double c, int rootCount)
        {
            // Arrange
            var QE = new QuadEquations(a, b, c);

            // Act + Assert
            Assert.Equal(rootCount, QE.RootCount);
        }

        [Fact]
        public void Array_data_entry()
        {
            // Arrange
            var term = new double[3] { 2, -3, -2 };
            var exception = Record.Exception( () => new QuadEquations(term));

            // Act + Assert
            Assert.Null(exception);
        }

        [Fact]
        public void Wrong_mumber_of_term()
        {
            // Arrange
            var terms1 = new double[] { 4, 5, 3, 2};
            var terms2 = new double[] { -3, 1 };
            var terms3 = new double[] { 5 };

            // Act + Assert
            Assert.Throws<WrongNumberOfTerm>( () => new QuadEquations(terms1));
            Assert.Throws<WrongNumberOfTerm>( () => new QuadEquations(terms2));
            Assert.Throws<WrongNumberOfTerm>( () => new QuadEquations(terms3));
        }

        [Fact]
        public void Coefficient_at_first_term_of_equatios_is_zero_or_nan_exception_when_entering_an_array()
        {
            // Arrange
            var terms = new double[] { 0, 3, 2 };

            // Act + Assert
            Assert.Throws<CoefficientAtFirstTermOfEquatiosIsZeroOrNaN>( () => new QuadEquations(terms));
        }
    }
}
