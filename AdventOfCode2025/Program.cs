using System.Diagnostics;
using AdventOfCode2025;

Console.WriteLine();

var day = DateTime.Now.Day;
var testResults = new Dictionary<int, Tuple<long, long>>()
{
    { 1, new Tuple<long, long>(3, 6) },
    { 2, new Tuple<long, long>(1227775554, 4174379265) },
    { 3, new Tuple<long, long>(357, 3121910778619) },
    { 4, new Tuple<long, long>(13, 43) },
};

var sw = new Stopwatch();
Console.WriteLine($"Day {day}");
sw.Start();
var resultA = Runner.RunA(day, testResults[day].Item1);
if (resultA != null)
{
    Console.WriteLine("A = ");
    Console.WriteLine(resultA);
}
Console.WriteLine($"elapsed: {sw.ElapsedMilliseconds}ms");
sw.Restart();

var resultB = Runner.RunB(day, testResults[day].Item2);
if (resultB != null)
{
    Console.WriteLine("B = ");
    Console.WriteLine(resultB);
}
sw.Stop();
Console.WriteLine($"elapsed: {sw.ElapsedMilliseconds}ms");
