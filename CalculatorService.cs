using System;
using System.Threading.Tasks;

public class CalculatorService
{
    private readonly CalculatorRepository _calculatorRepository;

    public CalculatorService()
    {
        _calculatorRepository = new CalculatorRepository();
    }

    public async Task<double> AddAsync(double n1, double n2)
    {
        var result = n1 + n2;
        await _calculatorRepository.LogOperationAsync(n1, n2, "+", result);
        return result;
    }

    public async Task<double> SubtractAsync(double n1, double n2)
    {
        var result = n1 - n2;
        await _calculatorRepository.LogOperationAsync(n1, n2, "-", result);
        return result;
    }

    public async Task<double> MultiplyAsync(double n1, double n2)
    {
        var result = n1 * n2;
        await _calculatorRepository.LogOperationAsync(n1, n2, "*", result);
        return result;
    }

    public async Task<double> DivideAsync(double n1, double n2)
    {
        if (n2 == 0) throw new DivideByZeroException("Cannot divide by zero.");
        var result = n1 / n2;
        await _calculatorRepository.LogOperationAsync(n1, n2, "/", result);
        return result;
    }

    public async Task<List<CalculatorLog>> GetAllLogsAsync()
{
    return await _calculatorRepository.GetAllLogsAsync();
}
}
