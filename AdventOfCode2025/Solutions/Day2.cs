namespace AdventOfCode2025.Solutions;

public class Day2 : IDay
{
    public string PartA(List<string> lines)
    {
        var idSets = lines.First().Split(",");
        long invalidCount = 0;
        foreach (var idSet in idSets)
        {
            var start = long.Parse(idSet.Split("-")[0]);
            var end = long.Parse(idSet.Split("-")[1]);

            for (var i = start; i <= end; i++)
            {
                var idString = i.ToString();
                if (idString.Length % 2 == 1) continue;

                var firstHalf = idString[..(idString.Length / 2)];
                var secondHalf = idString[(idString.Length / 2)..];

                if (firstHalf.Equals(secondHalf))
                {
                    invalidCount += i;
                }
            }
        }

        return invalidCount.ToString();
    }

    public string PartB(List<string> lines)
    {
        var idSets = lines.First().Split(",");
        long invalidCount = 0;
        foreach (var idSet in idSets)
        {
            var start = long.Parse(idSet.Split("-")[0]);
            var end = long.Parse(idSet.Split("-")[1]);

            for (var i = start; i <= end; i++)
            {
                var idString = i.ToString();

                if (idString.Length % 2 == 0)
                {
                    var firstHalf = idString[..(idString.Length / 2)];
                    var secondHalf = idString[(idString.Length / 2)..];

                    if (firstHalf.Equals(secondHalf))
                    {
                        invalidCount += i;
                        //we continue because we already found a pair that matches
                        continue;
                    }
                }

                //we only need to check for pairs that are bigger than 2
                if (idString.Length <= 2) continue;
                for (var j = 1; j <= idString.Length / 2; j++)
                {
                    //we can skip this part if the part doesn't divide evenly'
                    if (idString.Length % j != 0) continue;
                    var part = idString[..j];

                    var rest = idString[j..];
                    //if the rest doesn't contain the part, we can skip this part'
                    if (!rest.Contains(part)) continue;

                    //we can skip this part if there are other parts that contain the part'
                    var restPieces = Split(rest, part.Length).ToList();

                    if (restPieces.Any(x => !x.Contains(part))) continue;

                    invalidCount += i;
                    break;
                }
            }
        }

        return invalidCount.ToString();
    }

    private static IEnumerable<string> Split(string str, int chunkSize)
    {
        return Enumerable.Range(0, str.Length / chunkSize)
            .Select(i => str.Substring(i * chunkSize, chunkSize));
    }
}