using System;
using System.Globalization;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;
Console.InputEncoding = Encoding.UTF8;

double a = ReadSide("a");
double b = ReadSide("b");
double c = ReadSide("c");

if (!TriangleExists(a, b, c))
{
    Console.WriteLine("Трикутник із такими сторонами не існує.");
    return;
}

double perimeter = GetPerimeter(a, b, c);
double area = GetArea(a, b, c);
string type = GetTriangleType(a, b, c);

Console.WriteLine($"Периметр: {perimeter:F2}");
Console.WriteLine($"Площа: {area:F2}");
Console.WriteLine($"Вид трикутника: {type}");

static double ReadSide(string name)
{
    while (true)
    {
        Console.Write($"Введіть сторону {name}: ");
        string? input = Console.ReadLine();
        if (input == null) return 0;

        string text = input.Trim().Replace(',', '.');
        if (double.TryParse(text, CultureInfo.InvariantCulture, out double value) && value > 0)
        {
            return value;
        }

        Console.WriteLine("Помилка: сторона повинна бути додатним числом.");
    }
}

static bool ArePositive(double a, double b, double c)
{
    return a > 0 && b > 0 && c > 0;
}

static bool TriangleExists(double a, double b, double c)
{
    return ArePositive(a, b, c) && a + b > c && a + c > b && b + c > a;
}

static double GetPerimeter(double a, double b, double c)
{
    return a + b + c;
}

static double GetArea(double a, double b, double c)
{
    double p = GetPerimeter(a, b, c) / 2.0;
    return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
}

static string GetTriangleType(double a, double b, double c)
{
    const double eps = 1e-6;

    if (Math.Abs(a - b) < eps && Math.Abs(b - c) < eps)
    {
        return "рівносторонній";
    }

    bool isosceles = Math.Abs(a - b) < eps || Math.Abs(b - c) < eps || Math.Abs(a - c) < eps;
    bool right = Math.Abs(a * a + b * b - c * c) < eps
        || Math.Abs(a * a + c * c - b * b) < eps
        || Math.Abs(b * b + c * c - a * a) < eps;

    if (isosceles && right) return "рівнобедрений прямокутний";
    if (isosceles) return "рівнобедрений";
    if (right) return "прямокутний";

    return "довільний";
}
