using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace Solutions;

public static class Day5
{
    public static readonly string InputFile = "Day5-1.txt";

    public static string FirstStar()
    {
        var lines = File.ReadAllLines(InputFinder.GetInputPath(InputFile))
                .ToList();

        var scheme = lines.TakeWhile(x => !string.IsNullOrEmpty(x))
            .ToArray();

        var nums = scheme[^1]
            .Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
            .Select(int.Parse)
            .Count();
        scheme = scheme[0..^1];

        var stacks = new List<Stack<char>>(nums);

        for (int i = 0; i < nums; i++)
        {
            var index = i * 4;
            stacks.Add(new Stack<char>(scheme.Length));
            for (int j = scheme.Length - 1; j >= 0; j--)
            {
                if (scheme[j][index] == ' ')
                    break;

                stacks[i].Push(scheme[j][index + 1]);
            }
        }

        var moves = lines.Skip(scheme.Length + 2)
            .ToList();

        moves.Select(x => x.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries))
            .Select(x => new { Num = int.Parse(x[1]), From = int.Parse(x[3]), To = int.Parse(x[5]) })
            .ToList()
            .ForEach(x =>
            {
                MoveContainers(stacks, x.Num, x.From, x.To);
            });

        var answer = "";
        for (int i = 0; i < nums; i++)
        {
            answer += stacks[i].Pop();
        }

        return answer;
    }

    private static void MoveContainers(List<Stack<char>> stacks, int count, int from, int to)
    {
        for (int i = 0; i < count; i++)
        {
            var top = stacks[from - 1].Pop();
            stacks[to - 1].Push(top);
        }
    }

    public static string SecondStar()
    {
        var lines = File.ReadAllLines(InputFinder.GetInputPath(InputFile))
                .ToList();

        var scheme = lines.TakeWhile(x => !string.IsNullOrEmpty(x))
            .ToArray();

        var nums = scheme[^1]
            .Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
            .Select(int.Parse)
            .Count();
        scheme = scheme[0..^1];

        var stacks = new List<Stack<char>>(nums);

        for (int i = 0; i < nums; i++)
        {
            var index = i * 4;
            stacks.Add(new Stack<char>(scheme.Length));
            for (int j = scheme.Length - 1; j >= 0; j--)
            {
                if (scheme[j][index] == ' ')
                    break;

                stacks[i].Push(scheme[j][index + 1]);
            }
        }

        var moves = lines.Skip(scheme.Length + 2)
            .ToList();

        moves.Select(x => x.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries))
            .Select(x => new { Num = int.Parse(x[1]), From = int.Parse(x[3]), To = int.Parse(x[5]) })
            .ToList()
            .ForEach(x =>
            {
                MoveContainersTogether(stacks, x.Num, x.From, x.To);
            });

        var answer = "";
        for (int i = 0; i < nums; i++)
        {
            answer += stacks[i].Pop();
        }

        return answer;
    }

    private static void MoveContainersTogether(List<Stack<char>> stacks, int count, int from, int to)
    {
        var items = new List<char>();
        for (int i = 0; i < count; i++)
        {
            var top = stacks[from - 1].Pop();
            items.Add(top);
        }

        for (int i = count - 1; i >=0; i--)
        {
            stacks[to - 1].Push(items[i]);
        }
    }
}
