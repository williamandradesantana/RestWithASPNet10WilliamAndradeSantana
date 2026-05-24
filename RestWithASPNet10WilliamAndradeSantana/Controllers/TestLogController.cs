using Microsoft.AspNetCore.Mvc;

namespace RestWithASPNet10WilliamAndradeSantana.Controllers;

[ApiController]
[Route("api/[controller]/v1")]
public class TestLogController : ControllerBase
{
    private readonly ILogger<TestLogController> _logger;
    public TestLogController(ILogger<TestLogController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IActionResult LogTest()
    {
        _logger.LogTrace("This is a TRACE log message");
        _logger.LogDebug("This is a DEBUG log message");
        _logger.LogInformation("This is an INFORMATION log message");
        _logger.LogWarning("This is a WARNING log message");
        _logger.LogError("This is an ERROR log message");
        _logger.LogCritical("This is a CRITICAL log message");
        return Ok("Log messages have been generated. Click your logging checkout");
    }

}