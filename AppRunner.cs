using System;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;

public static class AppRunner
{
    public static void Run(Func<int[], int, int[]> twoSumFunction)
    {
        var results = Tests.RunAll(twoSumFunction);

        double passed = 0.0;
        foreach (var (success, message) in results)
        {
            if (success) passed++;
            Console.WriteLine((success ? "Passed:" : "Failed:") + $" {message}");
        }

        Console.WriteLine($"\nYou passed {passed} out of {results.Count} tests.");
        Console.WriteLine($"\nyour grade is: {(passed/results.Count)*100}%");

        Console.Write("\nDo you want to submit? Y/N ");
        string answer = Console.ReadLine().ToLower();
        if (answer == "n") {
            return;
        }

        Console.Write("\nEnter your full name: ");
        string fullName = Console.ReadLine();

        Console.Write("Enter your class name: ");
        string className = Console.ReadLine();

        Console.WriteLine("\nPlease take a screenshot of this screen and send it to your teacher.");
        Console.WriteLine("-------------------------------------------------------------");
        Console.WriteLine($"Name: {fullName}");
        Console.WriteLine($"Class: {className}");
        Console.WriteLine($"Score: {passed}/{results.Count} tests passed.");
        Console.WriteLine("-------------------------------------------------------------");
        Console.WriteLine("\nPlease send Program.cs to your teacher in discord.\n Make sure that your code is commented and explained!\n");
    }
}
