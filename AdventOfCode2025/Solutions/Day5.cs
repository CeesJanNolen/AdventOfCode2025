namespace AdventOfCode2025.Solutions;

public class Day5 : IDay
{
    public string PartA(List<string> lines)
    {
        var ans = 0;
        var ranges = new List<(long Start, long End)>();

        var atHalf = false;
        foreach (var line in lines)
        {
            if (!atHalf && line.Equals(""))
            {
                atHalf = true;
            }
            else
            {
                if (!atHalf)
                {
                    var firstNum = long.Parse(line.Split("-")[0]);
                    var secondNum = long.Parse(line.Split("-")[1]);
                    ranges.Add((firstNum, secondNum));
                }
                else
                {
                    var current = long.Parse(line);
                    if (ranges.Any(x => x.Start <= current && current <= x.End))
                        ans++;
                }
            }
        }

        return ans.ToString();
    }

    public string PartB(List<string> lines)
    {
        long ans = 0;
        var ranges = new List<(long Start, long End)>();

        foreach (var line in lines)
        {
            if (line.Equals(""))
            {
                break;
            }

            var firstNum = long.Parse(line.Split("-")[0]);
            var secondNum = long.Parse(line.Split("-")[1]);

            ranges.Add((firstNum, secondNum));
        }

        ranges = ranges.OrderBy(x => x.Start).ToList();

        long tempSize = 0;
        long maxEnd = 0;
        foreach (var valueTuple in ranges)
        {
            if (valueTuple.Start <= maxEnd)
            {
                //we continue the range because we still fall in the range!
                var newEnd = Math.Max(maxEnd, valueTuple.End);

                //the end is larger, so we increase it to hold the new one.
                tempSize += newEnd - maxEnd;
                maxEnd = newEnd;
            }
            else if (valueTuple.End < maxEnd)
            {
                //we can ignore this as it's already covered.
            }
            else
            {
                ans += tempSize;

                //we start a new range
                maxEnd = valueTuple.End;
                tempSize = valueTuple.End - valueTuple.Start + 1;
            }
        }

        ans += tempSize;

        return ans.ToString();
    }
}