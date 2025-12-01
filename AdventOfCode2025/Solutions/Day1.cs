namespace AdventOfCode2025.Solutions;

public class Day1 : IDay
{
    public string PartA(List<string> lines)
    {
        var start = 50;
        var occurrences = 0;
        foreach (var line in lines)
        {
            var direction = line[0];
            var distance = int.Parse(line[1..]);

            start = direction switch
            {
                'R' => (start + distance - 100) % 100,
                'L' => (start - distance + 100) % 100,
                _ => start
            };

            if (start == 0) occurrences++;
        }

        return occurrences.ToString();
    }

    public string PartB(List<string> lines)
    {
        var start = 50;
        var occurrences = 0;
        foreach (var line in lines)
        {
            var direction = line[0];
            var distance = int.Parse(line[1..]);

            for (int i = 0; i < distance; i++)
            {
                
                start = direction switch
                {
                    'R' => (start + 1 - 100) % 100,
                    'L' => (start - 1 + 100) % 100,
                    _ => start
                };


                if (start == 0) occurrences++;
            }
        }

        return occurrences.ToString();
        
        return 0.ToString();
    }
}