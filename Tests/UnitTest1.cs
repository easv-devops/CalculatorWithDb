using Xunit;
using System;
using System.Threading.Tasks;

namespace Tests;

public class UnitTest1
{
    private readonly CalculatorService _calculatorService = new CalculatorService();

    [Fact]
    public async Task AddAsync_ReturnsCorrectSum()
    {
        // Arrange
        double num1 = 5;
        double num2 = 3;

        // Act
        var result = await _calculatorService.AddAsync(num1, num2);

        // Assert
        Assert.Equal(8, result);
    }

    [Fact]
    public async Task SubtractAsync_ReturnsCorrectDifference()
    {
        // Arrange
        double num1 = 5;
        double num2 = 3;

        // Act
        var result = await _calculatorService.SubtractAsync(num1, num2);

        // Assert
        Assert.Equal(2, result);
    }

    [Fact]
    public async Task MultiplyAsync_ReturnsCorrectProduct()
    {
        // Arrange
        double num1 = 5;
        double num2 = 3;

        // Act
        var result = await _calculatorService.MultiplyAsync(num1, num2);

        // Assert
        Assert.Equal(15, result);
    }

    [Fact]
    public async Task DivideAsync_ReturnsCorrectQuotient()
    {
        // Arrange
        double num1 = 6;
        double num2 = 3;

        // Act
        var result = await _calculatorService.DivideAsync(num1, num2);

        // Assert
        Assert.Equal(2, result);
    }

    [Fact]
    public async Task DivideAsync_ThrowsDivideByZeroException()
    {
        // Arrange
        double num1 = 5;
        double num2 = 0;

        // Act & Assert
        await Assert.ThrowsAsync<DivideByZeroException>(() => _calculatorService.DivideAsync(num1, num2));
    }
}
