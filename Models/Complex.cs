
namespace GraficosMuitoComplexos.Models

{

    

    public class Complex(double real = 0 , double imaginary =  0 ) 
    {
        public static implicit operator Complex(double valor)
        {
            return new Complex(valor);
        }

        public static implicit operator Complex((double, double) valor)
        {
            return new Complex(valor.Item1, valor.Item2);
            
        }
        public double Real { get; set; } = real;
        public double Imaginary { get; set; } = imaginary;

        public static Complex I { get; } = new Complex(0, 1);
        public static Complex Zero { get; } = new Complex();


        public static Polar PolarForm(Complex z)
        {
            double x = z.Real;
            double y = z.Imaginary;
            double radios = Pow(x * x + y * y, 1/2 ).Real;
            double angle = Arctan(y / x);
            
            
            return new Polar(angle, radios);
        }

        public override string ToString()
        {
            return Imaginary >= 0 ? $"{Real:F5} + {Imaginary:F5}i" : $"{Real:F5} - {-Imaginary:F5}i";
        }

        public static Complex operator *(Complex c1, Complex c2) =>
            new Complex((c1.Real * c2.Real) - (c1.Imaginary * c2.Imaginary),
                        (c1.Real * c2.Imaginary) + (c2.Real * c1.Imaginary));

        public static Complex operator *(Complex c1, double r1) =>
            new Complex(c1.Real * r1, c1.Imaginary * r1);
        public static Complex operator *(double r1, Complex c1) =>
            new Complex(c1.Real * r1, c1.Imaginary * r1);

        public static Complex operator /(Complex c1, Complex c2)
        {
            if (c2 is { Real: 0, Imaginary: 0 })
                throw new DivideByZeroException("Divisão por zero no número complexo.");

            double divisor = c2.Real * c2.Real + c2.Imaginary * c2.Imaginary;
            double realPart = (c1.Real * c2.Real + c1.Imaginary * c2.Imaginary) / divisor;
            double imagPart = (c1.Imaginary * c2.Real - c1.Real * c2.Imaginary) / divisor;

            return new Complex(realPart, imagPart);
        }

        public static Complex operator /(Complex c1, double r1)
        {
            if (r1 == 0)
                throw new DivideByZeroException("Divisão por zero por um número real.");

            return new Complex(c1.Real / r1, c1.Imaginary / r1);
        }

        public static Complex operator /(double r1, Complex c1)
        {
            if (c1 is { Real: 0, Imaginary: 0 })
                throw new DivideByZeroException("Divisão por zero no número complexo.");

            double divisor = c1.Real * c1.Real + c1.Imaginary * c1.Imaginary;
            double realPart = r1 * c1.Real / divisor;
            double imagPart = -r1 * c1.Imaginary / divisor;

            return new Complex(realPart, imagPart);
        }
        // Soma
        public static Complex operator +(Complex c1, Complex c2) =>
            new Complex(c1.Real + c2.Real, c1.Imaginary + c2.Imaginary);

        public static Complex operator +(double r1, Complex c2) =>
            new Complex(r1 + c2.Real, c2.Imaginary);
        public static Complex operator +(Complex c2, double r1) =>
            new Complex(r1 + c2.Real, c2.Imaginary);
        // Sub
        public static Complex operator -(Complex c1, Complex c2) =>
            new Complex(c1.Real - c2.Real, c1.Imaginary - c2.Imaginary);

            public static Complex operator -(double r1, Complex c2) =>
            new Complex(r1 - c2.Real, c2.Imaginary);
        public static Complex operator -(Complex c2, double r1) =>
            new Complex(r1 - c2.Real, c2.Imaginary);
        
        
 
        

        public static Complex Exp(Complex x ){
            var sum = new Complex(1);
            var term = new Complex(1);
            

            for (int n = 1; n < 100; n++)
            {
                term *= x / n;
                sum += term;
            }
            Console.WriteLine(sum);
            return sum;
        }

        private static Complex PowInt(Complex x, int n)
        {
            return n switch
            {
                0 => 1,
                > 0 => PowInt(x, n - 1) * x,
                < 0 => PowInt(x, n + 1) / x
            };
        }

        private static double LnR(double x, int iters = 1000){
            if (x <= 0)
                throw new ArgumentException("O logaritmo natural está indefinido para valores não positivos.");

            double y = (x - 1) / (x + 1);
            

            double result = 0.0;

            for (int n = 1; n <= iters; n += 2)
            {
                result += (1.0 / n) * PowInt(y, n).Real;
            }

            return 2 * result;
        }

        private static double Abs(double x) => (x >= 0) ? x : -x;
        private static double SqrtR(Complex x)
        {

            double estimativa = x.Real;
            const double epsilon = 1e-10;  
            double anterior;

            do
            {
                anterior = estimativa;
                estimativa = (anterior + x.Real / anterior) / 2;
            } while (Abs(anterior - estimativa) > epsilon);

            return estimativa;
        }


        public static Complex Ln(Complex z)
        {
                double radios = SqrtR((z.Real * z.Real) + (z.Imaginary * z.Imaginary)); 

                if (z.Imaginary == 0) return LnR(radios);
                if (z.Real == 0)
                    return (z.Imaginary > 0) ? LnR(radios) + ( double.Pi / 2) * I : LnR(radios) - (double.Pi / 2) * I;


                
                double angle = Arctan(z.Imaginary / z.Real);
                if (z.Real < 0)  
                    angle += Math.PI;

                return LnR(radios) + I * angle;
                
        }

        public static Complex Pow(Complex z, Complex? n = null)
        {
            n ??= 1;
            return Exp( (n) * Ln(z));
        }

        public static Complex Root(Complex z, Complex? n = null)
        {
            var power = 1 / (n ?? 2); 
                var value = Pow(z, power);
                return value;
        }
        
        public static Complex Sine(Complex z){
            return (Exp(I*z) - Exp(I*z*(-1)))/2* I;      
        }
        public static Complex Cosine(Complex z){
            return (Exp(I*z) + Exp(I*z*(-1)))/2;      
        }
        
       
        public static double Arctan(double x, int termos = 10)
        {
            double resultado = 0;
            double potencia = x;  // x^n, começando com x^1
            int sinal = 1;        // Alterna entre +1 e -1

            for (int n = 1; n <= termos * 2; n += 2)
            {
                resultado += sinal * (potencia / n);
                potencia *= x * x;  // Atualiza para x^(n+2)
                sinal = -sinal;     // Alterna o sinal
            }

            return resultado;
        }

      

        public static Complex Derivada(Func<Complex, Complex> funcao, Complex z, double h = 1e-5)
        { 
            return (funcao(z + h) - funcao(z)) / h; 
        }
       
         public static Complex Integral(Func<Complex, Complex> f, double a, double b, int n = 1000)
         {
             double delta = (b - a) / n;  
             Complex integral = 0;

             for (int i = 0; i < n; i++)
             {
                 Complex t1 = a + i * delta;
                 Complex t2 =  a + (i + 1) * delta;

                 var f1 = f(t1);
                 var f2 = f(t2);

                 integral += (f1 + f2) / 2 * delta;
             }

             return integral;
         }
        
       /*
         mto complexo (haha que comico) , tem que saber analise complexa
         public static Func<Complex, Complex> Integral(Func<Complex, Complex> funcao)
        {
           
        }
        
        */
        
    }
}