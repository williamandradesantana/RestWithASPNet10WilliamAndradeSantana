using Microsoft.AspNetCore.Mvc;
using RestWithASPNet10WilliamAndradeSantana.Services;
using System.Globalization;

namespace RestWithASPNet10WilliamAndradeSantana.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MathController : ControllerBase
{
    private readonly MathService _mathService;

    public MathController(MathService mathService)
    {
        _mathService = mathService;
    }

    [HttpGet("{operation}/{firstNumber}/{secondNumber}")]
    public IActionResult Get(
        [FromRoute] string operation,
        [FromRoute] string firstNumber,
        [FromRoute] string secondNumber)
    {
        if (!TryParseDecimal(firstNumber, out var first) ||
            !TryParseDecimal(secondNumber, out var second))
        {
            return BadRequest("Os parâmetros devem ser números válidos.");
        }

        try
        {
            var result = _mathService.Calculate(operation, first, second);
            return Ok(result);
        }
        catch (DivideByZeroException)
        {
            return BadRequest("Divisão por zero não é permitida.");
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    private static bool TryParseDecimal(string value, out decimal result) =>
        decimal.TryParse(
            value,
            NumberStyles.Any,
            NumberFormatInfo.InvariantInfo,
            out result);
}