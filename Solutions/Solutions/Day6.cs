namespace Solutions;

public static class Day6
{
    public static readonly string InputFile = "Day6-1.txt";

    public static int FirstStar()
    {
        var input = File.ReadAllText(InputFinder.GetInputPath(InputFile));
        return FindFirstDifferentSub(input, 4);
    }

    public static int SecondStar()
    {
        var input = File.ReadAllText(InputFinder.GetInputPath(InputFile));
        return FindFirstDifferentSub(input, 14);
    }

    private static int FindFirstDifferentSub(string input, int diffLength)
    {
        var list = Enumerable.Range(0, input.Length + diffLength)
            .Select(x => new HashSet<char>())
            .ToList();

        for (int i = 0; i < input.Length; i++)
        {
            for (int j = i; j < i + diffLength; j++)
            {
                list[j].Add(input[i]);
            }

            if (list[i].Count == diffLength)
            {
                return i + 1;
            }
        }

        return -1;
    }
}
