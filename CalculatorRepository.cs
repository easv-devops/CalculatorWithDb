using System;
using System.Threading.Tasks;
using Npgsql;

public class CalculatorRepository
{
    string connectionString = Utilities.ProperlyFormattedConnectionString;
    public async Task<List<CalculatorLog>> GetAllLogsAsync()
{
    var logs = new List<CalculatorLog>();

    using (var connection = new NpgsqlConnection(connectionString))
    {
        await connection.OpenAsync();
        var command = new NpgsqlCommand("SELECT * FROM calculatorapp.calculator_logs", connection);

        using (var reader = await command.ExecuteReaderAsync())
        {
            while (await reader.ReadAsync())
            {
                logs.Add(new CalculatorLog
                {
                    Operand1 = reader.GetDouble(reader.GetOrdinal("Operand1")),
                    Operand2 = reader.GetDouble(reader.GetOrdinal("Operand2")),
                    Operation = reader.GetString(reader.GetOrdinal("Operation")),
                    Result = reader.GetDouble(reader.GetOrdinal("Result")),
                });
            }
        }
    }

    return logs;
}

    public async Task LogOperationAsync(double n1, double n2, string operation, double result)
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            await connection.OpenAsync();
            var command = new NpgsqlCommand("INSERT INTO calculatorapp.calculator_logs (Operand1, Operand2, Operation, Result) VALUES (@n1, @n2, @operation, @result)", connection);
            command.Parameters.AddWithValue("@n1", n1);
            command.Parameters.AddWithValue("@n2", n2);
            command.Parameters.AddWithValue("@operation", operation);
            command.Parameters.AddWithValue("@result", result);
            await command.ExecuteNonQueryAsync();
        }
    }
}
