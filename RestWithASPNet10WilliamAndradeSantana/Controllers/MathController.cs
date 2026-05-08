using Microsoft.AspNetCore.Mvc;
using RestWithASPNet10WilliamAndradeSantana.Services;
using RestWithASPNet10WilliamAndradeSantana.Utils;

namespace RestWithASPNet10WilliamAndradeSantana.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MathController : ControllerBase
{
    private readonly MathService _mathService;
    private readonly MathUtils _mathUtils;

    public MathController(MathService mathService, MathUtils mathUtils)
    {
        _mathService = mathService;
        _mathUtils = mathUtils;
    }

    [HttpGet("{operation}/{firstNumber}/{secondNumber}")]
    public IActionResult Get(
        [FromRoute] string operation,
        [FromRoute] string firstNumber,
        [FromRoute] string secondNumber)
    {
        if (!_mathUtils.TryParseDecimal(firstNumber, out var first) ||
            !_mathUtils.TryParseDecimal(secondNumber, out var second))
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
}