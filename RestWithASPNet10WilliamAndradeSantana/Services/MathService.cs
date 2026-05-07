namespace RestWithASPNet10WilliamAndradeSantana.Services;
public class MathService
{
    public decimal Calculator(string operation, decimal firstNumber, decimal secondNumber)
    {
        var result = operation switch
        {
            "+" or "sum" => firstNumber + secondNumber,
            "-" or "subtract" => firstNumber - secondNumber,
            "*" or "multiply" => firstNumber * secondNumber,
            "division" => firstNumber / secondNumber,
            "√" or "sqrt" => (decimal) Math.Sqrt((double)(firstNumber + secondNumber)),
            _ => throw new InvalidOperationException("Invalid Operation")
        };
        return result;
    }
}

