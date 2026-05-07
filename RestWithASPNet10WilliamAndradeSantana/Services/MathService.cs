namespace RestWithASPNet10WilliamAndradeSantana.Services;

public class MathService
{
    public decimal Calculate(string operation, decimal first, decimal second)
    {
        return operation.ToLowerInvariant() switch
        {
            "+" or "sum" => first + second,
            "-" or "subtract" => first - second,
            "*" or "multiply" => first * second,
            "divide" or "division" => second == 0 ? throw new DivideByZeroException() : first / second,
            "sqrt" or "√" => first < 0 ? 
                throw new InvalidOperationException("Raiz quadrada de número negativo não é suportada.") : 
                (decimal)Math.Sqrt((double)first),
            
            _ => throw new InvalidOperationException($"Operação '{operation}' não é suportada.")
        };
    }
}