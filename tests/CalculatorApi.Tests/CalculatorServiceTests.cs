using CalculatorApi.Services;

namespace CalculatorApi.Tests;

public class CalculatorServiceTests
{
    private readonly ICalculatorService _sut = new CalculatorService();

    // Add
    [Theory]
    [InlineData(2, 3, 5)]
    [InlineData(-1, 1, 0)]
    [InlineData(0, 0, 0)]
    [InlineData(1.5, 2.5, 4.0)]
    public void Add_ReturnsCorrectSum(double a, double b, double expected) =>
        Assert.Equal(expected, _sut.Add(a, b));

    // Subtract
    [Theory]
    [InlineData(10, 4, 6)]
    [InlineData(0, 5, -5)]
    [InlineData(-3, -2, -1)]
    [InlineData(1.5, 0.5, 1.0)]
    public void Subtract_ReturnsCorrectDifference(double a, double b, double expected) =>
        Assert.Equal(expected, _sut.Subtract(a, b));

    // Multiply
    [Theory]
    [InlineData(3, 4, 12)]
    [InlineData(-2, 5, -10)]
    [InlineData(0, 100, 0)]
    [InlineData(1.5, 2, 3.0)]
    public void Multiply_ReturnsCorrectProduct(double a, double b, double expected) =>
        Assert.Equal(expected, _sut.Multiply(a, b));

    // Divide — happy path
    [Theory]
    [InlineData(10, 2, 5)]
    [InlineData(-9, 3, -3)]
    [InlineData(1, 4, 0.25)]
    [InlineData(7.5, 2.5, 3.0)]
    public void Divide_ReturnsCorrectQuotient(double a, double b, double expected) =>
        Assert.Equal(expected, _sut.Divide(a, b), precision: 10);

    // Divide by zero
    [Fact]
    public void Divide_ByZero_ThrowsDivideByZeroException() =>
        Assert.Throws<DivideByZeroException>(() => _sut.Divide(5, 0));

    [Fact]
    public void Divide_ByZero_ExceptionMessageIsDescriptive()
    {
        var ex = Assert.Throws<DivideByZeroException>(() => _sut.Divide(5, 0));
        Assert.Contains("zero", ex.Message, StringComparison.OrdinalIgnoreCase);
    }
}
