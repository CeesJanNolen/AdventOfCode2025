namespace AdventOfCode2025.Solutions;

public class Day6 : IDay
{
    public string PartA(List<string> lines)
    {
        long ans = 0;

        var sets = new Dictionary<int, List<string>>();
        foreach (var line in lines)
        {
            var expressions = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            for (var i = 0; i < expressions.Length; i++)
            {
                if (sets.TryGetValue(i, out var value))
                {
                    value.Add(expressions[i]);
                }
                else
                {
                    sets.Add(i, [expressions[i]]);
                }
            }
        }

        foreach (var expressionSet in sets.Values)
        {
            var operatorType = expressionSet.Last();
            switch (operatorType)
            {
                case "+":
                    ans += (expressionSet.SkipLast(1).Select(long.Parse).Sum());
                    break;
                case "*":
                    ans += (expressionSet.SkipLast(1).Select(long.Parse).Aggregate((x, y) => x * y));
                    break;
            }
        }

        return ans.ToString();
    }

    public string PartB(List<string> lines)
    {
        long ans = 0;


        var lastLine = lines.Last();

        var currentOperator = ' ';
        long temp = 0;
        for (var i = 0; i < lastLine.Length; i++)
        {
            var operatorType = lastLine[i];
            if (!operatorType.Equals(' '))
            {
                currentOperator = operatorType;
                ans += temp;
                temp = 0;
            }

            var set = "";
            for (var i1 = 0; i1 < lines.Count - 1; i1++)
            {
                set += lines[i1][i];
            }

            if (string.IsNullOrWhiteSpace(set)) continue;
            var tempVal = long.Parse(set);
            if (temp == 0)
            {
                temp = long.Parse(set);
            }
            else
            {
                switch (currentOperator)
                {
                    case '+':
                        temp += tempVal;
                        break;
                    case '*':
                        temp *= tempVal;
                        break;
                }
            }
        }

        ans += temp;
        
        return ans.ToString();
    }
}