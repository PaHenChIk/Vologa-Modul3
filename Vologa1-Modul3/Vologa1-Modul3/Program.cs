using System;

public delegate double AreaDelegate();

public abstract class Shape
{
    public abstract double CalculateArea();
}

public class Circle : Shape
{
    private double radius;

    public Circle(double radius)
    {
        this.radius = radius;
    }

    public override double CalculateArea()
    {
        return Math.PI * Math.Pow(radius, 2);
    }
}

public class Rectangle : Shape
{
    private double width;
    private double height;

    public Rectangle(double width, double height)
    {
        this.width = width;
        this.height = height;
    }

    public override double CalculateArea()
    {
        return width * height;
    }
}

public class Triangle : Shape
{
    private double baseLength;
    private double height;

    public Triangle(double baseLength, double height)
    {
        this.baseLength = baseLength;
        this.height = height;
    }

    public override double CalculateArea()
    {
        return 0.5 * baseLength * height;
    }
}

public class Vivod_Figur 
{
    static void Main(string[] args)
    {
        Vivod_Figur vivod_figur = new Vivod_Figur();
        vivod_figur.vivod_Figur();
    }

    public void vivod_Figur() 
    {
       
            try
            {
                Console.Write("Введите радиус круга: ");
                if (!double.TryParse(Console.ReadLine(), out double circleRadius) || circleRadius <= 0)
                    throw new Exception("Радиус должен быть положительным числом.");
                Shape circle = new Circle(circleRadius);

                Console.Write("Введите ширину прямоугольника: ");
                if (!double.TryParse(Console.ReadLine(), out double rectangleWidth) || rectangleWidth <= 0)
                    throw new Exception("Ширина должна быть положительным числом.");
                Console.Write("Введите высоту прямоугольника: ");
                if (!double.TryParse(Console.ReadLine(), out double rectangleHeight) || rectangleHeight <= 0)
                    throw new Exception("Высота должна быть положительным числом.");
                Shape rectangle = new Rectangle(rectangleWidth, rectangleHeight);

                Console.Write("Введите основание треугольника: ");
                if (!double.TryParse(Console.ReadLine(), out double triangleBase) || triangleBase <= 0)
                    throw new Exception("Основание должно быть положительным числом.");
                Console.Write("Введите высоту треугольника: ");
                if (!double.TryParse(Console.ReadLine(), out double triangleHeight) || triangleHeight <= 0)
                    throw new Exception("Высота должна быть положительным числом.");
                Shape triangle = new Triangle(triangleBase, triangleHeight);

                AreaDelegate circleDelegate = circle.CalculateArea;
                AreaDelegate rectangleDelegate = rectangle.CalculateArea;
                AreaDelegate triangleDelegate = triangle.CalculateArea;

                Console.WriteLine("Площадь круга: " + circleDelegate());
                Console.WriteLine("Площадь прямоугольника: " + rectangleDelegate());
                Console.WriteLine("Площадь треугольника: " + triangleDelegate());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.ReadKey();
            }
       
       
    }
}
