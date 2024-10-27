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

    [HttpPost]
    [Route("Root/{real:double?}/{imaginary:double?}")]

    public Complex Root([FromBody] Complex z,double? real, double? imaginary )
    {
        Complex n = 2;
        if(real != null || imaginary != null) n = new Complex(real ?? 0, imaginary ?? 0);
        return Complex.Pow(z, 1/n);
    }
    
}