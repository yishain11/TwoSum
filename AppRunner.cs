using System;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;

public static class AppRunner
{
    public static void Run(Func<int[], int, int[]> twoSumFunction)
    {
        var results = Tests.RunAll(twoSumFunction);

        int passed = 0;
        foreach (var (success, message) in results)
        {
            if (success) passed++;
            Console.WriteLine((success ? "✅ Passed:" : "❌ Failed:") + $" {message}");
        }

        Console.WriteLine($"\nYou passed {passed} out of {results.Count} tests.");

        Console.Write("\nEnter your full name: ");
        string fullName = Console.ReadLine();

        Console.Write("Enter your class name: ");
        string className = Console.ReadLine();

        Console.WriteLine("\n📸 Please take a screenshot of this screen and send it to your teacher.");
        Console.WriteLine("-------------------------------------------------------------");
        Console.WriteLine($"👤 Name: {fullName}");
        Console.WriteLine($"🏫 Class: {className}");
        Console.WriteLine($"🧪 Score: {passed}/{results.Count} tests passed.");
        Console.WriteLine("-------------------------------------------------------------");
    }
}
