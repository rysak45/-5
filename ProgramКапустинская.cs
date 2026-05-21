using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Выберите тестовую функцию:");
        Console.WriteLine("1: x^2 - 4x + 5 (минимум в 2)");
        Console.WriteLine("2: sin(x) (минимум на [0,pi] в pi/2)");
        Console.WriteLine("3: x^4 - 2x^2 + 0.5 (минимумы в -1 и 1)");
        int choice = int.Parse(Console.ReadLine());

        Func<double, double> f;
        double a, b;
        switch (choice)
        {
            case 1:
                f = x => x * x - 4 * x + 5;
                a = 0; b = 5;
                break;
            case 2:
                f = Math.Sin;
                a = 0; b = Math.PI;
                break;
            case 3:
                f = x => Math.Pow(x, 4) - 2 * x * x + 0.5;
                a = -2; b = 2;
                break;
            default: return;
        }

        double eps = 1e-6;
        Console.WriteLine($"Деление пополам: {Minimizer.Bisection(f, a, b, eps):F10}");
        Console.WriteLine($"Золотое сечение: {Minimizer.GoldenSection(f, a, b, eps):F10}");
        Console.WriteLine($"Касательные (числ.): {Minimizer.NewtonMethod(f, a, b, eps):F10}");
        Console.WriteLine($"Фибоначчи: {Minimizer.FibonacciMethod(f, a, b, eps):F10}");
    }
}
