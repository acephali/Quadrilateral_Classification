using System;
using System.Windows; // Need to add WindowsBase.dll reference

namespace Quadrilateral_Classification
{
    internal class Program
    {
        static string QuadrilateralClassifier(int x1, int y1, int x2, int y2, int x3, int y3, int x4, int y4)
        {
            double AB = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
            double BC = Math.Sqrt(Math.Pow(x3 - x2, 2) + Math.Pow(y3 - y2, 2));
            double CD = Math.Sqrt(Math.Pow(x4 - x3, 2) + Math.Pow(y4 - y3, 2));
            double DA = Math.Sqrt(Math.Pow(x1 - x4, 2) + Math.Pow(y1 - y4, 2));
            double AC_diagonal = Math.Sqrt(Math.Pow(x3 - x1, 2) + Math.Pow(y3 - y1, 2));
            double B_angle = Math.Acos((Math.Pow(AB, 2) + Math.Pow(BC, 2) - Math.Pow(AC_diagonal, 2)) / (2 * AB * BC)) * 180 / Math.PI; // In degrees
            Vector dAB = new Vector(x2 - x1, y2 - y1);
            Vector dBC = new Vector(x3 - x2, y3 - y2);
            Vector dCD = new Vector(x4 - x3, y4 - y3);
            Vector dDA = new Vector(x1 - x4, y1 - y4);

            if (AB == BC && BC == CD && CD == DA && Math.Round(B_angle) == 90)
            {
                return "Square";
            }

            if (AB == BC && BC == CD && CD == DA)
            {
                return "Rhombus";
            }

            if (AB == CD && BC == DA && Math.Round(B_angle) == 90)
            {
                return "Rectangular";
            }

            if (AB == CD && BC == DA)
            {
                return "Parallelogram";
            }

            if ((AB == BC) && (CD == DA) || (BC == CD) && (DA == AB))
            {
                return "Kite";
            }

            if (dAB.X * dCD.Y - dAB.Y * dCD.X == 0 || dBC.X * dDA.Y - dBC.Y * dDA.X == 0)
            {
                return "Trapezoid";
            }

            return "Normal";
        }

        static void Main(string[] args)
        {
            // Uncomment if you want to read coordinates from file separated by whitespaces

            //System.IO.StreamReader streamReader = new System.IO.StreamReader("data.txt");
            //string[] data = streamReader.ReadLine().Split();
            //Console.WriteLine($"({data[0]},{data[1]}) ({data[2]},{data[3]}) ({data[4]},{data[5]}) ({data[6]},{data[7]}) Quadrilateral"); // Pasteable to Wolfram from console
            //Console.WriteLine("Type: " + QuadrilateralClassifier(int.Parse(data[0]), int.Parse(data[1]), int.Parse(data[2]), int.Parse(data[3]), int.Parse(data[4]), int.Parse(data[5]), int.Parse(data[6]), int.Parse(data[7])));
            //streamReader.Close();

            // Hardcoded coordinates
            int x1 = -81, y1 = 94, x2 = -81, y2 = 106, x3 = 1, y3 = -85, x4 = 1, y4 = -125;
            Console.WriteLine($"({x1},{y1}) ({x2},{y2}) ({x3},{y3}) ({x4},{y4}) Quadrilateral"); // Pasteable to Wolfram from console
            Console.WriteLine("Type: " + QuadrilateralClassifier(x1, y1, x2, y2, x3, y3, x4, y4));

            Console.ReadKey();
        }
    }
}
