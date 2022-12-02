namespace Solutions;

public static class Day1
{
    public static readonly string FileEOL = "\r\n";
    public static readonly string InputFile = "Day1-1.txt";

    public static int FirstStar()
    {
        var answer = File.ReadAllText(InputFinder.GetInputPath(InputFile))
            .Split(FileEOL + FileEOL, StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)
            .Max(x => x.Split(FileEOL).Select(y => int.Parse(y)).Sum());

        return answer;
    }

    public static int SecondStar()
    {
        var answer = File.ReadAllText(InputFinder.GetInputPath(InputFile))
            .Split(FileEOL + FileEOL, StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)
            .Select(x => x.Split(FileEOL).Select(y => int.Parse(y)).Sum())
            .OrderByDescending(x => x)
            .Take(3)
            .Sum();

        return answer;
    }
}
