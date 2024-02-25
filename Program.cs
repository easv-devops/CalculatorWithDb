using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

internal class Program
{
    
    private static async Task Main(string[] args)
    {
        Console.WriteLine("Attempting connection with: " + Environment.GetEnvironmentVariable("pgconn")!);
        Console.WriteLine("WELCOME TO THE CALCULATOR APP");
        var calculator = new CalculatorService();
        bool running = true;

        while (running)
        {
            Console.WriteLine("Press Enter to start the program, enter 'exit' to quit, or enter 'logs' to view all logs.");
            string? input = Console.ReadLine();

            if (input == "exit")
            {
                running = false;
                continue;
            }
            else if (input == "logs")
{
    var logs = await calculator.GetAllLogsAsync();
    foreach (var log in logs)
    {
        Console.WriteLine($"Operation: {log.Operation}, Operand1: {log.Operand1}, Operand2: {log.Operand2}, Result: {log.Result}");
    }
    continue;
}

            Console.WriteLine("Enter the first number: ");
            double num1 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter the second number: ");
            double num2 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter the operation (+, -, *, /): ");
            string? operation = Console.ReadLine();

            try
            {
                switch (operation)
                {
                    case "+":
                        var addResult = await calculator.AddAsync(num1, num2);
                        Console.WriteLine($"The result is: {addResult}");
                        break;
                    case "-":
                        var subtractResult = await calculator.SubtractAsync(num1, num2);
                        Console.WriteLine($"The result is: {subtractResult}");
                        break;
                    case "*":
                        var multiplyResult = await calculator.MultiplyAsync(num1, num2);
                        Console.WriteLine($"The result is: {multiplyResult}");
                        break;
                    case "/":
                        if (num2 != 0)
                        {
                            var divideResult = await calculator.DivideAsync(num1, num2);
                            Console.WriteLine($"The result is: {divideResult}");
                        }
                        else
                        {
                            Console.WriteLine("Cannot divide by zero.");
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid operation");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            Console.WriteLine("-----------------------------");
        }
    }
}
