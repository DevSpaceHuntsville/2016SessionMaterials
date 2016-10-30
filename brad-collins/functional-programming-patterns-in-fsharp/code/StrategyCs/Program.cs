using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyCs
{
    public class Complex
    {
        public readonly double Re;
        public readonly double Im;

        public Complex(double re, double im)
        {
            Re = re;
            Im = im;
        }

        public override string ToString()
        {
            var sign = Math.Sign(Im) < 0 ? '-' : '+';
            return $"{Re:0.0} {sign} i{Math.Abs(Im):0.0}";
        }
    }

    public class ComplexReImAscComparer : IComparer<Complex>
    {
        public int Compare(Complex x, Complex y)
        {
            var re = Math.Sign(x.Re - y.Re);
            return re != 0 ? re : Math.Sign(x.Im - y.Im);
        }
    }

    public class ComplexReImDescComparer : IComparer<Complex>
    {
        public int Compare(Complex x, Complex y)
        {
            var re = Math.Sign(y.Re - x.Re);
            return re != 0 ? re : Math.Sign(y.Im - x.Im);
        }
    }

    public class ComplexImReAscComparer : IComparer<Complex>
    {
        public int Compare(Complex x, Complex y)
        {
            var im = Math.Sign(x.Im - y.Im);
            return im != 0 ? im : Math.Sign(x.Re - y.Re);
        }
    }

    public class ComplexImReDescComparer : IComparer<Complex>
    {
        public int Compare(Complex x, Complex y)
        {
            var im = Math.Sign(y.Im - x.Im);
            return im != 0 ? im : Math.Sign(y.Re - x.Re);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var xs = new List<Complex>()
            {
                new Complex( 4,  9),
                new Complex(-3,  1),
                new Complex( 1, -6),
                new Complex(-3, -2),
                new Complex( 7,  1),
            };

            Console.WriteLine("Ascending by Re, Im");
            xs.Sort(new ComplexReImAscComparer());
            foreach (var x in xs)
            {
                Console.WriteLine(x);
            }
            Console.WriteLine();

            Console.WriteLine("Ascending by Im, Re");
            xs.Sort(new ComplexImReAscComparer());
            foreach (var x in xs)
            {
                Console.WriteLine(x);
            }
        }
    }
}
