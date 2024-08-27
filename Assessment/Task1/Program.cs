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

        public void Move(double newX, double newY)
        {
            X += newX;
            Y += newY;
        }

        public void Rotate(double angle)
        {
            double radians = angle * (Math.PI / 180);
            double rotatedX = X* Math.Cos(radians) - Y * Math.Sin(radians);
            double rotatedY = X* Math.Sin(radians) + Y * Math.Cos(radians);

            X = Math.Round(rotatedX,2);
            Y = Math.Round(rotatedY,2);
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

        public void Move(double newX, double newY)
        {
            StartPoint.Move(newX, newY);
            EndPoint.Move(newX, newY);
        }

        public void Rotate(double angle)
        {
            StartPoint.Rotate(angle);
            EndPoint.Rotate(angle);
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

        public void Move(double newX, double newY)
        {
            Center.Move(newX, newY);
        }

        public void Rotate(double angle)
        {
            Center.Rotate(angle);
        }

        public override string ToString()
        {
            return $"Circle(Center: {Center}, Radius: {Radius})";
        }
    }

    public class Aggregation
    {
        private List<object> figures;

        public Aggregation()
        {
            figures = new List<object>();
        }

        public void AddFigure(object figure)
        {
            figures.Add(figure);
        }

        public void Move(double newX, double newY)
        {
            foreach (var figure in figures)
            {
                switch (figure)
                {
                    case Point p:
                        p.Move(newX, newY);
                        break;
                    case Line l:
                        l.Move(newX, newY);
                        break;
                    case Circle c:
                        c.Move(newX, newY);
                        break;
                }
            }
        }

        public void Rotate(double angle)
        {
            foreach (var figure in figures)
            {
                switch (figure)
                {
                    case Point p:
                        p.Rotate(angle);
                        break;
                    case Line l:
                        l.Rotate(angle);
                        break;
                    case Circle c:
                        c.Rotate(angle);
                        break;
                }
            }
        }

        public override string ToString()
        {
            string result = "Aggregation:\n";
            foreach (var figure in figures)
            {
                result += figure.ToString() + "\n";
            }
            return result;
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            Point point1 = new Point(1, 1);
            Point point2 = new Point(2, 2);
            Point point3 = new Point(3, 4);

            Line line1 = new Line(new Point(0,3), new Point(4,5));
            Line line2 = new Line(new Point(2, 3), new Point(4, 1));

            Circle circle1 = new Circle(new Point(3, 2), 4);
            Circle circle2 = new Circle(new Point(1, 2), 5);

            Console.WriteLine($"Point1: {point1}");
            Console.WriteLine($"Point2: {point2}");
            Console.WriteLine($"Point3: {point3}");

            Console.WriteLine($"Line1: {line1}");
            Console.WriteLine($"Line2: {line2}");

            Console.WriteLine($"Circle1: {circle1}");
            Console.WriteLine($"Circle2: {circle2}");

            point2.Move(2, 3);
            point3.Rotate(30);

            line1.Move(3, 3);
            line2.Rotate(90);

            circle1.Move(2,2);
            circle2.Rotate(45);

            Console.WriteLine("\nNew Values\n");

            Console.WriteLine($"New Point2: {point2}");
            Console.WriteLine($"New Point3: {point3}");
            Console.WriteLine($"New Line1: {line1}");
            Console.WriteLine($"New Line2: {line2}");
            Console.WriteLine($"New Circle1: {circle1}");
            Console.WriteLine($"New Circle2: {circle2}");

            Aggregation agg = new Aggregation();
            agg.AddFigure(point1);
            agg.AddFigure(point2);
            agg.AddFigure(line1);
            agg.AddFigure(circle1);

         
            Console.WriteLine("\nAggregation Original Positions:");
            Console.WriteLine(agg);

            
            agg.Move(2, 3);
            Console.WriteLine("After Move (2, 3):");
            Console.WriteLine(agg);

            
            agg.Rotate(90);
            Console.WriteLine("After Rotate 90 degrees around (0, 0):");
            Console.WriteLine(agg);

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}
