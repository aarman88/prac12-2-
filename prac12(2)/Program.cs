using System;

// Определение делегата
public delegate double MathOperation(double x, double y);

class Program
{
    // Статические методы для выполнения арифметических операций
    static double Add(double x, double y) => x + y;
    static double Subtract(double x, double y) => x - y;
    static double Multiply(double x, double y) => x * y;
    static double Divide(double x, double y) => y != 0 ? x / y : double.NaN;

    // Метод для выполнения операции с использованием делегата
    static double PerformOperation(double x, double y, MathOperation operation)
    {
        return operation(x, y);
    }

    static void Main()
    {
        // Создание экземпляров делегата
        MathOperation addDelegate = Add;
        MathOperation subtractDelegate = Subtract;
        MathOperation multiplyDelegate = Multiply;
        MathOperation divideDelegate = Divide;

        // Демонстрация использования делегатов
        Console.WriteLine("Результат сложения: " + PerformOperation(5, 3, addDelegate));
        Console.WriteLine("Результат вычитания: " + PerformOperation(5, 3, subtractDelegate));
        Console.WriteLine("Результат умножения: " + PerformOperation(5, 3, multiplyDelegate));
        Console.WriteLine("Результат деления: " + PerformOperation(5, 3, divideDelegate));

        // Использование анонимных методов
        MathOperation powerDelegate = delegate (double x, double y) { return Math.Pow(x, y); };
        Console.WriteLine("Результат возведения в степень: " + PerformOperation(2, 3, powerDelegate));

        // Использование лямбда-выражений
        MathOperation squareRootDelegate = (x, y) => Math.Pow(x, 1 / y);
        Console.WriteLine("Результат извлечения корня: " + PerformOperation(9, 2, squareRootDelegate));

        // Цепочка делегатов
        MathOperation chainDelegate = addDelegate + subtractDelegate + multiplyDelegate;
        Console.WriteLine("Результат цепочки делегатов: " + chainDelegate(5, 2));

        // Удаление метода из цепочки
        chainDelegate -= multiplyDelegate;
        Console.WriteLine("Результат после удаления умножения из цепочки делегатов: " + chainDelegate(5, 2));
    }
}
