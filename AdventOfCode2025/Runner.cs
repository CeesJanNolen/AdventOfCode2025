using System.Diagnostics;
using System.Reflection;
using AdventOfCode2025.Solutions;

namespace AdventOfCode2025;

public static class Runner
{
    public static string? RunA(int day, long testResult)
    {
        var data = Input.GetInput(day);
        var sampleData = Input.GetSampleAInput(day);

        var assembly = Assembly.GetExecutingAssembly();

        var className = $"AdventOfCode2025.Solutions.Day{day}";
        var classType = assembly.GetType(className);

        if (classType == null) return null;
        if (Activator.CreateInstance(classType) is not IDay dayRunner) return null;
        var sampleResult = dayRunner.PartA(sampleData);
        if (sampleResult.Equals(testResult.ToString()))
        {
            var sw = new Stopwatch();
            sw.Start();
            var result = dayRunner.PartA(data);
            sw.Stop();
            Console.WriteLine($"Day {day} Part A took {sw.ElapsedMilliseconds}ms -  {sw.ElapsedTicks} ticks");
            return result;
        }

        Console.WriteLine("Test A failed!");
        Console.WriteLine($"Result was: {sampleResult}");
        Console.WriteLine($"Should have been: {testResult}");

        return null;
    }

    public static string? RunB(int day, long testResult)
    {
        var data = Input.GetInput(day);
        var sampleData = Input.GetSampleBInput(day);

        var assembly = Assembly.GetExecutingAssembly();

        var className = $"AdventOfCode2025.Solutions.Day{day}";
        var classType = assembly.GetType(className);

        if (classType == null) return null;
        if (Activator.CreateInstance(classType) is not IDay dayRunner) return null;
        var sampleResult = dayRunner.PartB(sampleData);
        if (sampleResult.Equals(testResult.ToString()))
        {
            var sw = new Stopwatch();
            sw.Start();
            var result = dayRunner.PartB(data);
            sw.Stop();
            Console.WriteLine($"Day {day} Part B took {sw.ElapsedMilliseconds}ms - {sw.ElapsedTicks} ticks");
            return result;
        }

        Console.WriteLine("Test B failed!");
        Console.WriteLine($"Result was: {sampleResult}");
        Console.WriteLine($"Should have been: {testResult}");

        return null;
    }
}