namespace AdventOfCode2025.Solutions;

public class Day4 : IDay
{
    public string PartA(List<string> lines)
    {
        var grid = new char[lines.First().Length, lines.Count];

        for (var r = 0; r < lines.Count; r++)
        {
            var line = lines[r];
            for (var c = 0; c < line.Length; c++)
            {
                grid[c, r] = line[c];
            }
        }

        return GetToBeRemoved(grid).ToString();
    }

    public string PartB(List<string> lines)
    {
        long ans = 0;

        var grid = new char[lines.First().Length, lines.Count];

        for (var r = 0; r < lines.Count; r++)
        {
            var line = lines[r];
            for (var c = 0; c < line.Length; c++)
            {
                grid[c, r] = line[c];
            }
        }

        var tempAns = GetToBeRemoved(grid);
        while (tempAns != 0)
        {
            ans += tempAns;
            tempAns = GetToBeRemoved(grid);
        }

        return ans.ToString();
    }

    private static int GetToBeRemoved(char[,] grid)
    {
        var foundItems = new List<(int c, int r)>();
        var rMax = grid.GetLength(0);
        var cMax = grid.GetLength(1);
        for (var c = 0; c < grid.GetLength(1); c++)
        {
            for (var r = 0; r < grid.GetLength(0); r++)
            {
                var current = grid[c, r];
                if (current == '.') continue;

                var filledAdjacent = 0;

                for (var cn = c - 1; cn <= c + 1; cn++)
                {
                    for (var rc = r - 1; rc <= r + 1; rc++)
                    {
                        if (cn < 0 || cn >= cMax || rc < 0 || rc >= rMax) continue;
                        if (grid[cn, rc] == '@') filledAdjacent++;
                    }
                }

                if (filledAdjacent > 4) continue;
                foundItems.Add((c, r));
            }
        }

        foundItems.ForEach(x => grid[x.c, x.r] = '.');

        return foundItems.Count;
    }
}