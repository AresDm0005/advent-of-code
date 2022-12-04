using System.Runtime.InteropServices;

namespace Solutions;

public static class Day4
{
    public static readonly string InputFile = "Day4-1.txt";

    public static int FirstStar()
    {
        var answer = File.ReadAllLines(InputFinder.GetInputPath(InputFile))
            .Select(x => x
                .Split(',')
                .Select(y =>
                    y.Split('-')
                        .Select(z => int.Parse(z))
                        .ToList())
                .Select(y => new { St = y[0], End = y[1] })
                .ToList()
            )
            .Select(x => new { First = x[0], Second = x[1] })
            .Count(x =>
            {
                if (x.First.St <= x.Second.St
                    && x.First.End >= x.Second.End)
                    return true;

                if (x.Second.St <= x.First.St
                    && x.Second.End >= x.First.End)
                    return true;

                return false;
            });

        return answer;
    }

    public static int SecondStar()
    {
        var answer = File.ReadAllLines(InputFinder.GetInputPath(InputFile))
            .Select(x => x
                .Split(',')
                .Select(y =>
                    y.Split('-')
                        .Select(z => int.Parse(z))
                        .ToList())
                .Select(y => new { St = y[0], End = y[1] })
                .ToList()
            )
            .Select(x => new { First = x[0], Second = x[1] })
            .Count(x =>
            {
                if (x.First.St < x.Second.St
                    && x.First.End < x.Second.St)
                    return false;

                if (x.Second.St < x.First.St
                    && x.Second.End < x.First.St)
                    return false;

                return true;
            });

        return answer;
    }
}
