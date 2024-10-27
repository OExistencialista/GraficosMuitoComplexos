using System.Numerics;
using Microsoft.AspNetCore.Mvc;
using GraficosMuitoComplexos.Models;
using Complex = GraficosMuitoComplexos.Models.Complex;

namespace GraficosMuitoComplexos.Controllers;
[Route("Functions/[controller]")]
[ApiController]
public class FunctionsController : Controller
{
    [HttpPost]
    public Complex Exp([FromBody] Complex complex)
    {
        return Complex.Exp(complex);
    }
    
}