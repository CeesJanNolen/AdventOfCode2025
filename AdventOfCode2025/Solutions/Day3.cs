namespace AdventOfCode2025.Solutions;

public class Day3 : IDay
{
    public string PartA(List<string> lines)
    {
        long ans = 0;

        foreach (var line in lines)
        {
            var firstNumber = 0;
            var secondNumber = 0;
            for (var i = 0; i < line.Length; i++)
            {
                var current = int.Parse(line[i].ToString());
                if (firstNumber < current && i != line.Length - 1)
                {
                    firstNumber = current;
                    secondNumber = 0;
                }
                else if (secondNumber < current && i != 0)
                {
                    secondNumber = current;
                }
            }

            ans += (firstNumber * 10) + secondNumber;
        }

        return ans.ToString();
    }

    public string PartB(List<string> lines)
    {
        long ans = 0;

        foreach (var line in lines)
        {
            var numberList = new int[12];
            for (var i = 0; i < line.Length; i++)
            {
                var current = int.Parse(line[i].ToString());

                for (var i1 = 0; i1 < numberList.Length; i1++)
                {
                    var number = numberList[i1];
                    if (number < current && i <= line.Length - (numberList.Length - i1))
                    {
                        numberList[i1] = current;
                        //reset the rest that's remaining:
                        for (var j = i1 +1; j < numberList.Length; j++)
                        {
                            numberList[j] = 0;
                        }
                        break;
                    }
                }
            }
          
            // var texmpstring = ;
            ans += long.Parse(string.Join("", numberList));
        }

        return ans.ToString();
    }
}