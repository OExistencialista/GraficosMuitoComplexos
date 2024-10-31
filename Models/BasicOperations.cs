namespace GraficosMuitoComplexos.Models;

public class BasicOperations
{
    public Complex A { get; set; } = 0;
    public Complex B { get; set; } = 0;

    public void Deconstruct(out Complex a, out Complex b)
    {
        a = A;
        b = B;
    }
}