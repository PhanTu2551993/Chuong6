namespace Chuong6
{
    public abstract class Shape
    {
        public abstract double GetArea();
        public abstract double GetPerimeter();
        public abstract override string ToString();
    }

    // Điểm
    public class Point
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public override string? ToString()
        {
            return $"Point({X}, {Y})";
        }
    }

    // Tiện ích hình học
    public static class GeometryUtils
    {
        public static double GetSideLength(Point p1, Point p2)
        {
            return Math.Sqrt(Math.Pow(p2.X - p1.X, 2) + Math.Pow(p2.Y - p1.Y, 2));
        }
    }

    // Đoạn thẳng
    public class LineSegment : Shape
    {
        public Point Start { get; set; }
        public Point End { get; set; }

        public LineSegment(Point start, Point end)
        {
            Start = start;
            End = end;
        }

        public override double GetArea()
        {
            return 0;
        }

        public override double GetPerimeter()
        {
            return GeometryUtils.GetSideLength(Start, End);
        }

        public override string ToString()
        {
            return $"LineSegment(Start: {Start}, End: {End})";
        }
    }

    // Đường tròn
    public class Circle : Shape
    {
        public Point Center { get; set; }
        public double Radius { get; set; }

        public Circle(Point center, double radius)
        {
            Center = center;
            Radius = radius;
        }

        public override double GetArea()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }

        public override double GetPerimeter()
        {
            return 2 * Math.PI * Radius;
        }

        public override string ToString()
        {
            return $"Circle(Center: {Center}, Radius: {Radius})";
        }
    }

    // Hình chữ nhật
    public class Rectangle : Shape
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public Rectangle(double width, double height)
        {
            Width = width;
            Height = height;
        }

        public override double GetArea()
        {
            return Width * Height;
        }

        public override double GetPerimeter()
        {
            return 2 * (Width + Height);
        }

        public override string ToString()
        {
            return $"Rectangle(Width: {Width}, Height: {Height})";
        }
    }

    // Hình vuông
    public class Square : Rectangle
    {
        public Square(double sideLength)
            : base(sideLength, sideLength)
        {
        }

        public override string ToString()
        {
            return $"Square(SideLength: {Width})";
        }
    }

    // Hình tam giác
    public class Triangle : Shape
    {
        public Point Vertex1 { get; set; }
        public Point Vertex2 { get; set; }
        public Point Vertex3 { get; set; }

        public Triangle(Point vertex1, Point vertex2, Point vertex3)
        {
            Vertex1 = vertex1;
            Vertex2 = vertex2;
            Vertex3 = vertex3;
        }

        public override double GetArea()
        {
            double a = GeometryUtils.GetSideLength(Vertex1, Vertex2);
            double b = GeometryUtils.GetSideLength(Vertex2, Vertex3);
            double c = GeometryUtils.GetSideLength(Vertex3, Vertex1);
            double s = (a + b + c) / 2;
            return Math.Sqrt(s * (s - a) * (s - b) * (s - c));
        }

        public override double GetPerimeter()
        {
            double a = GeometryUtils.GetSideLength(Vertex1, Vertex2);
            double b = GeometryUtils.GetSideLength(Vertex2, Vertex3);
            double c = GeometryUtils.GetSideLength(Vertex3, Vertex1);
            return a + b + c;
        }

        public override string ToString()
        {
            return $"Triangle(Vertex1: {Vertex1}, Vertex2: {Vertex2}, Vertex3: {Vertex3})";
        }
    }

    // Hình bình hành
    public class Parallelogram : Shape
    {
        public Point Vertex1 { get; set; }
        public Point Vertex2 { get; set; }
        public Point Vertex3 { get; set; }
        public Point Vertex4 { get; set; }

        public Parallelogram(Point vertex1, Point vertex2, Point vertex3, Point vertex4)
        {
            Vertex1 = vertex1;
            Vertex2 = vertex2;
            Vertex3 = vertex3;
            Vertex4 = vertex4;
        }

        public override double GetArea()
        {
            double baseLength = GeometryUtils.GetSideLength(Vertex1, Vertex2);
            double height = Math.Abs(Vertex3.Y - Vertex1.Y);
            return baseLength * height;
        }

        public override double GetPerimeter()
        {
            double a = GeometryUtils.GetSideLength(Vertex1, Vertex2);
            double b = GeometryUtils.GetSideLength(Vertex2, Vertex3);
            return 2 * (a + b);
        }

        public override string ToString()
        {
            return $"Parallelogram(Vertex1: {Vertex1}, Vertex2: {Vertex2}, Vertex3: {Vertex3}, Vertex4: {Vertex4})";
        }
    }

    // Hình thoi
    public class Rhombus : Shape
    {
        public Point Vertex1 { get; set; }
        public Point Vertex2 { get; set; }
        public Point Vertex3 { get; set; }
        public Point Vertex4 { get; set; }

        public Rhombus(Point vertex1, Point vertex2, Point vertex3, Point vertex4)
        {
            Vertex1 = vertex1;
            Vertex2 = vertex2;
            Vertex3 = vertex3;
            Vertex4 = vertex4;
        }

        public override double GetArea()
        {
            double diagonal1 = GeometryUtils.GetSideLength(Vertex1, Vertex3);
            double diagonal2 = GeometryUtils.GetSideLength(Vertex2, Vertex4);
            return (diagonal1 * diagonal2) / 2;
        }

        public override double GetPerimeter()
        {
            double sideLength = GeometryUtils.GetSideLength(Vertex1, Vertex2);
            return 4 * sideLength;
        }

        public override string ToString()
        {
            return $"Rhombus(Vertex1: {Vertex1}, Vertex2: {Vertex2}, Vertex3: {Vertex3}, Vertex4: {Vertex4})";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {

            Shape[] shapes = new Shape[]
            {
                new LineSegment(new Point(0, 0), new Point(3, 4)),
                new Circle(new Point(0, 0), 5),
                new Rectangle(4, 6),
                new Square(5),
                new Triangle(new Point(0, 0), new Point(4, 0), new Point(4, 3)),
                new Parallelogram(new Point(0, 0), new Point(4, 0), new Point(5, 3), new Point(1, 3)),
                new Rhombus(new Point(0, 0), new Point(3, 4), new Point(6, 0), new Point(3, -4))
            };

            foreach (Shape shape in shapes)
            {
                Console.WriteLine(shape);
                Console.WriteLine($"Area: {shape.GetArea()}");
                Console.WriteLine($"Perimeter: {shape.GetPerimeter()}");
                Console.WriteLine();
            }
        }
    }
}
