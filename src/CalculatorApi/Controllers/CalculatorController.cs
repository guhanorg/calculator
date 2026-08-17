using CalculatorApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace CalculatorApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CalculatorController(ICalculatorService calculatorService) : ControllerBase
{
    [HttpGet("add")]
    public IActionResult Add([FromQuery] double a, [FromQuery] double b) =>
        Ok(new { result = calculatorService.Add(a, b) });

    [HttpGet("subtract")]
    public IActionResult Subtract([FromQuery] double a, [FromQuery] double b) =>
        Ok(new { result = calculatorService.Subtract(a, b) });

    [HttpGet("multiply")]
    public IActionResult Multiply([FromQuery] double a, [FromQuery] double b) =>
        Ok(new { result = calculatorService.Multiply(a, b) });

    [HttpGet("divide")]
    public IActionResult Divide([FromQuery] double a, [FromQuery] double b)
    {
        try
        {
            return Ok(new { result = calculatorService.Divide(a, b) });
        }
        catch (DivideByZeroException ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }
}
