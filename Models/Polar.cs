namespace GraficosMuitoComplexos.Models;

public class Polar(double angle, double radius)
{


    public double Angle { get; set; } = angle;
    public double Radius { get; set; } = radius;

        public Complex NormalForm()
        {
            return Radius * Complex.Exp(Complex.I * Angle);
        }

        public override string ToString()
        {
            return $"{Radius} * e^i{Angle/double.Pi}";
        }

        public static Polar operator +( Polar a, Polar b )
        {
            return (a.NormalForm() + b.NormalForm()).PolarForm();
        }
        public static Polar operator -( Polar a, Polar b )
        {
            return (a.NormalForm() - b.NormalForm()).PolarForm();
        }
        public static Polar operator *( Polar a, Polar b )
        {
            return new Polar(a.Radius * b.Radius, a.Angle + b.Angle );
        }
        public static Polar operator /( Polar a, Polar b )
        {
            return new Polar(a.Radius / b.Radius, a.Angle - b.Angle );
        }
        
        
}