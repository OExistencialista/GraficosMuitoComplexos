using Microsoft.AspNetCore.Mvc;
using GraficosMuitoComplexos.Models;
    

namespace GraficosMuitoComplexos.Controllers;
[Route("BasicOperations/[controller]")]
[ApiController]
public class BasicOperationsController : Controller
{
    [HttpPost("/Mult/")]
    public IActionResult Mult([FromBody] BasicOperations operations)
    {
        return ExecuteOperation(operations, (a, b) => a * b);
    }

    [HttpPost("/Div/")]
    public IActionResult Div([FromBody] BasicOperations operations)
    {
        return ExecuteOperation(operations, (a, b) => a / b);
    }

    [HttpPost("/Add/")]
    public IActionResult Add([FromBody] BasicOperations operations)
    {
        return ExecuteOperation(operations, (a, b) => a + b);
    }

    [HttpPost("/Sub/")]
    public IActionResult Sub([FromBody] BasicOperations operations)
    {
        return ExecuteOperation(operations, (a, b) => a - b);
    }

    private IActionResult ExecuteOperation(BasicOperations operations, Func<Complex, Complex, Complex> operation)
    {
        try
        {
            var result = operation(operations.A, operations.B);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }
}