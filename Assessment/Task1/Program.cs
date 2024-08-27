using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class Point
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }
        public override string ToString()
        {
            return $"Point({X}, {Y})";
        }
    }

    public class Line
    {
        public Point StartPoint { get; set; }
        public Point EndPoint { get; set; }

        public Line(Point startPoint, Point endPoint)
        {
            StartPoint = startPoint;
            EndPoint = endPoint;
        }
        public override string ToString()
        {
            return $"Line(Start: {StartPoint}, End: {EndPoint})";
        }
    }

    public class Circle
    {
        public Point Center { get; set; }
        public double Radius { get; set; }

        public Circle(Point center, double radius)
        {
            Center = center;
            Radius = radius;
        }
        public override string ToString()
        {
            return $"Circle(Center: {Center}, Radius: {Radius})";
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            Point point1 = new Point(1, 1);
            Point point2 = new Point(2, 2);
            Point point3 = new Point(3, 3);

            Line line1 = new Line(point1, point2);
            Line line2 = new Line(point2, point3);

            Circle circle1 = new Circle(point1, 3);
            Circle circle2 = new Circle(point2, 5);

            Console.WriteLine($"Point1: {point1}");
            Console.WriteLine($"Point2: {point2}");
            Console.WriteLine($"Point3: {point3}");

            Console.WriteLine($"Line1: {line1}");
            Console.WriteLine($"Line2: {line2}");

            Console.WriteLine($"Circle1: {circle1}");
            Console.WriteLine($"Circle2: {circle2}");

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}
