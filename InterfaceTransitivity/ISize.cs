using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceTransitivity
{
    interface ISize
    {
        double Width { get; set; }
        double Height { get; set; }

        double Calc();
    }

    class Shape : ISize
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public /* virtual */ double Calc()
        {
            Console.WriteLine("ShapeSize:");
            return Width * Height;
        }
    }

    class Square : Shape
    {
        public Square(double d)
        {
            Width = Height = d;
        }

        public /* override */ double Calc()
        {
            Console.WriteLine("SqareSize:");
            return Width * Width;
        }
    }

    class Program
    {
        public static void Main()
        {
            Shape s = new Shape { Width = 10, Height = 10 };
            Square sq = new Square(20);

            // Square neimplementuje přímo ISize, ale její
            // předek ano, takže můžeme pracovat s kolekcí ISize
            // a vložit do ní i Square
            // Pokud ale nebude Shape.Calc() virtuální 
            // a Square.Calc() nebude overriden,
            // nebude se nikdy volat metoda Square.Calc().
            ISize[] sizeArr = new ISize[] { s, sq };

            foreach (var i in sizeArr)
                Console.WriteLine(i.Calc());
        }

       
    }
}
