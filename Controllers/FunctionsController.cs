using Microsoft.AspNetCore.Mvc;
using Complex = GraficosMuitoComplexos.Models.Complex;

namespace GraficosMuitoComplexos.Controllers;
[Route("Functions/[controller]")]
[ApiController]
public class FunctionsController : Controller
{

        [HttpPost("/Exp/")]
        public IActionResult Exp([FromBody] Complex x)
        {
            return Ok(Complex.Exp(x));
        }

        [HttpPost("/Ln/")]
        public IActionResult Ln([FromBody] Complex z)
        {
            return Ok(Complex.Ln(z));
        }

        [HttpPost("/Pow/")]
        public IActionResult Pow([FromBody] Complex z, [FromQuery] Complex? n = null)
        {
            return Ok(Complex.Pow(z, n));
        }

        [HttpPost("/Root/")]
        public IActionResult Root([FromBody] Complex z, [FromQuery] Complex? n = null)
        {
            return Ok(Complex.Root(z, n));
        }

        [HttpPost("/Sine/")]
        public IActionResult Sine([FromBody] Complex z)
        {
            return Ok(Complex.Sine(z));
        }

        [HttpPost("/Cosine/")]
        public IActionResult Cosine([FromBody] Complex z)
        {
            return Ok(Complex.Cosine(z));
        }

        [HttpPost("/Derivada/")]
        public IActionResult Derivada([FromBody] Complex z, [FromQuery] double h = 1e-5)
        {
            var funcao = Complex.Sine;
            return Ok(Complex.Derivada(funcao, z, h));
        }

        [HttpPost("/Integral/")]
        public IActionResult Integral([FromBody] Func<Complex, Complex> f, [FromQuery] double a, [FromQuery] double b,
            [FromQuery] int n = 1000)
        {
            return Ok(Complex.Integral(f, a, b, n));
        }

        
}

