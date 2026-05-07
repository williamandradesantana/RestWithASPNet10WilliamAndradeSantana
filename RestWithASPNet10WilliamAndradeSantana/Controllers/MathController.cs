using Microsoft.AspNetCore.Mvc;
using RestWithASPNet10WilliamAndradeSantana.Services;

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
    public IActionResult Get([FromRoute] string operation, [FromRoute] string firstNumber, [FromRoute] string secondNumber)
    {
        if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
        {
            firstNumber = ConvertToDecimal(firstNumber);
            secondNumber = ConvertToDecimal(secondNumber);
            var result = _mathService.Calculator(operation, firstNumber, secondNumber);
            return Ok(result);
        }
        return BadRequest("Invalid Operation");
    }

    private bool IsNumeric(string secondNumber)
    {
        throw new NotImplementedException();
    }

    private decimal ConvertToDecimal(string secondNumber)
    {
        throw new NotImplementedException();
    }
}

