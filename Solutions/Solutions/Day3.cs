namespace Solutions;

public static class Day3
{
    public static readonly string InputFile = "Day3-1.txt";

    public static int FirstStar()
    {
        var rucksacks = File.ReadAllLines(InputFinder.GetInputPath(InputFile));
        var answer = 0;
        foreach (var rucksack in rucksacks)
        {
            var set = new HashSet<char>();

            for (int i = 0; i < rucksack.Length; i++)
            {
                if (i < rucksack.Length / 2) {
                    set.Add(rucksack[i]);
                }
                else
                {
                    if (set.Contains(rucksack[i]))
                    {
                        answer += Score(rucksack[i]);
                        break;
                    }
                }
            }
        }

        return answer;
    }

    public static int SecondStar()
    {
        var answer = File.ReadAllLines(InputFinder.GetInputPath(InputFile))
            .Chunk(3)
            .Select(x => x.Select(y => y.ToList()).ToList()).Select(x =>
            {
                var sames = x[0];

                for (int i = 1; i < x.Count; i++)
                {
                    sames = sames.Intersect(x[i]).ToList();
                }

                return sames[0];
            })
            .Sum(x => Score(x));

        return answer;
    }

    private static int Score(char letter)
    {
        if (letter <= 'Z')
            return letter - 'A' + 27;

        return letter - 'a' + 1;
    }
}
