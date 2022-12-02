namespace Solutions;

public class Day2
{
    public static readonly string InputFile = "Day2-1.txt";

    public static readonly Dictionary<char, int> ItemScores = new()
    {
        { 'X', 1 },
        { 'Y', 2 },
        { 'Z', 3 },
    };
    public static readonly Dictionary<char, char> WinningCombinations = new()
    {
        { 'X', 'C' },
        { 'Y', 'A' },
        { 'Z', 'B' },
        { 'A', 'Z' },
        { 'B', 'X' },
        { 'C', 'Y' },
    };

    public static readonly Dictionary<char, int> ResultToScores = new()
    {
        { 'X', 0 },
        { 'Y', 3 },
        { 'Z', 6 },
    };

    public static int FirstStar()
    {
        var answer = File.ReadAllLines(InputFinder.GetInputPath(InputFile))
            .Select(x => x.Split())
            .Sum(x => 
                ItemScores[x[1][0]] +
                (WinningCombinations[x[1][0]] == x[0][0]
                    ? 6
                    : (WinningCombinations[x[0][0]] == x[1][0] ? 0 : 3)));

        return answer;
    }

    public static int SecondStar()
    {
        var answer = File.ReadAllLines(InputFinder.GetInputPath(InputFile))
            .Select(x => x.Split())
            .Sum(x => 
            {
                var options = new HashSet<char> { 'X', 'Y', 'Z' };
                var answer = x[1][0] switch
                {
                    'X' => WinningCombinations[x[0][0]],
                    'Y' => x[0][0] + 'X' - 'A',
                    'Z' => WinningCombinations
                        .FirstOrDefault(y => y.Value == x[0][0])
                        .Key,
                    _ => '0'
                };

                return ItemScores[(char)answer] + ResultToScores[x[1][0]];
            });

        return answer;
    }
}
